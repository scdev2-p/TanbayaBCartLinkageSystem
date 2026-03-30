using BCartApi;
using BCartApi.Entity;
using BCartLinkBatch.AppData;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Transactions;


namespace BCartLinkBatch
{
    /// <summary>
    /// BCart連携バッチ
    /// </summary>
    internal class BCartLinkBatch
    {

        private const int SetLinmit = 100;

        /// <summary>
        /// BCartの情報をApiで取得してDBに登録します
        /// エラー検知しても処理を最後のオーダーまで実行します
        /// </summary>
        /// <returns>エラーを取得した場合はtrueを返します</returns>
        internal static bool BCartLink()
        {
            var isError = false;
            using (HttpApiCommon com = new HttpApiCommon())
            {
                // DBに接続
                var ta = new AppData.dsTnbToBcartTableAdapters.bc_OrderTableAdapter();
                var ta2 = new AppData.dsTnbToBcartTableAdapters.bc_OrderProductsTableAdapter();
                var ta3 = new AppData.dsTnbToBcartTableAdapters.bc_LogisticsTableAdapter();

                var dt = new dsTnbToBcart.bc_OrderDataTable();
                var dt2 = new dsTnbToBcart.bc_OrderProductsDataTable();

                var ret = OrdersApi.GetNewOrders(com);

                if (ret == null)
                {
                    return true;
                }
                else if (ret.orders == null)
                {
                    Log.Write($"{nameof(ret.orders)}がnullです");
                    return false;
                }

                // DBにインサート
                foreach (var order in ret.orders)
                {
                    Log.Write($"データベースに新規注文情報を挿入します");

                    Log.Write($"{JsonSerializer.Serialize(order)}");

                    bool isBreak = false;

                    // トランザクション処理開始
                    using (TransactionScope ts = new TransactionScope())
                    {
                        try
                        {
                            try
                            {
                                // Apiで取得したオーダーをDBに登録
                                OrdersData.InsertOrder(order, ta);
                            }
                            catch (Exception ex)
                            {
                                isError = true;
                                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                Log.Write("新規注文情報の挿入に失敗しました。次の新規注文情報の処理に進みます。");
                                continue;
                            }

                            // 受注の明細（商品毎）を取得
                            long offset = 0;
                            List<long> logisticsIDList = new List<long>();
                            while (true)
                            {

                                var ret2 = OrdersApi.GetNewOrderProducts(com, order.id.ToString(), offset.ToString(), SetLinmit.ToString());
                                if (ret2 == null || ret2.order_products == null || ret2.order_products.Count == 0)
                                {
                                    // 戻りが無ければ中断（明細が空でもエラーにしない）
                                    Log.Write($"明細取得api終了");
                                    break;
                                }
                                offset += ret2.order_products.Count;

                                Log.Write($"データベースに受注の明細（商品毎）を挿入します");


                                // 出荷IDは全てに同じものがセットされているが、念のため複数に対応する
                                // DBにインサート
                                foreach (var order_product in ret2.order_products)
                                {
                                    Log.Write($"{JsonSerializer.Serialize(order_product)}");

                                    if (order_product.logistics_id != null && !logisticsIDList.Contains((long)order_product.logistics_id))
                                    {
                                        logisticsIDList.Add((long)order_product.logistics_id);
                                    }

                                    try
                                    {
                                        OrdersData.InsertOrderProduct(order_product, ta2);
                                    }
                                    catch (Exception ex)
                                    {
                                        isError = true;
                                        isBreak = true;
                                        Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                        //Log.Write("受注の明細（商品毎）の挿入に失敗しました。次の受注の明細（商品毎）の処理に進みます。");
                                        Log.Write("受注の明細（商品毎）の挿入に失敗しました。次の受注の処理に進みます。");
                                        break;
                                    }


                                    // この機能は使うとApi使用数の上限を超える可能性があり不可
                                    //// ピッキング用商品画像の取得
                                    //long productID = (long)order_product.product_id;
                                    //var productInfo = OrdersApi.GetProduct(com, productID.ToString());
                                    //if( productInfo != null && productInfo.product != null)
                                    //{
                                    //    saveProductImage(productInfo.product.image, order_product.product_set_customs[0].ToString().Trim());
                                    //}

                                }
                                if (isBreak)
                                {
                                    continue;
                                }
                            }

                            // 出荷を取得
                            foreach (var logistics_id in logisticsIDList)
                            {
                                var ret3 = OrdersApi.GetNewLogistics(com, logistics_id);
                                if(ret3 == null || ret3.logistic == null)
                                {
                                    isError = true;
                                    Log.Write("出荷の取得に失敗しました。次の新規注文情報の処理に進みます。");
                                    break; ;
                                }

                                try
                                {
                                    OrdersData.InsertLogistics(ret3.logistic, ta3);
                                }
                                catch (Exception ex)
                                {
                                    isError = true;
                                    isBreak = true;
                                    Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                    Log.Write("出荷の挿入に失敗しました。次の受注の明細（商品毎）の処理に進みます。");
                                    break;
                                }
                            }
                            if (isBreak)
                            {
                                continue;
                            }

                            // 受注ステータスの作成
                            try
                            {
                                OrdersData.MakeOrderStatus(order.id);
                            }
                            catch (Exception ex)
                            {
                                isError = true;
                                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                Log.Write("受注ステータス作成に失敗しました。次の新規注文情報の登録処理に進みます。");
                                continue;
                            }

                             // 受注のステータスを変更
                            cOrderStatus stReq = new cOrderStatus();
                            stReq.status = "カスタム1";

                            Log.Write($"変更後受注情報:{JsonSerializer.Serialize(stReq)}");

                            var ret4 = OrdersApi.UpdateOrder(com, order.id.ToString(), stReq);
                            if (ret4 == null || ret4.order == null)
                            {
                                isError = true;
                                Log.ErrWrite("受注ステータス変更エラー");
                                Log.Write("受注ステータス変更エラー。次の新規注文情報の登録処理に進みます。");
                                continue;
                            }

                        }
                        catch(Exception ex)
                        {
                            isError = true;
                            Log.ErrWrite("受注取込エラー");
                            Log.Write("受注取込でエラーが発生しました。次の新規注文情報の登録処理に進みます。");
                            continue;
                        }

                        // トランザクション処理終了
                        ts.Complete();
                    }
                }
            }
            return isError;
        
        }

