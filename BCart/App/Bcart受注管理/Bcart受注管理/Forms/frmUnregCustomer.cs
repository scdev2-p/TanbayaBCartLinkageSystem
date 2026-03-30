using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Microsoft.VisualBasic;

namespace Bcart受注管理.Forms
{
    internal partial class frmUnregCustomer : frmBase
    {
        public frmUnregCustomer()
        {
            InitializeComponent();
        }

        private void frmUnregCustomer_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCart未登録顧客";


            // 検索条件初期値

            // 検索実行
            doSearchUnregCustomer();

            Program.ScLogger.Info($"end");
        }

        private void frmUnregCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.ScLogger.Info($"start");
            if (e.KeyChar == ControlChars.Cr)
            {
                e.Handled = true;
            }
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// 検索実行
        /// </summary>
        private void doSearchUnregCustomer()
        {
            Program.ScLogger.Info($"start {nameof(txtCustomerCode)}={txtCustomerCode.Text}, {nameof(txtCustomerName)}={txtCustomerName.Text}");

            using (AppData.Sql.sqlTnbBCart tnb = new AppData.Sql.sqlTnbBCart())
            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchUnregCustomerTableAdapter ucTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchUnregCustomerTableAdapter())
            using (dsBCartLink.S_SearchUnregCustomerDataTable dt = new dsBCartLink.S_SearchUnregCustomerDataTable())
            {
                // BCartに登録できる顧客の抽出
                tnb.MakeSendCustomer();

                // 顧客の検索
                ucTa.Fill(dt,
                    string.IsNullOrEmpty(this.txtCustomerCode.Text) ? null : this.txtCustomerCode.Text,
                    string.IsNullOrEmpty(this.txtCustomerName.Text) ? null : this.txtCustomerName.Text);
                this.bsBcartLink.DataSource = dt;
                this.lblCount.Text = string.Format("{0:#,0}件", dt.Count);
                Program.ScLogger.Info($"{nameof(lblCount)}={lblCount.Text}");
            }
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
                dsBCartLink.S_SearchUnregCustomerRow dbRow = (dsBCartLink.S_SearchUnregCustomerRow)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                string tnbCustomerID = dbRow.顧客管理番号;

                Program.ScLogger.Info($"{nameof(tnbCustomerID)}={tnbCustomerID}");

                // 顧客登録画面を開く
                using (frmRegistCustomer fRegCust = new frmRegistCustomer(tnbCustomerID))
                {
                    fRegCust.Size = new Size((int)(700 * PublicData.DpiX / 90), (int)(500 * PublicData.DpiX / 90));
                    fRegCust.StartPosition = FormStartPosition.CenterScreen;
                    //fOrderDEtail.WindowState = FormWindowState.Maximized;

                    if (fRegCust.ShowDialog() == DialogResult.OK)
                    {
                        // 検索実行
                        doSearchUnregCustomer();
                    }
                }
            }

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmUnregCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
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
            doSearchUnregCustomer();
            Program.ScLogger.Info($"end");
        }
    }
}
