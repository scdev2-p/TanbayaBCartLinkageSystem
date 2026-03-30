using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCart商品差分登録.AppData;
using BCartApi.Entity;
using BCartApi;

namespace BCart商品差分登録.Jobs
{
    /// <summary>
    /// 商品在庫の差分更新処理
    /// </summary>
    internal class bcStockUpdate:IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrl = "product_sets";

        public bcStockUpdate() { 
        
        }

        public void Dispose()
        {
            api.Dispose();
        }


        public bool Do()
        {

            int cnt = 0;        // 更新データのカウンタ
            int apiCnt = 0;     // api実行数のカウンタ（上限まで実行）

            try
            {
                using (AppData.dsTnbToBCartTableAdapters.S_商品在庫差分抽出TableAdapter taStock = new AppData.dsTnbToBCartTableAdapters.S_商品在庫差分抽出TableAdapter())
                using (dsTnbToBCart.S_商品在庫差分抽出DataTable dtStock = new dsTnbToBCart.S_商品在庫差分抽出DataTable())
                using (AppData.dsTnbToBCartTableAdapters.bc商品ゼロ在庫TableAdapter taZeroStock = new AppData.dsTnbToBCartTableAdapters.bc商品ゼロ在庫TableAdapter())
                using (dsTnbToBCart.bc商品ゼロ在庫DataTable dtZeroStock = new dsTnbToBCart.bc商品ゼロ在庫DataTable())
                using (AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter taDel = new AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter())
                {
                    // 商品在庫差分の抽出
                    taStock.Fill(dtStock);
                    Log.Write(string.Format("在庫更新対象件数[{0}]", dtStock.Count));

                    cProductSetStockRequest request = new cProductSetStockRequest();
                    foreach (dsTnbToBCart.S_商品在庫差分抽出Row row in dtStock)
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
                        cProductSetStock ps = new cProductSetStock();
                        ps.id = row.セット_BカートセットID;
                        ps.stock = row.在庫;
                        request.product_sets.Add(ps);

                        if (row.在庫 == 0 && row.旧在庫 > 0)
                        {
                            // 在庫がゼロになった場合
                            // ゼロになった日付をセット
                            taZeroStock.FillByID(dtZeroStock, row.基本_Bカート商品ID, row.セット_BカートセットID);
                            if(dtZeroStock.Count > 0)
                            {
                                // 更新
                                dtZeroStock[0].zero_stock_day = DateTime.Now;
                            }
                            else
                            {
                                // 新規
                                var newRow = dtZeroStock.Newbc商品ゼロ在庫Row();
                                newRow.基本_Bカート商品ID = row.基本_Bカート商品ID;
                                newRow.セット_BカートセットID = row.セット_BカートセットID;
                                newRow.zero_stock_day = DateTime.Now;
                                newRow.Setdisabled_dayNull();
                                dtZeroStock.Addbc商品ゼロ在庫Row(newRow);
                            }
                            taZeroStock.Update(dtZeroStock);
                        }
                        else if (row.在庫 > 0 && row.旧在庫 == 0)
                        {
                            // 在庫がゼロから復活した場合(自動非表示にしたもののみ)
                            taZeroStock.FillByID(dtZeroStock, row.基本_Bカート商品ID, row.セット_BカートセットID);
                            if (dtZeroStock.Count > 0)
                            {
                                // 更新
                                dtZeroStock[0].Setzero_stock_dayNull();   // 非表示解除対象となる
                                taZeroStock.Update(dtZeroStock);
                            }
                            else
                            {
                                // ゼロ在庫自動非表示にしてない商品は無視
                            }

                        }
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

                    // bc在庫更新対象商品の削除
                    foreach(var row in dtStock)
                    {
                        taDel.DeleteRegTargetStock(row.基本_Bカート商品ID, row.セット_BカートセットID);
                    }

                }


            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("エラー[{0}]", cnt), ex);
                return false;
            }
            return true;
        }

        private bool UpdateProductSets(cProductSetStockRequest request)
        {
            if (Settings.Default.ApiDisable)
            {
                Log.Write("デバッグ：APIスキップ");
                return true;
            }

            cProductSetStockResponse ret = this.api.PatchListCommand<cProductSetStockRequest, cProductSetStockResponse>(commandUrl, request);
            if(ret == null || ret.product_sets == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            // 取込済商品の在庫を更新する（登録結果を元に更新する）
            using (sqlTnbToBCart sql = new sqlTnbToBCart())
            {
                foreach (cProductSetStock row in ret.product_sets)
                {
                    if (!sql.UpdateImportedProductsStock(row.id, row.stock))
                        return false;
                }
            }
            return true;
        }

    }
}
