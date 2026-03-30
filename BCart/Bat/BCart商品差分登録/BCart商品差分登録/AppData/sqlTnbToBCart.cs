using BCartApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart商品差分登録.AppData
{

    /*
     * データセットでは遅くなりそうなのでSQLコマンドで実行する
     */


    internal class sqlTnbToBCart:IDisposable
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
            catch(Exception ex)
            {
                Log.ErrWrite("DB接続エラー", ex);
                return false;
            }
            return true;
        }


        public bool UpdateImportedProductsStock(long productSetID, decimal stock)
        {
            SqlCommand cmd = this.conn.CreateCommand();
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                this.conn.Open();
            }
            cmd.CommandText = "update bc登録済商品 set セット_在庫 = @stock where セット_BカートセットID = @product_set_id";
            cmd.Parameters.Add(new SqlParameter("@product_set_id", productSetID));
            cmd.Parameters.Add(new SqlParameter("@stock", stock));

            try
            {
                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("bc登録済商品 更新エラー：{0}：{1}", productSetID, stock), ex);
                return false;
            }
            return true;
        }

        //public bool UpdateZeroStockFlag(long productSetID, bool enable)
        //{
        //    SqlCommand cmd = this.conn.CreateCommand();
        //    if (this.conn.State != System.Data.ConnectionState.Open)
        //    {
        //        this.conn.Open();
        //    }
        //    cmd.CommandText = @"UPDATE [dbo].[bc商品ゼロ在庫] SET [disabled_day] = @disabled_day WHERE [セット_BカートセットID] = @product_set_id";
        //    cmd.Parameters.Add(new SqlParameter("@product_set_id", productSetID));
        //    cmd.Parameters.Add(new SqlParameter("@disabled_day", enable? DBNull.Value : DateTime.Now));
             
        //    try
        //    {
        //        int ret = cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.ErrWrite(string.Format("bc登録済商品 更新エラー：{0}：{1}", productSetID, enable), ex);
        //        return false;
        //    }
        //    return true;
        //}



        public bool UpdateImportedProductsPrice(long productSetID, decimal jodai, decimal unitPrice,
            decimal g1Price, decimal g2Price, decimal g3Price, decimal g4Price, decimal g5Price, decimal g6Price, decimal g7Price, decimal g8Price)
        {
            SqlCommand cmd = this.conn.CreateCommand();
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                this.conn.Open();
            }
            cmd.CommandText =
@"update bc登録済商品 set
 [セット_上代] = @jodai
,[セット_単価] = @unitPrice
,[セット_グループ価格1] = @g1Price
,[セット_グループ価格2] = @g2Price
,[セット_グループ価格3] = @g3Price
,[セット_グループ価格4] = @g4Price
,[セット_グループ価格5] = @g5Price
,[セット_グループ価格6] = @g6Price
,[セット_グループ価格7] = @g7Price
,[セット_グループ価格8] = @g8Price
where セット_BカートセットID = @product_set_id";
            cmd.Parameters.Add(new SqlParameter("@product_set_id", productSetID));
            cmd.Parameters.Add(new SqlParameter("@jodai", jodai));
            cmd.Parameters.Add(new SqlParameter("@unitPrice", unitPrice));
            cmd.Parameters.Add(new SqlParameter("@g1Price", g1Price));
            cmd.Parameters.Add(new SqlParameter("@g2Price", g2Price));
            cmd.Parameters.Add(new SqlParameter("@g3Price", g3Price));
            cmd.Parameters.Add(new SqlParameter("@g4Price", g4Price));
            cmd.Parameters.Add(new SqlParameter("@g5Price", g5Price));
            cmd.Parameters.Add(new SqlParameter("@g6Price", g6Price));
            cmd.Parameters.Add(new SqlParameter("@g7Price", g7Price));
            cmd.Parameters.Add(new SqlParameter("@g8Price", g8Price));

            try
            {
                int ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("bc登録済商品 更新エラー：{0}：{1}", productSetID, jodai), ex);
                return false;
            }
            return true;
        }




    }
}
