using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.AppData.Sql;
using BCartApi;
using Bcart受注管理.Services;
using Bcart受注管理.Models;
using Microsoft.VisualBasic;
using Bcart受注管理.Validators;
using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using static Bcart受注管理.Forms.ViewBuilder;
using static Bcart受注管理.Forms.frmMenu;
using System.Runtime.CompilerServices;

namespace Bcart受注管理.Forms
{
    internal partial class frmReloadOrder : frmBase
    {
        /// <summary>
        /// BCart受注APIのサービス
        /// </summary>
        private readonly OrderService _orderService;
        /// <summary>
        /// BCart受注商品APIのサービス
        /// </summary>
        private readonly OrderProductService _orderProductService;

        /// <summary>
        /// 親フォームに次画面を知らせるためのデリゲート
        /// </summary>
        private event NextShowDialogDelegate SetNextShowDialogEvent;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmReloadOrder(NextShowDialogDelegate setNextShowDialogEvent)
        {
            InitializeComponent();

            _orderService = Program.GetService<OrderService>();
            _orderProductService = Program.GetService<OrderProductService>();

            // 全てのキー入力をFormが受け取る
            this.KeyPreview = true;

            this.SetNextShowDialogEvent = setNextShowDialogEvent;

        }

        private void frmReloadOrder_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCart受注再取込";


            // 検索条件初期値


            // 検索実行
            doSearchOrders();

            Program.ScLogger.Info($"end");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(Settings.Default.RegistTnb)}={Settings.Default.RegistTnb}");

