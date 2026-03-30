using BCartApi.Entity;
using BCartApi;
using BCart顧客ランク差分登録.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart顧客ランク差分登録.Jobs
{


    internal class bcRankUpdate : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrl = "customers";

        public bcRankUpdate()
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
                // 顧客送信用を作成
                using(sqlTnbToBCart sql = new sqlTnbToBCart())
                {
                    if(!sql.MakeRegistCustomer())
                    {
                        Log.ErrWrite("システムエラー!");
                        return false;
                    }
                }

                using (AppData.dsTnbToBCartDBTableAdapters.S_顧客ランク差分抽出TableAdapter taRank = new AppData.dsTnbToBCartDBTableAdapters.S_顧客ランク差分抽出TableAdapter())
                using (dsTnbToBCartDB.S_顧客ランク差分抽出DataTable dtRank = new dsTnbToBCartDB.S_顧客ランク差分抽出DataTable())
                {
                    // ランクが変わった顧客の抽出
                    taRank.Fill(dtRank);
                    Log.Write(string.Format("顧客ランク更新対象件数[{0}]", dtRank.Count));

                    cCustomerRankRequest request = new cCustomerRankRequest();
                    foreach (dsTnbToBCartDB.S_顧客ランク差分抽出Row row in dtRank)
                    {

                        // 100件ずつまとめて更新する
                        if (cnt != 0 && cnt % 100 == 0)
                        {
                            // api 実行
                            if (!UpdateCustomerRank(request))
                            {
                                // 実行エラー
                                return false;
                            }

                            request.customers.Clear();
                            apiCnt++;
                            if (apiCnt >= Settings.Default.ApiLimit)
                            {
                                Log.Write("Api実行制限のため中断：" + apiCnt.ToString());
                                break;
                            }
                        }

                        // list add
                        cCustomerRank ps = new cCustomerRank();
                        ps.id = row.Bカート会員ID;
                        ps.price_group_id = int.Parse(row.新ランク);
                        request.customers.Add(ps);

                        Log.Write(string.Format("顧客ランク変更 ID:{0} Rank:{1}", ps.id, ps.price_group_id));

                        cnt++;

                    }
                    if (request.customers.Count > 0)
                    {
                        // api 実行
                        if (!UpdateCustomerRank(request))
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

        private bool UpdateCustomerRank(cCustomerRankRequest request)
        {
            if (Settings.Default.ApiDisable)
            {
                Log.Write("デバッグ：APIスキップ");
                return true;
            }

            cCustomerRankRequest ret = this.api.PatchListCommand<cCustomerRankRequest, cCustomerRankRequest>(commandUrl, request);
            if (ret == null || ret.customers == null)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            // 取込済商品の在庫を更新する（登録結果を元に更新する）
            using (sqlTnbToBCart sql = new sqlTnbToBCart())
            {
                foreach (cCustomerRank row in ret.customers)
                {
                    int rank = 0;
                    if (row.price_group_id != null)
                        rank = (int)row.price_group_id;

                    if (!sql.UpdateImportedCustomerRank(row.id, rank))
                        return false;
                }
            }
            return true;
        }

    }
}
