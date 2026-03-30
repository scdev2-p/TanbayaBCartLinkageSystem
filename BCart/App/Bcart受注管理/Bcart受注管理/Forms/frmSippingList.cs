using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.AppData.Sql;
using Microsoft.VisualBasic;
using static Bcart受注管理.Forms.ViewBuilder;

namespace Bcart受注管理.Forms
{
    internal partial class frmSippingList : frmBase
    {
        public frmSippingList()
        {
            InitializeComponent();
        }

        private void frmSipping_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCart出荷済登録";

            //this.lblPrinterDevice.Text = Settings.Default.PrinterDevice;


            // ステータスコンボの初期化
            ViewBuilder.BuildCmbStatus(cmbStatus);

            // 検索条件初期値
            ViewBuilder.BuildDateSpan(dtOrderFrom, dtOrderTo);

            this.cmbStatus.Items.Clear();
            for (int i = 0; i < Consts.OrderStatus.Count; i++)
            {
                this.cmbStatus.Items.Add(Consts.OrderStatus[i]);
            }
            this.cmbStatus.SelectedIndex = 2;

            // 検索実行
            doSearchSipping();
            this.txtOrderCode.Focus();

            Program.ScLogger.Info($"end");
        }

        private void frmSipping_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.ScLogger.Info($"start");
            if (e.KeyChar == ControlChars.Cr)
            {
                e.Handled = true;
            }
            Program.ScLogger.Info($"end");
        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.ScLogger.Info($"start");

            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnDetail")     // 詳細ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Order）
                dsBCartLink.S_SearchSippingRow dbRow = (dsBCartLink.S_SearchSippingRow)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                long id = dbRow.order_id;

                // 明細画面を開く
                frmSippingDetail fOrderDEtail = new frmSippingDetail(id);
                fOrderDEtail.WindowState = FormWindowState.Maximized;
                if (fOrderDEtail.ShowDialog() == DialogResult.OK)
                {
                    doSearchSipping();
                }

            }

            Program.ScLogger.Info($"end");
        }


        /// <summary>
        /// 検索実行
        /// </summary>
        private void doSearchSipping()
        {
            Program.ScLogger.Info($"start {nameof(cmbStatus)}={ViewBuilder.GetSearchStatusLabel(cmbStatus)}, {nameof(chkOrderDate)}={chkOrderDate.Checked}, {nameof(dtOrderFrom)}={dtOrderFrom.Value}, {nameof(dtOrderTo)}={dtOrderTo.Value}");

            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchSippingTableAdapter SippingTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchSippingTableAdapter())
            using (AppData.Ds.dsBCartLinkTableAdapters.DataCountTableAdapter CountTa = new AppData.Ds.dsBCartLinkTableAdapters.DataCountTableAdapter())
            using (dsBCartLink.S_SearchSippingDataTable dt = new dsBCartLink.S_SearchSippingDataTable())
            {
                // 受注の検索
                ViewBuilder.SetSearchTime(this.dtOrderFrom, this.dtOrderTo);
                SippingTa.FillBy(dt
                    , ViewBuilder.GetSearchStatusLabel(this.cmbStatus)
                    , this.chkOrderDate.Checked ? this.dtOrderFrom.Value : null
                    , this.chkOrderDate.Checked ? this.dtOrderTo.Value : null

                    );

                this.bsBcartLink.DataSource = dt;

                // 総数取得
                this.lblCount.Text = string.Format("{0:#,0}件", dt.Count);
                Program.ScLogger.Info($"{nameof(lblCount)}={lblCount.Text}");
            }
        }

        private void txtOrderCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(txtOrderCode)}={txtOrderCode.Text}");

            if (e.KeyChar == ControlChars.Cr)
            {
                e.Handled = true;

                if (string.IsNullOrEmpty(txtOrderCode.Text))
                    return;

                long id = -1;
                // 受注番号からBCart受注IDを取得
                using (sqlTnbBCart tnb = new sqlTnbBCart())
                {
                    id = tnb.GetOrderIdByCode(this.txtOrderCode.Text);
                    if (id < 0)
                    {
                        this.txtOrderCode.Text = "";
                        Interaction.Beep();     // VBのBeep
                        return;
                    }
                }

                // 明細画面を開く
                frmSippingDetail fOrderDEtail = new frmSippingDetail(id);
                fOrderDEtail.WindowState = FormWindowState.Maximized;
                if (fOrderDEtail.ShowDialog() == DialogResult.OK)
                {
                    // 検索実行
                    doSearchSipping();
                }
                // 受注番号のテキストを初期化
                this.txtOrderCode.Text = string.Empty;
                // 受注番号にフォーカス
                this.txtOrderCode.Focus();
            }

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.Close();
            Program.ScLogger.Info($"end");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            doSearchSipping();
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmSippingList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }
    }
}
