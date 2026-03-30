using Bcart受注管理.AppData;


namespace Bcart受注管理.Forms
{
    internal partial class frmOrderDetail : frmBase
    {

        private long OrderID { get; set; }
        private Consts.FormMode Mode { get; set; }

        public frmOrderDetail(long orderID, Consts.FormMode mode)
        {
            this.OrderID = orderID;
            this.Mode = mode;
            InitializeComponent();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(this.OrderID)}={this.OrderID}");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCart受注 明細";

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

                // 取得した支払い方法を変換　カスタム＝"yhカード"　カスタム2="您所配合的代工"
                // 受注画面への表示はストアドで行っています
                this.label33.Text = ViewBuilder.GetPaymentText(OrderDt[0].payment);

                Program.ScLogger.Info($"{nameof(OrderDt.customer_ext_idColumn)}={OrderDt[0].customer_ext_id}, {nameof(count)}={count}, {OrderDt.address_changedColumn}={OrderDt[0].address_changed}");
            }

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            this.DialogResult = DialogResult.OK;
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmOrderDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }
    }
}