        /// <summary>
        /// 商品画像の保存（ピッキングリスト用）
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="barcode"></param>
        internal static void saveProductImage(string imageUrl, string barcode)
        {

            // 画像保存用フォルダ
            string outputFolder = Settings.Default.ProductImagePath;

            // バーコードからファイル名を作成
            string outPath = Path.Combine(outputFolder, barcode + "." + Path.GetExtension(imageUrl));

            // ファイルがあればスキップ
            if ( File.Exists(outPath))
            {
                return;
            }

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                // 画像をダウンロードして保存する。
                // 失敗してもピッキングリストに出ないだけ。
                try
                {
                    wc.DownloadFile(imageUrl, outPath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"画像のダウンロードに失敗しました: {imageUrl}\n{ex.Message}");
                }
            }

        }


        /// <summary>
        /// デバック用受注取込
        /// Bカートのステータスは変更しない
        /// </summary>
        /// <param name="bcOrderID"></param>
        /// <returns></returns>
        internal static bool debugGetOrder(string orderCD)
        {
            var isError = false;
            using (HttpApiCommon com = new HttpApiCommon())
            {
                // DBに接続
                var ta = new AppData.dsTnbToBcartTableAdapters.bc_OrderTableAdapter();
                var ta2 = new AppData.dsTnbToBcartTableAdapters.bc_OrderProductsTableAdapter();
                var ta3 = new AppData.dsTnbToBcartTableAdapters.bc_LogisticsTableAdapter();

                var dt = new dsTnbToBcart.bc_OrderDataTable();
                var dt2 = new dsTnbToBcart.bc_OrderProductsDataTable();

                var ret = OrdersApi.debugGetNewOrder(com, orderCD);

                if (ret == null)
                {
                    return true;
                }
                else if (ret.orders == null)
                {
                    Log.Write($"{nameof(ret.orders)}がnullです");
                    return false;
                }

                // DBにインサート
                foreach (var order in ret.orders)
                {
                    Log.Write($"データベースに新規注文情報を挿入します");

                    Log.Write($"{JsonSerializer.Serialize(order)}");

                    bool isBreak = false;

                    // トランザクション処理開始
                    using (TransactionScope ts = new TransactionScope())
                    {
                        try
                        {
                            try
                            {
                                // Apiで取得したオーダーをDBに登録
                                OrdersData.InsertOrder(order, ta);
                            }
                            catch (Exception ex)
                            {
                                isError = true;
                                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                Log.Write("新規注文情報の挿入に失敗しました。次の新規注文情報の処理に進みます。");
                                continue;
                            }

                            // 受注の明細（商品毎）を取得
                            long offset = 0;
                            List<long> logisticsIDList = new List<long>();
                            while (true)
                            {

                                var ret2 = OrdersApi.GetNewOrderProducts(com, order.id.ToString(), offset.ToString(), SetLinmit.ToString());
                                if (ret2 == null || ret2.order_products == null || ret2.order_products.Count == 0)
                                {
                                    // 戻りが無ければ中断（明細が空でもエラーにしない）
                                    Log.Write($"明細取得api終了");
                                    break;
                                }
                                offset += ret2.order_products.Count;

                                Log.Write($"データベースに受注の明細（商品毎）を挿入します");


                                // 出荷IDは全てに同じものがセットされているが、念のため複数に対応する
                                // DBにインサート
                                foreach (var order_product in ret2.order_products)
                                {
                                    Log.Write($"{JsonSerializer.Serialize(order_product)}");

                                    if (order_product.logistics_id != null && !logisticsIDList.Contains((long)order_product.logistics_id))
                                    {
                                        logisticsIDList.Add((long)order_product.logistics_id);
                                    }

                                    try
                                    {
                                        OrdersData.InsertOrderProduct(order_product, ta2);
                                    }
                                    catch (Exception ex)
                                    {
                                        isError = true;
                                        isBreak = true;
                                        Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                        //Log.Write("受注の明細（商品毎）の挿入に失敗しました。次の受注の明細（商品毎）の処理に進みます。");
                                        Log.Write("受注の明細（商品毎）の挿入に失敗しました。次の受注の処理に進みます。");
                                        break;
                                    }
                                }
                                if (isBreak)
                                {
                                    continue;
                                }
                            }

                            // 出荷を取得
                            foreach (var logistics_id in logisticsIDList)
                            {
                                var ret3 = OrdersApi.GetNewLogistics(com, logistics_id);
                                if (ret3 == null || ret3.logistic == null)
                                {
                                    isError = true;
                                    Log.Write("出荷の取得に失敗しました。次の新規注文情報の処理に進みます。");
                                    break; ;
                                }

                                try
                                {
                                    OrdersData.InsertLogistics(ret3.logistic, ta3);
                                }
                                catch (Exception ex)
                                {
                                    isError = true;
                                    isBreak = true;
                                    Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                    Log.Write("出荷の挿入に失敗しました。次の受注の明細（商品毎）の処理に進みます。");
                                    break;
                                }
                            }
                            if (isBreak)
                            {
                                continue;
                            }

                            // 受注ステータスの作成
                            try
                            {
                                OrdersData.MakeOrderStatus(order.id);
                            }
                            catch (Exception ex)
                            {
                                isError = true;
                                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                                Log.Write("受注ステータス作成に失敗しました。次の新規注文情報の登録処理に進みます。");
                                continue;
                            }


                        }
                        catch (Exception ex)
                        {
                            isError = true;
                            Log.ErrWrite("受注取込エラー");
                            Log.Write("受注取込でエラーが発生しました。次の新規注文情報の登録処理に進みます。");
                            continue;
                        }

                        // トランザクション処理終了
                        ts.Complete();
                    }
                }
            }
            return isError;
        }




    }
}
