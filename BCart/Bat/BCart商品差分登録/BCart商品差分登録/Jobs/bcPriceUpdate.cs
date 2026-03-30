using BCartApi;
using BCartApi.Entity;
using BCart商品差分登録.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart商品差分登録.Jobs
{
    /// <summary>
    /// 商品価格の差分登録処理
    /// </summary>
    internal class bcPriceUpdate : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrl = "product_sets";

        public bcPriceUpdate()
        {

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
                using (AppData.dsTnbToBCartTableAdapters.S_商品価格差分抽出TableAdapter taPrice = new AppData.dsTnbToBCartTableAdapters.S_商品価格差分抽出TableAdapter())
                using (dsTnbToBCart.S_商品価格差分抽出DataTable dtPrice = new dsTnbToBCart.S_商品価格差分抽出DataTable())
                {
                    // 商品在庫差分の抽出
                    taPrice.Fill(dtPrice);
                    Log.Write(string.Format("価格更新対象件数[{0}]", dtPrice.Count));

                    cProductSetPriceRequest request = new cProductSetPriceRequest();
                    foreach (dsTnbToBCart.S_商品価格差分抽出Row row in dtPrice)
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
                        cProductSetPrice ps = new cProductSetPrice();
                        ps.id = row.セット_BカートセットID;
                        ps.jodai = row.上代単価;
                        ps.unit_price = row.価格0;

                        ps.group_price.gp1.unit_price = row.価格1;
                        ps.group_price.gp1.fixed_price = row.価格1;

                        ps.group_price.gp2.unit_price = row.価格2;
                        ps.group_price.gp2.fixed_price = row.価格2;

                        ps.group_price.gp3.unit_price = row.価格3;
                        ps.group_price.gp3.fixed_price = row.価格3;

                        ps.group_price.gp4.unit_price = row.価格4;
                        ps.group_price.gp4.fixed_price = row.価格4;

                        ps.group_price.gp5.unit_price = row.価格5;
                        ps.group_price.gp5.fixed_price = row.価格5;

                        ps.group_price.gp6.unit_price = row.価格6;
                        ps.group_price.gp6.fixed_price = row.価格6;

                        ps.group_price.gp7.unit_price = row.価格7;
                        ps.group_price.gp7.fixed_price = row.価格7;

                        ps.group_price.gp8.unit_price = row.価格8;
                        ps.group_price.gp8.fixed_price = row.価格8;

                        request.product_sets.Add(ps);
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
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("エラー[{0}]", cnt), ex);
                return false;
            }
            return true;
        }


        private bool UpdateProductSets(cProductSetPriceRequest request)
        {
            if(Settings.Default.ApiDisable)
            {
                Log.Write("デバッグ：APIスキップ");
                return true;
            }

            cProductSetPriceResponse ret = this.api.PatchListCommand<cProductSetPriceRequest, cProductSetPriceResponse>(commandUrl, request);
            if (ret == null || ret.product_sets == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            // 取込済商品の在庫を更新する（登録結果を元に更新する）
            using (sqlTnbToBCart sql = new sqlTnbToBCart())
            {
                foreach (cProductSetPrice row in ret.product_sets)
                {
                    if (!sql.UpdateImportedProductsPrice(row.id, row.jodai, row.unit_price,
                        row.group_price.gp1.fixed_price,
                        row.group_price.gp2.fixed_price,
                        row.group_price.gp3.fixed_price,
                        row.group_price.gp4.fixed_price,
                        row.group_price.gp5.fixed_price,
                        row.group_price.gp6.fixed_price,
                        row.group_price.gp7.fixed_price,
                        row.group_price.gp8.fixed_price
                        ))
                        return false;
                }
            }
            return true;
        }
    }
}
