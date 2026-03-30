using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcart受注管理.Forms
{
    public partial class frmRegiList : Form
    {
        public frmRegiList()
        {
            InitializeComponent();
        }

        private void frmRegiList_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "レジ事前登録一覧";

            // 検索条件初期値
            this.dtRegiFrom.Value = DateTime.Now.AddDays(-7);
            this.dtRegiTo.Value = DateTime.Now.AddDays(+7);

            // 検索実行
            doSearchRegi();

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.Close();
            Program.ScLogger.Info($"end");
        }

        private void doSearchRegi()
        {
            // ログ
            Program.ScLogger.Info($"start {nameof(Settings.Default.ListLimit)}={Settings.Default.ListLimit}, {nameof(txtCustomerExtId)}={txtCustomerExtId.Text}, , {nameof(txtOrderCode)}={txtOrderCode.Text}{nameof(txtCustomerCade)}={txtCustomerCade.Text}, {nameof(dtRegiFrom)}={dtRegiFrom.Value}, {nameof(dtRegiTo)}={dtRegiTo.Value}");

            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchRegiTableAdapter RegiTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchRegiTableAdapter())
            using (AppData.Ds.dsBCartLinkTableAdapters.DataCountTableAdapter CountTa = new AppData.Ds.dsBCartLinkTableAdapters.DataCountTableAdapter())
            using (dsBCartLink.S_SearchRegiDataTable RegiDt = new dsBCartLink.S_SearchRegiDataTable())
            {
                // 受注の検索
                RegiTa.Fill(RegiDt,
                    Settings.Default.ListLimit,
                    null,
                    string.IsNullOrEmpty(this.txtOrderCode.Text) ? null : long.Parse(this.txtOrderCode.Text),
                    string.IsNullOrEmpty(this.txtCustomerExtId.Text) ? null : this.txtCustomerExtId.Text,
                    string.IsNullOrEmpty(this.txtCustomerCade.Text) ? null : this.txtCustomerCade.Text,
                    this.chkRegiDate.Checked ? this.dtRegiFrom.Value.ToString("yyyyMMdd") : null,
                    this.chkRegiDate.Checked ? this.dtRegiTo.Value.ToString("yyyyMMdd") : null
                    );
                this.bindingSource1.DataSource = RegiDt;

                // 総数取得
                var Count = RegiDt.Rows.Count;
                this.lblCount.Text = string.Format("{0:#,0}件（最大表示{1:#,0}件）", Count > 0 ? Count : "0", Settings.Default.ListLimit);
                Program.ScLogger.Info($"{nameof(lblCount)}={lblCount.Text}");
            }
        }

        private void btnRegiSearch_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 検索
            this.doSearchRegi();
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

                // クリックされた行にバインドされているRowデータを取得
                dsBCartLink.S_SearchRegiRow dbRow = (dsBCartLink.S_SearchRegiRow)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;

                if (dbRow.Is受注IDNull())
                    return;

                long id = dbRow.受注ID;

                Program.ScLogger.Info($"{nameof(id)}={id}");

                // 明細画面を開く
                frmRegiDetail fRegiDetail = new frmRegiDetail(id, Consts.FormMode.ReadOnly);
                fRegiDetail.WindowState = FormWindowState.Maximized;
                fRegiDetail.ShowDialog();

            }

            Program.ScLogger.Info($"end");
        }

        private void txtCustomerCade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Program.ScLogger.Info($"start");
                doSearchRegi();
                Program.ScLogger.Info($"end");
            }
        }
    }
}
