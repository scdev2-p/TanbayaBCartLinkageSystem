using BCartApi;
using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.AppData.Sql;
using Bcart受注管理.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bcart受注管理
{
    internal class Reload
    {

        public List<string> CancelList { get; set; }

        public Reload()
        {
            CancelList = new List<string>();
        }

        struct sProductKey
        {
            public long? productId;
            public long? SetId;
        }

        public bool RelooadByCD(long OrderCD, bool IsRegist)
        {
            List<sProductKey> list = new List<sProductKey>();

            using (BCartApi.HttpApiCommon api = new HttpApiCommon())
            using (AppData.Ds.dsBCartLink2TableAdapters.bc_OrderTableAdapter taOrder = new AppData.Ds.dsBCartLink2TableAdapters.bc_OrderTableAdapter())
            using (dsBCartLink2.bc_OrderDataTable dtOrder = new dsBCartLink2.bc_OrderDataTable())
            using (AppData.Ds.dsBCartLink2TableAdapters.bc_OrderProductsTableAdapter taOrderProducts = new AppData.Ds.dsBCartLink2TableAdapters.bc_OrderProductsTableAdapter())
            using (dsBCartLink2.bc_OrderProductsDataTable dtOrderProducts = new dsBCartLink2.bc_OrderProductsDataTable())
            using (AppData.Ds.dsBCartLink2TableAdapters.QueriesTableAdapter taQuery = new AppData.Ds.dsBCartLink2TableAdapters.QueriesTableAdapter())
            using (AppData.Ds.dsBCartLink2TableAdapters.M_顧客TableAdapter taCustomer = new AppData.Ds.dsBCartLink2TableAdapters.M_顧客TableAdapter())
            using (dsBCartLink2.M_顧客DataTable dtCustomer = new dsBCartLink2.M_顧客DataTable())
            using (AppData.Ds.dsBCartLink2TableAdapters.bc_LogisticsTableAdapter taLogistics = new AppData.Ds.dsBCartLink2TableAdapters.bc_LogisticsTableAdapter())
            using (AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter Marge = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter())
            {

                // -------------------------------------------------
                // トランザクション開始
                // -------------------------------------------------
                TransactionManager.ImplicitDistributedTransactions = true;
                using (TransactionScope ts = new TransactionScope())
                {
                    Program.ScLogger.Info($"【Order取込開始】" + OrderCD);

                    taOrder.FillByCD(dtOrder, OrderCD);
                    if (dtOrder.Count > 0)
                    {
                        long orderID = dtOrder[0].order_id;
                        // -------------------------------------------------
                        //既存データの削除
                        // -------------------------------------------------
                        try
                        {
                            taQuery.S_DeleteRegiDetail(orderID);
                        }
                        catch (Exception e)
                        {
                            Program.ScLogger.Error($"{nameof(orderID)}={orderID},\"W_レジ伝票明細の削除でエラーが発生しました。\"");
                            Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                            Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                            return false;
                        }
                        try
                        {
                            taQuery.S_DeleteOrder2(orderID);
                        }
                        catch (Exception e)
                        {
                            Program.ScLogger.Error($"{nameof(orderID)}={orderID},\"受注データ再取込でエラーが発生しました。\"");
                            Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                            Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                            return false;
                        }
                    }

                    // -------------------------------------------------
                    // BカートからOrderを取得
                    // -------------------------------------------------
                    var orderResponse = OrdersApi.GetOrder(api, OrderCD.ToString());
                    if (orderResponse == null || orderResponse.orders == null || orderResponse.orders.Count == 0)
                    {
                        Program.ScLogger.Error($"Order取得エラー:" + OrderCD);
                        return false;
                    }

                    // キャンセルの場合は取り込まない
                    if (orderResponse.orders[0].status == "キャンセル")
                    {
                        CancelList.Add(OrderCD.ToString());
                    }
                    else
                    {

                        string customerCD = "";
                        foreach (var cu in orderResponse.orders[0].customer_customs)
                        {
                            if (cu.field_id == 3)
                            {
                                customerCD = cu.value;
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(customerCD))
                        {
                            throw new Exception("顧客コード取得エラー");
                        }

                        // Apiで取得したオーダーをDBに登録
                        try
                        {
                            orderResponse.orders[0].status = "ピック済";        // ステータスを置き換える
                            OrdersData.InsertOrder(orderResponse.orders[0], taOrder, customerCD);
                        }
                        catch (Exception e)
                        {
                            Program.ScLogger.Error($"{nameof(OrderCD)}={OrderCD},\"Order登録でエラーが発生しました。\"");
                            Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                            Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                            return false;
                        }

                        // -------------------------------------------------
                        // BカートからOrderProductsを取得
                        // -------------------------------------------------
                        int offset = 0;
                        List<long> logisticsIDList = new List<long>();
                        while (true)
                        {
                            var orderProductResponse = OrdersApi.GetNewOrderProducts(api, orderResponse.orders[0].id.ToString(), offset.ToString(), "100");

                            if (orderProductResponse == null)
                            {
                                Program.ScLogger.Error($"OrderProducts取得エラー:" + OrderCD);
                                return false;
                            }

                            if (orderProductResponse.order_products == null || orderProductResponse.order_products.Count == 0)
                            {
                                break;
                            }
                            offset += orderProductResponse.order_products.Count;

                            foreach (var order_product in orderProductResponse.order_products)
                            {
                                if (order_product.logistics_id != null && !logisticsIDList.Contains((long)order_product.logistics_id))
                                {
                                    logisticsIDList.Add((long)order_product.logistics_id);
                                }

                                try
                                {
                                    // 商品管理番号を空にする
                                    order_product.main_no = "";
                                    order_product.jan_code = "";
                                    OrdersData.InsertOrderProduct(order_product, taOrderProducts);

                                    if (!list.Contains(new sProductKey { productId = order_product.product_id, SetId = order_product.product_set_id }))
                                    {
                                        list.Add(new sProductKey() { productId = order_product.product_id, SetId = order_product.product_set_id });
                                    }
                                }
                                catch (Exception e)
                                {
                                    Program.ScLogger.Error($"{nameof(OrderCD)}={OrderCD},\"OrderProducts登録でエラーが発生しました。\"");
                                    Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                                    Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                                    return false;
                                }
                            }

                        }


                        // -------------------------------------------------
                        // Bカートから出荷を取り込む
                        // -------------------------------------------------
                        foreach (var logistics_id in logisticsIDList)
                        {
                            var retLogisticsResponse = OrdersApi.GetNewLogistics(api, logistics_id);
                            if (retLogisticsResponse == null || retLogisticsResponse.logistic == null)
                            {
                                Program.ScLogger.Error($"Logistics取得エラー:" + OrderCD);
                                return false;
                            }

                            try
                            {
                                OrdersData.InsertLogistics(retLogisticsResponse.logistic, taLogistics);
                            }
                            catch (Exception e)
                            {
                                Program.ScLogger.Error($"{nameof(OrderCD)}={OrderCD},\"Logistics登録でエラーが発生しました。\"");
                                Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                                Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                                return false;
                            }
                        }

                        // -------------------------------------------------
                        // ステータス作成
                        // -------------------------------------------------
                        try
                        {
                            taQuery.S_MakeOrderStatus(orderResponse.orders[0].id, 1);   // ピッキング済にする
                        }
                        catch (Exception e)
                        {
                            Program.ScLogger.Error($"{nameof(OrderCD)}={OrderCD},\"OrderStatus作成でエラーが発生しました。\"");
                            Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                            Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                            return false;
                        }

                        // -------------------------------------------------
                        // レジ伝票明細登録
                        // -------------------------------------------------
                        if (IsRegist)
                        {
                            try
                            {
                                //操作ログ記載
                                string machinname = Environment.MachineName;
                                using AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter bco = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter();
                                bco.Insert_bcOperationLog(DateTime.Now, machinname, "受注再取込レジ登録", "Order_Code:" + OrderCD);

                                taQuery.S_MakeRegiDetail(orderResponse.orders[0].id);

                            }
                            catch (Exception e)
                            {
                                Program.ScLogger.Error($"{nameof(OrderCD)}={OrderCD},\"W_レジ伝票明細登録でエラーが発生しました。\"");
                                Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                                Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("基幹連携機能解除中のためレジ伝票明細の登録をスキップします。");
                        }

                        // Bカート受注の顧客情報よりe飛伝用のcsvファイルに書き込み
                        if (!OrderCustomerAddress.WriteSagawaCsvFromOrder(orderResponse.orders[0].id))
                        {
                            //MessageBox.Show("佐川用住所を出力できませんでした。");
                        }

                    }


                    // -------------------------------------------------
                    // トランザクション終了（コミット）
                    // -------------------------------------------------
                    ts.Complete();

                    Program.ScLogger.Info($"【Order取込完了】:" + OrderCD);
                }

                // bc在庫更新対象商品登録
                for (int i = 0; i < list.Count; i++)
                {
                    // null判定
                    if (list[i].productId.HasValue)
                    {
                        try
                        {
                            Marge.MargeLibraryUpdates((long)list[i].productId, (int)list[i].SetId);
                        }
                        catch(Exception e)
                        {
                            Program.ScLogger.Error($"{nameof(OrderCD)}={OrderCD},\"bc在庫更新対象商品登録でエラーが発生しました。\"");
                            Program.ScLogger.Error($"e.Exception.Message={e.Message}");
                            Program.ScLogger.Error($"e.Exception.StackTrace={e.StackTrace}");
                            return false;
                        }
                    }
                }
                
            }

            return true;
        }
    }

}
