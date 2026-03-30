using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcart受注管理.AppData.Sql
{
    internal class OrderCustomerAddress
    {

        public static bool WriteSagawaCsvFromOrder(long orderID)
        {
            StringBuilder sb = new StringBuilder();

            using (Ds.dsBCartLink2TableAdapters.vwBc受注顧客住所TableAdapter ta = new Ds.dsBCartLink2TableAdapters.vwBc受注顧客住所TableAdapter())
            using (Ds.dsBCartLink2.vwBc受注顧客住所DataTable dt = new Ds.dsBCartLink2.vwBc受注顧客住所DataTable())
            {
                try
                {
                    ta.FillByOrderID(dt, orderID);
                }
                catch (Exception e)
                {
                    Program.ScLogger.Error($"{nameof(orderID)}={orderID},\"佐川用CSV作成の受注データ読み込みでエラーが発生しました。\"");
                    Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                    Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                    return false;
                }

                if (dt.Count > 0)
                {
                    sb.Append(dt[0].customer_code);
                    sb.Append(",");
                    sb.Append(dt[0].customer_comp_name);
                    sb.Append(",");
                    sb.Append(dt[0].customer_tel);
                    sb.Append(",");
                    sb.Append(dt[0].customer_zip);
                    sb.Append(",");
                    sb.Append(dt[0].customer_address);

                    try
                    {

                        // 更新日が昨日以前なら削除
                        DateTime fTime = File.GetLastWriteTime(Settings.Default.SagawaPath);
                        if (fTime.Date < DateTime.Now.Date)
                        {
                            File.Delete(Settings.Default.SagawaPath);
                        }

                        // csvファイルに書き込む
                        using (StreamWriter sw = new StreamWriter(Settings.Default.SagawaPath, true, System.Text.Encoding.GetEncoding("shift_jis")))
                        {
                            sw.WriteLine(sb.ToString());
                            sw.Flush();
                            sw.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        Program.ScLogger.Error($"{nameof(orderID)}={orderID},\"佐川用CSV書込みでエラーが発生しました。。\"");
                        Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                        Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool WriteSagawaCsvFromReserved(long reservedID)
        {
            using(Ds.dsBCartLink2TableAdapters.QueriesTableAdapter ta = new Ds.dsBCartLink2TableAdapters.QueriesTableAdapter())
            {
                try
                {
                    long? orderID =ta.sqGetReservedLastOrder(reservedID);

                    if(orderID.HasValue)
                    {
                        return WriteSagawaCsvFromOrder((long)orderID);
                    }

                }
                catch (Exception e)
                {
                    Program.ScLogger.Error($"{nameof(reservedID)}={reservedID},\"佐川用CSV作成の取り置きデータ取得でエラーが発生しました。\"");
                    Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                    Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                    return false;
                }
            }

            return true;
        }

    }
}