            // ここでチェックされたデータを取得
            var OrderIDList = new List<long>();
            var OrderCDList = new List<long>();
            foreach (DataGridViewRow row in this.dgvMainList.Rows)
            {
                if (ViewBuilder.GetCheckedFromDataGridViewRow(row, 0))
                {
                    // クリックされた行にバインドされているRowデータを取得（Picking）
                    dsBCartLink2.S_SearchReloadOrderRow dbRow = (dsBCartLink2.S_SearchReloadOrderRow)((System.Data.DataRowView)row.DataBoundItem).Row;

                    // 機能追加（TANBAYA-334 20240712）
                    // この受注のレジ伝票明細がすでに存在するかチェック
                    using var checkRegistedRegOrderTa = new AppData.Ds.dsBCartLinkTableAdapters.S_CheckRegistedRegOrderTableAdapter();
                    using var checkRegistedRegOrderDt = new dsBCartLink.S_CheckRegistedRegOrderDataTable();
                    checkRegistedRegOrderTa.Fill(checkRegistedRegOrderDt, dbRow.order_id);

                    if (checkRegistedRegOrderDt.Any())
                    {
                        if (MessageBox.Show($"{checkRegistedRegOrderDt[0].カード番号} {checkRegistedRegOrderDt[0].顧客名} {checkRegistedRegOrderDt[0].伝票年月日}は既にレジに事前登録した受注があります。\n実行してもよろしいですか？", "ピッキング作業 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        {
                            Program.ScLogger.Info($"end レジ伝票明細登録あり キャンセルクリック");
                            return;
                        }
                    }
                    OrderIDList.Add(dbRow.order_id);
                    OrderCDList.Add(dbRow.order_code);
                    Program.ScLogger.Info($"{nameof(dbRow.order_id)}={dbRow.order_id}, {nameof(dbRow.order_code)}={dbRow.order_code}");
                }
            }
            // チェックされたﾃﾞｰﾀが存在しない場合
            if (OrderIDList.Count == 0)
            {
                MessageBox.Show("受注が選択されていません");
                Program.ScLogger.Info($"受注が選択されていません");
                return;
            }

            if (MessageBox.Show("選択された受注をBカートから再取込します。\nよろしいですか？", "BCart受注取込", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                Program.ScLogger.Info($"{nameof(MessageBoxButtons.OKCancel)}={MessageBoxButtons.OKCancel}");
                return;
            }

            // takagi@sc 修正 2024/08/22
            //ExecReloadOrders(OrderIDList);
            ExecReloadOrder(OrderCDList, Settings.Default.RegistTnb);

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// 受注再取得を実行します
        /// </summary>
        /// <param name="OrderIDList">受注IDのリスト</param>
        private void ExecReloadOrders(List<long> OrderIDList)
        {
            Program.ScLogger.Info($"{nameof(OrderIDList)}={string.Join(",", OrderIDList)}");

            using (BCartApi.HttpApiCommon api = new HttpApiCommon())
            using (sqlTnbBCart sqlBc = new sqlTnbBCart())
            using (AppData.Ds.dsTnb.M_顧客DataTable dt = new dsTnb.M_顧客DataTable())
            using (AppData.Ds.dsTnbTableAdapters.M_顧客TableAdapter ta = new AppData.Ds.dsTnbTableAdapters.M_顧客TableAdapter())
            {
                // キャンセルリスト
                var cancelIdList = new List<string>();

                foreach (long orderID in OrderIDList)
                {
                    // この受注がキャンセルかどうか true:キャンセル
                    var cancelFlg = false;

                    // 受注伝票明細の削除
                    if (!sqlBc.DeleteRegiDetail(orderID))
                    {
                        MessageBox.Show("W_レジ伝票明細の削除でエラーが発生しました。");
                        Program.ScLogger.Info($"{nameof(orderID)}={orderID},\"W_レジ伝票明細の削除でエラーが発生しました。\"");
                        return;
                    }

                    // 受注データの削除
                    if (!sqlBc.DeleteOrder(orderID))
                    {
                        MessageBox.Show("受注データ再取込でエラーが発生しました。");
                        Program.ScLogger.Info($"{nameof(orderID)}={orderID},\"受注データ再取込でエラーが発生しました。\"");
                        return;
                    }

                    var result = Task.Run(async () =>
                    {
                        // BCartから受注を取り込む
                        var order = await _orderService.GetOrder(orderID);

                        Program.ScLogger.Info($"{nameof(orderID)}={orderID},{nameof(order.Status)} = {order.Status}");

                        var orderCode = (order.Code != null) ? order.Code : "受注番号を取得できませんでした";
                        // 取り込んだ受注のステータスがキャンセルならばスキップして次の受注に進む

                        if (order.Status == "キャンセル")
                        {
                            // キャンセルなのでフラグをtrueにする
                            cancelFlg = true;
                            // この受注をキャンセル
                            cancelIdList.Add(orderCode);
                            return;
                        }

                        ta.FillBy(dt, order.CustomerExtId);

                        // DBにOrderを登録
                        using (AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter OrderTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter())
                        {
                            OrderTa.Insert(
                                (long)order.Id,
                                long.Parse(order.Code),
                                (long)order.CustomerId,
                                order.CustomerExtId,
                                order.CustomerParentId,
                                order.CustomerSalesmanId,
                                order.CustomerCompName,
                                order.CustomerDepartment,
                                order.CustomerName,
                                order.CustomerTel,
                                order.CustomerMobilePhone,
                                order.CustomerEmail,
                                order.CustomerPriceGroupId,
                                order.CustomerZip,
                                order.CustomerPref,
                                order.CustomerAddress1,
                                order.CustomerAddress2,
                                order.CustomerAddress3,
                                GetVaueFromCustomerCustoms(order.CustomerCustoms, 0),
                                GetVaueFromCustomerCustoms(order.CustomerCustoms, 1),
                                dt[0].顧客コード,
                                order.Payment,
                                order.PaymentAt,
                                order.TotalPrice,
                                order.Tax,
                                decimal.Parse(order?.TaxRate ?? "0"),
                                order.CODCost,
                                order.ShippingCost,
                                order.FinalPrice,
                                order.UsePoint,
                                order.GetPoint,
                                GetTotalInclTaxFromOrderTotals(order.OrderTotals, 0),
                                GetTotalInclTaxFromOrderTotals(order.OrderTotals, 1),
                                GetTotalInclTaxFromOrderTotals(order.OrderTotals, 2),
                                order.CustomerMessage,
                                order.AdminMessage,
                                order.Memo,
                                GetVaueFromCustomerCustoms(order.Customs, 0),
                                GetVaueFromCustomerCustoms(order.Customs, 1),
                                GetVaueFromCustomerCustoms(order.Customs, 2),
                                order.Enquete1,
                                order.Enquete2,
                                order.Enquete3,
                                order.Enquete4,
                                order.Enquete5,
                                order.OrderedAt,
                                order.AffiliateId,
                                string.IsNullOrWhiteSpace(order.EstimateId) ? null : long.Parse(order.EstimateId),
                                "ピック済"
                                );
                        }

                        long offset = 0;

                        while (true)
                        {
                            // BCartから受注商品を取り込む
                            var orderProducts = await _orderProductService.GetOrderProductsByOrderId(orderID, offset);

                            if (orderProducts == null || orderProducts.Count == 0)
                            {
                                // 戻りが無ければ中断（明細が空でもエラーにしない）
                                Log.Write($"明細取得api終了");
                                break;
                            }

                            // DBにOrderProductsを登録
                            using AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsEditTableAdapter OrderProductsTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsEditTableAdapter();
                            foreach (var orderProduct in orderProducts)
                            {
                                OrderProductsTa.Insert(
                                        orderProduct.Id,
                                        orderProduct.OrderId,
                                        orderProduct.LogisticsId,
                                        orderProduct.ProductId,
                                        orderProduct.MainNo,
                                        orderProduct.ProductNo,
                                        orderProduct.JanCode,
                                        orderProduct.LocationNo,
                                        orderProduct.ProductName,
                                        orderProduct.ProductSetId,
                                        orderProduct.SetName,
                                        decimal.Parse(orderProduct.UnitPrice.ToString()),
                                        orderProduct.SetQuantity.ToString(),
                                        orderProduct.SetUnit,
                                        orderProduct.OrderProCount,
                                        (long)orderProduct.ShippingSize,
                                        decimal.Parse(orderProduct.TaxRate),
                                        (byte)orderProduct.TaxTypeId,
                                        (byte)orderProduct.TaxIncl,
                                        orderProduct.ItemType,
                                        // GetVaueFromCustomerCustoms(orderProduct.ProductCustoms, 0),
                                        // GetVaueFromCustomerCustoms(orderProduct.ProductCustoms, 1),
                                        null,
                                        null,
                                        null,
                                        GetVaueFromCustomerCustoms(orderProduct.ProductSetCustoms, 0),
                                        GetVaueFromCustomerCustoms(orderProduct.ProductSetCustoms, 1),
                                        GetVaueFromCustomerCustoms(orderProduct.ProductSetCustoms, 2),
                                        GetVaueFromCustomerCustoms(orderProduct.Options, 0),
                                        GetVaueFromCustomerCustoms(orderProduct.Options, 1),
                                        GetVaueFromCustomerCustoms(orderProduct.Options, 2));
                            }
                            offset += Settings.Default.Limit;
                        }
                    });
                    result.Wait();

                    // ------------------------------------------------------------------
                    // DBにステータスを作成（ピッキング済）
                    // ストアドプロシージャ S_MakeOrderStatus orderID, 1

                    // キャンセルでなければ実行
                    if (cancelFlg == false)
                    {
                        if (!sqlBc.MakeOrderStatus(orderID, 1))
                        {
                            MessageBox.Show("受注ステータスの変更でエラーが発生しました。");
                            Program.ScLogger.Info($"{nameof(orderID)}={orderID},\"受注ステータスの変更でエラーが発生しました。\"");
                            return;
                        }

                        // 基幹のレジに登録してしまうので本番環境で実行する時はスキップさせる
                        if (Settings.Default.RegistTnb)
                        {
                            // 基幹のw_レジ伝票明細の登録
                            // ストアドプロシージャ S_MakeRegiDetail orderID
                            if (!sqlBc.MakeRegiDetail(orderID))
                            {
                                MessageBox.Show("基幹のw_レジ伝票明細の登録でエラーが発生しました。");
                                Program.ScLogger.Info($"{nameof(orderID)}={orderID},\"基幹のw_レジ伝票明細の登録でエラーが発生しました。\"");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("基幹連携機能解除中のためレジ伝票明細の登録をスキップします。");
                        }
                    }
                }

                string msg = "";
                foreach (string cancelId in cancelIdList)
                {
                    msg += "\n" + cancelId;
                }

                MessageBox.Show($"再登録が完了しました" + $"\nキャンセルは{cancelIdList.Count()}件です" + msg);
            }

            // 一覧の再検索
            // 検索実行
            doSearchOrders();
        }

        /// <summary>
        /// カスタム値のリストからvalueを取得します
        /// </summary>
        /// <param name="customs">カスタム値のリスト</param>
        /// <param name="index">取得するインデックス</param>
        /// <returns>value値</returns>
        private static string GetVaueFromCustomerCustoms(List<CustomerCustom>? customs, int index)
        {
            var value = customs?.Count >= index + 1 ? customs[index].Value ?? string.Empty : string.Empty;
            Program.ScLogger.Info($"{nameof(index)}={index}, {nameof(value)}={value}");
            return value;
        }

        /// <summary>
        /// 受注合計額のリストから税込み価格を取得します
        /// </summary>
        /// <param name="orderTotals">受注合計額のリスト</param>
        /// <param name="index">取得するインデックス</param>
        /// <returns>税込み価格</returns>
        private static decimal GetTotalInclTaxFromOrderTotals(List<OrderTotal>? orderTotals, int index)
        {
            var value = orderTotals?.Count >= index + 1 ? orderTotals[index].TotalInclTax ?? 0 : 0;
            Program.ScLogger.Info($"{nameof(index)}={index}, {nameof(value)}={value}");
            return value;
        }

        private void doSearchOrders()
        {
            Program.ScLogger.Info($"start");
            using (AppData.Ds.dsBCartLink2TableAdapters.S_SearchReloadOrderTableAdapter OrderTa = new AppData.Ds.dsBCartLink2TableAdapters.S_SearchReloadOrderTableAdapter())
            using (dsBCartLink2.S_SearchReloadOrderDataTable dt = new dsBCartLink2.S_SearchReloadOrderDataTable())
            {
                // 受注の検索
                OrderTa.Fill(dt,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null);
                this.bsOrderList.DataSource = dt;
                Program.ScLogger.Info($"{nameof(dt.Count)}={dt.Count}");
            }
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmReloadOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }

        /// <summary>
        /// 入力された受注番号で受注再取得を実行します
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnReloadByOrderCode_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(this.textOrderCode)}={this.textOrderCode.Text}");

            // 入力値チェック 
            // 必須チェックするリストを作成
            List<KeyValuePair<string, string>> formValues = new List<KeyValuePair<string, string>>();

            // データを追加
            formValues.Add(new KeyValuePair<string, string>("受注番号", this.textOrderCode.Text));

            // 必須チェック
            var validationResult = FormValidators.IsRequiredList(formValues);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            // 桁数チェック
            validationResult = FormValidators.CheckMaxLength("受注番号", this.textOrderCode.Text, 11);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            // 整数チェック
            validationResult = FormValidators.IsIntager("受注番号", this.textOrderCode.Text);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            var OrderIDList = new List<long>();
            var OrderCDList = new List<long>();
            using (AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter OrderTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter())
            {
                // 入力された受注番号からorderIdを取得
                var orderId = OrderTa.GetOrderId(long.Parse(this.textOrderCode.Text));

                if (orderId == null)
                {

                    MessageBox.Show("入力された受注番号が見つかりませんでした");
                    Program.ScLogger.Info($"\"入力された受注番号が見つかりませんでした\"");
                    return;
                }
                // 機能追加（TANBAYA-334 20240712）
                // orderIdでレジ伝票明細データを取得
                using var checkRegistedRegOrderTa = new AppData.Ds.dsBCartLinkTableAdapters.S_CheckRegistedRegOrderTableAdapter();
                using var checkRegistedRegOrderDt = new dsBCartLink.S_CheckRegistedRegOrderDataTable();
                checkRegistedRegOrderTa.Fill(checkRegistedRegOrderDt, Convert.ToInt64(orderId));

                // 明細を取得した場合はその趣旨をメッセージで表示。
                if (checkRegistedRegOrderDt.Any())
                {
                    if (MessageBox.Show($"{checkRegistedRegOrderDt[0].カード番号} {checkRegistedRegOrderDt[0].顧客名} {checkRegistedRegOrderDt[0].伝票年月日}は既にレジに事前登録した受注があります。\n実行してもよろしいですか？", "ピッキング作業 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        Program.ScLogger.Info($"end レジ伝票明細登録あり キャンセルクリック");
                        return;
                    }
                }
                OrderIDList.Add((long)orderId);
                OrderCDList.Add(long.Parse(this.textOrderCode.Text));
            }

            if (MessageBox.Show("指定された受注をBカートから再取込します。\nよろしいですか？", "BCart受注取込", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                Program.ScLogger.Info($"{nameof(MessageBoxButtons.OKCancel)}={MessageBoxButtons.OKCancel}");
                return;
            }


            // takagi@sc 修正 2024/08/22
            // 取得したorderIDで再登録を実行
            //ExecReloadOrders(OrderIDList);
            ExecReloadOrder(OrderCDList, Settings.Default.RegistTnb);

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// ピッキング作業画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnPicking_Click(object sender, EventArgs e)
        {
            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.PickingWork);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.OderList);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.Close();
            Program.ScLogger.Info($"end");
        }


        /// <summary>
        /// 受注再取込
        /// takagi@sc 2024/08/22
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="isPicked"></param>
        private void ExecReloadOrder(List<long> OrderCDList, bool isPicked)
        {
            Reload or = new Reload();

            foreach (var orderCD in OrderCDList)
            {
                //操作ログ記載
                string machinname = Environment.MachineName;
                using AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter bco = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter();
                bco.Insert_bcOperationLog(DateTime.Now, machinname,"受注再取り込み", "Order_Code:"+ orderCD);


                if (!or.RelooadByCD(orderCD, isPicked))
                {
                    MessageBox.Show("受注再取込はエラーで終了しました。");
                    return;
                }
            }

            string msg = "";
            foreach (string cancelId in or.CancelList)
            {
                msg += "\n" + cancelId;
            }
            MessageBox.Show($"再登録が完了しました" + $"\nキャンセルは{or.CancelList.Count}件です" + msg);
        }

        /// <summary>
        /// 取置一覧画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnReserved_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.Reserved);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }
    }
}
