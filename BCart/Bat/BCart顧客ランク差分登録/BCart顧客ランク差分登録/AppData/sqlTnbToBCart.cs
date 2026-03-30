using BCartApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart顧客ランク差分登録.AppData
{
    internal class sqlTnbToBCart :IDisposable
    {
        private SqlConnection conn = new SqlConnection(Settings.Default.TnbToBCartDB);

        public sqlTnbToBCart()
        {
            // this.conn.Open();
        }

        public void Dispose()
        {
            try
            {
                this.conn.Close();
                this.conn.Dispose();
            }
            catch { }
        }


        // メンテナンス等でDBに接続できない時は実行しない
        public static bool CheckConnect()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Settings.Default.TnbToBCartDB))
                {
                    con.Open();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("DB接続エラー", ex);
                return false;
            }
            return true;
        }

        public bool MakeRegistCustomer()
        {
            SqlCommand cmd = this.conn.CreateCommand();
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                this.conn.Open();
            }
            cmd.CommandText = "exec S_MakeBC顧客";
 
            try
            {
                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("bc顧客送信用 作成エラー："), ex);
                return false;
            }
            return true;
        }

        public bool UpdateImportedCustomerRank(long customerID, int rank)
        {
            SqlCommand cmd = this.conn.CreateCommand();
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                this.conn.Open();
            }
            cmd.CommandText = @"UPDATE [dbo].[bc登録済顧客] SET [価格グループID] = @rank WHERE [Bカート会員ID] = @customer_id";
            cmd.Parameters.Add(new SqlParameter("@customer_id", customerID));
            cmd.Parameters.Add(new SqlParameter("@rank", rank));

            try
            {
                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("bc登録済顧客 更新エラー：{0}：{1}", customerID, rank), ex);
                return false;
            }

            return true;
        }
    }
}
