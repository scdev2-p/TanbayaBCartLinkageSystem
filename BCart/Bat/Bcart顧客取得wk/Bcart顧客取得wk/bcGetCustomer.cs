using BCartApi;
using BCartApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bcart顧客取得wk
{
    internal class bcGetCustomer
    {
        private const int cLimit = 100;
        private const string cApiComm = "customers";

        public bcGetCustomer() 
        {
            
        }


        public static bool Do()
        {
            // Bカートの会員データ全件取得し、wkテーブルに保存する
            using(AppData.dsBcartTableAdapters.wk_bc会員eMailTableAdapter ta = new AppData.dsBcartTableAdapters.wk_bc会員eMailTableAdapter())
            using(AppData.dsBcart.wk_bc会員eMailDataTable dt = new AppData.dsBcart.wk_bc会員eMailDataTable())
            {
                // トランザクションスコープ
                using (TransactionScope tc = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(300)))
                {
                    try
                    {
                        // wkの全レコード削除
                        ta.DeleteAllQuery();

                        using (HttpApiCommon com = new HttpApiCommon())
                        {
                            // apiで会員情報取得を繰り返す
                            int offset = 0;
                            while (true)
                            {

                                // 会員情報を取得
                                ApiCommandParam[] prm = { new ApiCommandParam("limit", cLimit.ToString()), new ApiCommandParam("offset", offset.ToString()) };
                                cCustomerResponse ret = com.GetListCommand<cCustomerResponse>(cApiComm, prm);
                                if (ret == null)
                                {
                                    Log.ErrWrite("会員情報取得エラー");
                                    return false;
                                }

                                if(ret.customers.Count == 0)
                                {
                                    // 終了
                                    break;
                                }

                                foreach (var customer in ret.customers)
                                {
                                    string custom3 = "";
                                    if (customer.customs != null)
                                    { 
                                        foreach (var custom in customer.customs)
                                        {
                                            if (custom.field_id == 3)
                                            {
                                                custom3 = custom.value;
                                                break;
                                            }
                                        }
                                    }
                                    // DB Insert
                                    ta.Insert(customer.id,0, customer.email, custom3);
                                }
                                offset += ret.customers.Count;

                                System.Threading.Thread.Sleep(1000);
                            }
                        }

                    }
                    catch(Exception ex)
                    {
                        Log.ErrWrite("会員情報の登録でエラー", ex);
                        return false;
                    }

                    tc.Complete();
                }
            }

            return true;
        }


    }
}
