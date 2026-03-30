using BCartApi;
using BCartApi.Entity;
using bc自動非表示設定.AppData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc自動非表示設定.Jobs
{

    /// <summary>
    /// ゼロ在庫期限切れ
    /// </summary>
    internal class cZeroTeamOver:IDisposable
    {
        HttpApiCommon api = new HttpApiCommon();
        private const string commandProductSetUrl = "product_sets";
        private const string commandProductUrl = "products";

        public cZeroTeamOver() 
        { 


        }

        public void Dispose() 
        {

        }


        public bool Do()
        {
            int cnt = 0;        // 更新データのカウンタ
            int apiCnt = 0;     // api実行数のカウンタ（上限まで実行）

            try
            {
                using (AppData.dsTnbToBCartDBTableAdapters.bc商品ゼロ在庫TableAdapter ta = new AppData.dsTnbToBCartDBTableAdapters.bc商品ゼロ在庫TableAdapter())
                using (dsTnbToBCartDB.bc商品ゼロ在庫DataTable dt = new dsTnbToBCartDB.bc商品ゼロ在庫DataTable())
                using (AppData.dsTnbToBCartDBTableAdapters.bc登録済商品TableAdapter taRegPro = new AppData.dsTnbToBCartDBTableAdapters.bc登録済商品TableAdapter())
                using (dsTnbToBCartDB.bc登録済商品DataTable dtRegPro = new dsTnbToBCartDB.bc登録済商品DataTable())
                {
                    ta.FillByZeroTermOver(dt, Settings.Default.ZeroTerm);


                    List<long> parentProductsIDList = new List<long>(); // 親の商品基本IDのリスト

                    cProductSetFlagRequest request = new cProductSetFlagRequest();
                    foreach (var row in dt)
                    {

                        // 100件ずつまとめて更新する
                        if (cnt != 0 && cnt % 100 == 0)
                        {
                            // api 実行
                            if (!UpdateProductSets(request))
                            {
                                // 実行エラー
                                return false;
                            }

                            request.product_sets.Clear();
                            apiCnt++;
                            if (apiCnt >= Settings.Default.ApiLimit)
                            {
                                Log.Write("Api実行制限のため中断：" + apiCnt.ToString());
                                break;
                            }
                        }

                        // list add
                        Log.Write(string.Format("セット情報非表示：{0}", row.セット_BカートセットID));

                        cProductSetFlag ps = new cProductSetFlag();
                        ps.id = row.セット_BカートセットID;
                        ps.set_flag = "非表示";
                        request.product_sets.Add(ps);

                        if (!parentProductsIDList.Contains(row.基本_Bカート商品ID))
                            parentProductsIDList.Add(row.基本_Bカート商品ID);

                        cnt++;
                    }

                    if (request.product_sets.Count > 0)
                    {
                        // api 実行
                        if (!UpdateProductSets(request))
                        {
                            // 実行エラー
                            return false;
                        }
                    }



                    // ===============================================================================
                    // 全てのセット情報が非表示になった商品は、商品基本も非表示にする
                    // セット情報が実際表示か非表示かはBカートの情報を見るしかない
                    // 100件ずつ取得する
                    // ===============================================================================
                    
                    List<long> disabledProductIDList = new List<long>();    // 非表示にする商品基本IDのリスト
                    foreach(var productID in parentProductsIDList)
                    {
                        // セット譲歩が複数かbc取込済商品より取得してチェックする
                        taRegPro.FillByProductID(dtRegPro, productID);
                        if(dtRegPro.Count == 1)
                        {
                            // セットが1つだけ
                            // 商品基本を非表示にする
                            disabledProductIDList.Add(productID);
                        }
                        else
                        { 
                            // セットが複数
                            // 商品基本を非表示にするかどうかの判定
                            if(isBcDisabledProducts(dtRegPro))
                            {
                                disabledProductIDList.Add(productID);
                            }
                        }
                    }

                    
                    cnt = 0;        // 更新データのカウンタ
                    apiCnt = 0;     // api実行数のカウンタ（上限まで実行）

                    cSetProductsFlagByIDRequest productRequest = new cSetProductsFlagByIDRequest();
                    foreach (var productID in disabledProductIDList)
                    {
                        // 100件ずつまとめて更新する
                        if (cnt != 0 && cnt % 100 == 0)
                        {
                            // api 実行
                            if (!setProductsDisabled(productRequest))
                            {
                                // 実行エラー
                                return false;
                            }

                            productRequest.products.Clear();
                        }

                        Log.Write(string.Format("商品基本非表示：{0}", productID));
                        cSetProductsFlagByID pf = new cSetProductsFlagByID();
                        pf.id = productID;
                        pf.flag = "非表示";
                        productRequest.products.Add(pf);

                        cnt++;
                    }
                    if (productRequest.products.Count > 0)
                    {
                        // api 実行
                        if (!setProductsDisabled(productRequest))
                        {
                            // 実行エラー
                            return false;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Log.ErrWrite("システムエラー", ex);
                return false;
            }

            return true;
        }


        private bool UpdateProductSets(cProductSetFlagRequest request)
        {
            if (Settings.Default.ApiDisable)
            {
                Log.Write("デバッグ：APIスキップ");
                return true;
            }

            cProductSetNewResponse ret = this.api.PatchListCommand<cProductSetFlagRequest, cProductSetNewResponse>(commandProductSetUrl, request);
            if (ret == null || ret.product_sets == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            // 在庫ゼロ情報の更新
            using (sqlTnbToBCart sql = new sqlTnbToBCart())
            {
                foreach (cProductSetGet row in ret.product_sets)
                {
                    if (!sql.UpdateZeroStockFlag(row.id))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Bカート上でセットが全て非表示かどうかを判定する
        /// セット情報が複数の商品はそんなに無いはずなので、apiの制約は考慮しない
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool isBcDisabledProducts(dsTnbToBCartDB.bc登録済商品DataTable dt)
        {
            // ありえないがスキップする
            if(dt.Count == 0)
                return false;

            // Apiでセット情報を取得
            ApiCommandParam[] prmProductSetGet = { new ApiCommandParam("limit", "100"), new ApiCommandParam("product_id", dt[0].基本_Bカート商品ID.ToString()) };
            cProductSetParentResponnse retProductSets = api.GetListCommand<cProductSetParentResponnse>(commandProductSetUrl, prmProductSetGet);
            if (retProductSets == null || retProductSets.product_sets == null)
            {
                return false;
            }

            // 全て非表示かの判定
            foreach(var productSet in retProductSets.product_sets)
            {
                if(productSet.set_flag == "表示")
                {
                    return false;
                }
            }

            return true;
        }

        private bool setProductsDisabled(cSetProductsFlagByIDRequest request)
        {
            if (Settings.Default.ApiDisable)
            {
                Log.Write("デバッグ：APIスキップ");
                return true;
            }

            cSetProductsFlagByIDRequest ret = this.api.PatchListCommand<cSetProductsFlagByIDRequest, cSetProductsFlagByIDRequest>(commandProductUrl, request);
            if (ret == null || ret.products == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            return true;
        }


    }
}
