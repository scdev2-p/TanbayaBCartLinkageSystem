using BCartApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc自動非表示設定.AppData
{
    internal class sqlTnbToBCart:IDisposable
    {
        private SqlConnection conn = new SqlConnection(Settings.Default.TnbToBCartDB);

        public sqlTnbToBCart()
        {

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



        public bool UpdateZeroStockFlag(long productSetID)
        {
            SqlCommand cmd = this.conn.CreateCommand();
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                this.conn.Open();
            }
            cmd.CommandText = @"UPDATE [dbo].[bc商品ゼロ在庫] SET [disabled_day] = getdate() WHERE [セット_BカートセットID] = @product_set_id";
            cmd.Parameters.Add(new SqlParameter("@product_set_id", productSetID));

            try
            {
                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("bc商品ゼロ在庫 更新エラー：{0}", productSetID), ex);
                return false;
            }
            return true;
        }


        public bool UpdateBackInStockFlag(long productSetID)
        {
            SqlCommand cmd = this.conn.CreateCommand();
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                this.conn.Open();
            }
            cmd.CommandText = @"UPDATE [dbo].[bc商品ゼロ在庫] SET [zero_stock_day] = NULL, [disabled_day] = NULL WHERE [セット_BカートセットID] = @product_set_id";
            cmd.Parameters.Add(new SqlParameter("@product_set_id", productSetID));

            try
            {
                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("bc商品ゼロ在庫 更新エラー：{0}", productSetID), ex);
                return false;
            }
            return true;
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
    }
}
