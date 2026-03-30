using System.Text;
using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Microsoft.VisualBasic;
using static Bcart受注管理.Forms.frmMenu;
using static Bcart受注管理.Forms.ViewBuilder;

namespace Bcart受注管理.Forms
{
    internal partial class frmOderList : frmBase
    {
        /// <summary>
        /// 親フォームに次画面を知らせるためのデリゲート
        /// </summary>
        private event NextShowDialogDelegate SetNextShowDialogEvent;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="setNextShowDialogEvent">親フォームに次画面を知らせるためのデリゲート</param>
        public frmOderList(NextShowDialogDelegate setNextShowDialogEvent)
        {
            InitializeComponent();

            // 全てのキー入力をFormが受け取る
            this.KeyPreview = true;

            this.SetNextShowDialogEvent = setNextShowDialogEvent;
        }

        private void frmOderList_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCart受注一覧";


            // 検索条件初期値
            this.dtOrderFrom.Value = DateTime.Now.AddMonths(-1);
            this.dtOrderTo.Value = DateTime.Now;

            this.cmbStatus.Items.Clear();
            for (int i = 0; i < Consts.OrderStatus.Count; i++)
            {
                this.cmbStatus.Items.Add(Consts.OrderStatus[i]);
            }
            // ステータスの初期値
            this.cmbStatus.SelectedIndex = 1;

            // 検索実行
            doSearchOrders();

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
        /// 検索実行
        /// </summary>
        private void doSearchOrders()
        {
            Program.ScLogger.Info($"start {nameof(Settings.Default.ListLimit)}={Settings.Default.ListLimit}, {nameof(txtOrderCode)}={txtOrderCode.Text}, {nameof(txtCustomerCode)}={txtCustomerCode.Text}, {nameof(dtOrderFrom)}={dtOrderFrom.Value}, {nameof(dtOrderTo)}={dtOrderTo.Value}, {nameof(Consts.OrderStatus)}={Consts.OrderStatus[this.cmbStatus.SelectedIndex]}");

            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchOrder2TableAdapter OrderTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchOrder2TableAdapter())
            using (AppData.Ds.dsBCartLinkTableAdapters.DataCountTableAdapter CountTa = new AppData.Ds.dsBCartLinkTableAdapters.DataCountTableAdapter())
            using (dsBCartLink.S_SearchOrder2DataTable dt = new dsBCartLink.S_SearchOrder2DataTable())
            using (dsBCartLink.DataCountDataTable dtCnt = new dsBCartLink.DataCountDataTable())
            {
                string st = Consts.OrderStatus[this.cmbStatus.SelectedIndex];

                // 受注の検索
                ViewBuilder.SetSearchTime(this.dtOrderFrom, this.dtOrderTo);
                OrderTa.Fill(dt,
                    Settings.Default.ListLimit,
                    null,
                    string.IsNullOrEmpty(this.txtOrderCode.Text) ? null : long.Parse(this.txtOrderCode.Text),
                    string.IsNullOrEmpty(this.txtCustomerCode.Text) ? null : this.txtCustomerCode.Text,
                    this.dtOrderFrom.Value, this.dtOrderTo.Value,
                    st == "(すべて)" ? null : st);
                this.bsBcartLink.DataSource = dt;

                // 総数取得
                CountTa.FillBySerchOrderCunt2(dtCnt,
                    null,
                    string.IsNullOrEmpty(this.txtOrderCode.Text) ? null : long.Parse(this.txtOrderCode.Text),
                    string.IsNullOrEmpty(this.txtCustomerCode.Text) ? null : this.txtCustomerCode.Text,
                    this.dtOrderFrom.Value, this.dtOrderTo.Value,
                    st == "(すべて)" ? null : st);
                this.lblCount.Text = string.Format("{0:#,0}件（最大表示{1:#,0}件）", dtCnt.Count > 0 ? dtCnt[0].Count : "", Settings.Default.ListLimit);
                Program.ScLogger.Info($"{nameof(lblCount)}={lblCount.Text}");

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
                dsBCartLink.S_SearchOrder2Row dbRow = (dsBCartLink.S_SearchOrder2Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                long id = dbRow.order_id;

                Program.ScLogger.Info($"{nameof(id)}={id}");

                // 明細画面を開く
                frmOrderDetail fOrderDEtail = new frmOrderDetail(id, Consts.FormMode.ReadOnly);
                fOrderDEtail.WindowState = FormWindowState.Maximized;
                fOrderDEtail.ShowDialog();

            }

            Program.ScLogger.Info($"end");
        }
        private StringBuilder readbuff = new StringBuilder();
        private string stringValue = "";

        private void frmOderList_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.ScLogger.Info($"start");

            if (e.KeyChar == ControlChars.Cr)
            {
                e.Handled = true;
                stringValue = readbuff.ToString();
                readbuff.Clear();

                // 検索条件にフォーカスがある場合は検索を再実行する
                if (this.txtCustomerCode.Focused
                    || this.txtOrderCode.Focused
                    || this.dtOrderFrom.Focused
                    || this.dtOrderTo.Focused
                    || this.cmbStatus.Focused)
                {
                    doSearchOrders();
                }
            }
            else
            {
                readbuff.Append(e.KeyChar);
            }

            Program.ScLogger.Info($"end");
        }

        // 検索ボタン押下
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            doSearchOrders();
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmOderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }

        /// <summary>
        /// ピッキング作業画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnPicking_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.PickingWork);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// BCart受注再取込画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnReloadOrder_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.ReloadOrder);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
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

        //private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Program.ScLogger.Info($"start");
        //        doSearchOrders();
        //        Program.ScLogger.Info($"end");
        //    }
        //}
    }
}
