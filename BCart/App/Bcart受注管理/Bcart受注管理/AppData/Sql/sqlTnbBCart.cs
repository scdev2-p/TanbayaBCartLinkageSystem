using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Bcart受注管理.Models;
using System.Data;

namespace Bcart受注管理.AppData.Sql
{
    internal class sqlTnbBCart : IDisposable
    {

        private SqlConnection con;

        public sqlTnbBCart()
        {
            con = new SqlConnection(Settings.Default.BCartDBConnectionString);
        }

        public void Dispose()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            con.Dispose();
        }

        // 送信用顧客の作成
        public bool MakeSendCustomer()
        {
            Program.ScLogger.Info($"start");

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "exec [S_MakeBC顧客]";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("送信顧客作成エラー", ex);
                Program.ScLogger.Error(ex);
                return false;
            }

            return true;
        }


        // 受注番号から受注IDを取得
        public long GetOrderIdByCode(string code)
        {
            Program.ScLogger.Info($"start {nameof(code)}={code}");
            long ret = -1;

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "select order_id from bc_order where order_code = @order_code";
                    cmd.Parameters.Add(new SqlParameter("@order_code", code));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        ret = (long)dr[0];
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("送信顧客作成エラー", ex);
                Program.ScLogger.Error(ex);
                return -1;
            }

            Program.ScLogger.Info($"return {nameof(ret)}={ret}");
            return ret;
        }

        // ピッキング番号からピッキングIDを取得
        public long GetPickingIdByCOde(string code)
        {
            Program.ScLogger.Info($"start {nameof(code)}={code}");
            long ret = -1;

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "select picking_id from bc_picking where picking_code = @picking_code";
                    cmd.Parameters.Add(new SqlParameter("@picking_code", code));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        ret = (long)dr[0];
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("送信顧客作成エラー", ex);
                Program.ScLogger.Error(ex);
                return -1;
            }

            Program.ScLogger.Info($"return {nameof(ret)}={ret}");
            return ret;
        }

        public bool DeleteOrder(long orderId)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "exec S_DeleteOrder " + orderId.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("受注データ削除エラー", ex);
                Program.ScLogger.Error(ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注・ピッキング関連データ及び基幹の伝票明細ﾃﾞｰﾀを作成するストアドプロシージャを実行します。
        /// </summary>
        /// <param name="orderId">受注ID</param>
        /// <param name="pickingStatus">ピッキングステータス(0：未処理（初期値）、1:ピッキング済み）</param>
        /// <returns>通常終了:true,例外発生:false</returns>
        public bool MakeOrderStatus(long orderId, int pickingStatus)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}, {nameof(pickingStatus)}={pickingStatus}");

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "exec S_MakeOrderStatus " + orderId.ToString() + "," + pickingStatus.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("受注データ削除エラー", ex);
                Program.ScLogger.Error(ex);
                return false;
            }

            return true;

        }
        //
        public bool DeleteRegiDetail(long orderId)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "exec S_DeleteRegiDetail " + orderId.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("レジ伝票明細データ削除エラー", ex);
                Program.ScLogger.Error(ex);
                return false;
            }

            return true;

        }

        /// <summary>
        /// w_レジ伝票明細の詳細ﾃﾞｰﾀを作成するストアドプロシージャを実行します
        /// </summary>
        /// <param name="orderId">受注ID</param>
        /// <returns>通常終了:true,例外発生:false</returns>
        public bool MakeRegiDetail(long orderId)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {   
                    // 360秒でタイムアウト
                    cmd.CommandTimeout = Settings.Default.TimeoutInSeconds;
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "exec S_MakeRegiDetail " + orderId.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("w_レジ伝票明細の取得エラー", ex);
                Program.ScLogger.Error(ex);
                return false;
            }

            return true;

        }

        /// <summary>
        /// 取り置きデータからW_レジ伝票明細を作成するストアドプロシージャを実行します
        /// </summary>
        /// <param name="reserved_id">受注ID</param>
        /// <returns>通常終了:true,例外発生:false</returns>
        public bool MakeRegiByReserved(long reserved_id)
        {
            Program.ScLogger.Info($"start {nameof(reserved_id)}={reserved_id}");

            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    // 360秒でタイムアウト
                    cmd.CommandTimeout = Settings.Default.TimeoutInSeconds;
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    cmd.CommandText = "exec S_MakeRegiByReserved "+ reserved_id.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("w_レジ伝票明細の取得エラー", ex);
                Program.ScLogger.Error(ex);
                return false;
            }

            return true;

        }
    }
}
