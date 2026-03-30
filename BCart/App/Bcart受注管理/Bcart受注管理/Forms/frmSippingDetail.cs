using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.Services;
using Bcart受注管理.Validators;

namespace Bcart受注管理.Forms
{
    public partial class frmSippingDetail : Form
    {
        /// <summary>
        /// BCart受注APIのサービス
        /// </summary>
        private readonly OrderService _orderService;

        /// <summary>
        /// BCart出荷APIのサービス
        /// </summary>
        private readonly LogisticService _logisticService;
        private long OrderID { get; set; }

        public frmSippingDetail(long orderID)
        {
            InitializeComponent();
            this.OrderID = orderID;

            _logisticService = Program.GetService<LogisticService>();
            _orderService = Program.GetService<OrderService>();
        }

        private void frmSippingDetail_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(this.OrderID)}={this.OrderID}");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCart出荷登録";

            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchOrderDetailTableAdapter OrderTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchOrderDetailTableAdapter())
            using (AppData.Ds.dsBCartLink.S_SearchOrderDetailDataTable OrderDt = new AppData.Ds.dsBCartLink.S_SearchOrderDetailDataTable())
            using (AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsTableAdapter OrderProductsTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsTableAdapter())
            using (AppData.Ds.dsBCartLink.bc_OrderProductsDataTable OrderProductsDt = new AppData.Ds.dsBCartLink.bc_OrderProductsDataTable())
            using (AppData.Ds.dsTnbTableAdapters.T_取置TableAdapter CountTa = new AppData.Ds.dsTnbTableAdapters.T_取置TableAdapter())
            using (AppData.Ds.dsTnb.T_取置DataTable CountDt = new AppData.Ds.dsTnb.T_取置DataTable())
            {
                OrderTa.Fill(OrderDt, this.OrderID);
                this.bcOrderBindingSource.DataSource = OrderDt;

                OrderProductsTa.FillByOrderID(OrderProductsDt, this.OrderID);
                this.bcOrderProductsBindingSource.DataSource = OrderProductsDt;


                // 取置があるか確認
                var count = (int)CountTa.ReserveCount(OrderDt[0].customer_ext_id);
                this.lblReserve.Text = count > 0 ? "【取置あり】" : "";

                // 住所変更があるか確認
                this.label30.Text = OrderDt[0].address_changed == 0 ? "" : "【住所変更あり】";

                Program.ScLogger.Info($"{nameof(OrderDt.customer_ext_idColumn)}={OrderDt[0].customer_ext_id}, {nameof(count)}={count}, {OrderDt.address_changedColumn}={OrderDt[0].address_changed}");
            }

            Program.ScLogger.Info($"end");
        }

        private void btnRegistSipping_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(this.OrderID)}={this.OrderID}, {nameof(this.txtSippingNo)}={this.txtSippingNo.Text}");

            // 入力チェック
            // 必須チェックするリストを作成
            List<KeyValuePair<string, string>> formValues = new List<KeyValuePair<string, string>>();

            // データを追加
            formValues.Add(new KeyValuePair<string, string>("送り状番号", this.txtSippingNo.Text));

            // 必須チェックは不要(20240610)
            //var validationResult = FormValidators.IsRequiredList(formValues);
            //if (validationResult.ShowError())
            //{
            //    Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
            //    return;
            //}

            //// 整数チェック
            //var res = FormValidators.IsIntager("送り状番号", this.txtSippingNo.Text);
            //if (res.ShowError())
            //{
            //    Program.ScLogger.Info($"end 送り状番号整数エラー");
            //    return;
            //}

            //// 桁数チェック
            //res = FormValidators.CheckMaxLength("送り状番号", this.txtSippingNo.Text, 255);
            //if (res.ShowError())
            //{
            //    Program.ScLogger.Info($"end 送り状番号桁数エラー");
            //    return;
            //}

            //if (MessageBox.Show("BCartに反映します。\nよろしいですか？", "BCart出荷登録", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //{
            //    Program.ScLogger.Info($"end キャンセルクリック");
            //    return;
            //}

            // 操作ログ記載
            string machinname = Environment.MachineName;
            using AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter bco = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter();
            bco.Insert_bcOperationLog(DateTime.Now, machinname, "出荷登録", "Order_Code:" + this.LblOrderCode.Text);

            // ①対応状況＝出荷完了（bc_order.status="出荷完了"）
            using AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter orderTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter();
            using AppData.Ds.dsBCartLink.bc_OrderDataTable orderDt = new AppData.Ds.dsBCartLink.bc_OrderDataTable();
            orderTa.FillByOrderID(orderDt, this.OrderID);
            Program.ScLogger.Info($"before {nameof(orderDt.statusColumn)}={orderDt[0].status}");
            orderDt[0].status = Consts.OrderStatus[(int)Consts.OrderStatusIndex.ShippingCompleted];
            Program.ScLogger.Info($"after {nameof(orderDt.statusColumn)}={orderDt[0].status}");
            orderTa.Update(orderDt);

            // ②発送状況＝発送完了（bc_Logistics.status="発送完了"）
            // ③発送日＝入力された値(bc_Logistics.shipment_date=入力された値）
            // ④送り状番号＝入力された値(bc_Logistics.shipment_code=入力された値）
            DataGridViewRow row = this.dgvDetailList.Rows[0];
            var dbRow = (dsBCartLink.bc_OrderProductsRow)((System.Data.DataRowView)row.DataBoundItem).Row;
            using AppData.Ds.dsBCartLinkTableAdapters.bc_LogisticsTableAdapter logisticsTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_LogisticsTableAdapter();
            using AppData.Ds.dsBCartLink.bc_LogisticsDataTable logisticsDt = new AppData.Ds.dsBCartLink.bc_LogisticsDataTable();
            logisticsTa.FillBy(logisticsDt, dbRow.logistics_id);
            if (logisticsDt.Count > 0)
            {
                try
                {
                    Program.ScLogger.Info($"before {nameof(logisticsDt.statusColumn)}={logisticsDt[0].status}, {nameof(logisticsDt.shipment_dateColumn)}={logisticsDt[0].shipment_date}, {nameof(logisticsDt.shipment_codeColumn)}={logisticsDt[0].shipment_code}");
                }
                catch(System.Data.StrongTypingException)
                {
                    Program.ScLogger.Info($"before {nameof(logisticsDt.statusColumn)}={logisticsDt[0].status}, {nameof(logisticsDt.shipment_dateColumn)}=null, {nameof(logisticsDt.shipment_codeColumn)}={logisticsDt[0].shipment_code}");
                }
                
                logisticsDt[0].status = "発送完了";
                logisticsDt[0].shipment_date = dtSippingDate.Value;
                logisticsDt[0].shipment_code = this.txtSippingNo.Text;
                Program.ScLogger.Info($"after {nameof(logisticsDt.statusColumn)}={logisticsDt[0].status}, {nameof(logisticsDt.shipment_dateColumn)}={logisticsDt[0].shipment_date}, {nameof(logisticsDt.shipment_codeColumn)}={logisticsDt[0].shipment_code}");
                logisticsTa.Update(logisticsDt);

                // 出荷登録
                var result = Task.Run(async () =>
                {
                    // 出荷情報取得
                    var logistic = await _logisticService.GetLogistic(dbRow.logistics_id);
                    if (logistic != null)
                    {
                        logistic.DeliveryCode = this.txtSippingNo.Text;
                        logistic.ShipmentDate = dtSippingDate.Value;
                        logistic.Status = "発送済";
                        await _logisticService.UpdateLogistic(logistic);
                    }
                    // 出荷情報取得
                    var order = await _orderService.GetOrder(this.OrderID);
                    if (order != null)
                    {
                        order.Status = "完了";
                        await _orderService.UpdateOrder(order);
                    }
                });
                result.Wait();
            }
            // 
            MessageBox.Show("出荷済みにしました。", "出荷登録");

            // 画面を閉じる
            DialogResult = DialogResult.OK;

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            DialogResult = DialogResult.Cancel;
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmSippingDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }
    }
}
