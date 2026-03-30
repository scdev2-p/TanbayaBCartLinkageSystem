using BCartApi.Entity;
using BCartApi;
using bc自動非表示設定.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc自動非表示設定.Jobs
{
    /// <summary>
    /// 在庫復活
    /// </summary>
    public class cBackInStock : IDisposable
    {
        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlSet = "product_sets";
        private const string commandUrlProducts = "products";

        public cBackInStock()
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
                {
                    ta.FillByBackInStoc(dt);

                    cProductSetFlagRequest requestSet = new cProductSetFlagRequest();
                    cSetProductsFlagByIDRequest requestProducts = new cSetProductsFlagByIDRequest();
                    foreach (var row in dt)
                    {

                        // 100件ずつまとめて更新する
                        if (cnt != 0 && cnt % 100 == 0)
                        {
                            // api 実行
                            if (!UpdateProductSets(requestSet, requestProducts))
                            {
                                // 実行エラー
                                return false;
                            }

                            requestSet.product_sets.Clear();
                            requestProducts.products.Clear();
                            apiCnt++;
                            if (apiCnt >= Settings.Default.ApiLimit)
                            {
                                Log.Write("Api実行制限のため中断：" + apiCnt.ToString());
                                break;
                            }
                        }


                        Log.Write(string.Format("商品基本・セット 再表示：[{0}] [{1}]",row.基本_Bカート商品ID, row.セット_BカートセットID));
                        // list add
                        cProductSetFlag psSet = new cProductSetFlag();
                        psSet.id = row.セット_BカートセットID;
                        psSet.set_flag = "表示";
                        requestSet.product_sets.Add(psSet);

                        cSetProductsFlagByID psProduct = new cSetProductsFlagByID();
                        psProduct.id = row.基本_Bカート商品ID;
                        psProduct.flag = "表示";
                        requestProducts.products.Add(psProduct);

                        cnt++;
                    }

                    if (requestSet.product_sets.Count > 0)
                    {
                        // api 実行
                        if (!UpdateProductSets(requestSet, requestProducts))
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


        private bool UpdateProductSets(cProductSetFlagRequest requestSet, cSetProductsFlagByIDRequest requestProduct)
        {
            if (Settings.Default.ApiDisable)
            {
                Log.Write("デバッグ：APIスキップ");
                return true;
            }

            cProductSetNewResponse retSet = this.api.PatchListCommand<cProductSetFlagRequest, cProductSetNewResponse>(commandUrlSet, requestSet);
            if (retSet == null || retSet.product_sets == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            cInsertProductsResponse retProduct = this.api.PatchListCommand<cSetProductsFlagByIDRequest, cInsertProductsResponse>(commandUrlProducts, requestProduct);
            if (retProduct == null || retProduct.products == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }



            // 在庫ゼロ商品の情報を更新
            using (sqlTnbToBCart sql = new sqlTnbToBCart())
            {
                foreach (cProductSetGet row in retSet.product_sets)
                {
                    if (!sql.UpdateBackInStockFlag(row.id))
                        return false;
                }
            }
            return true;
        }

    }
}
