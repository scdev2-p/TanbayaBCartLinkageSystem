using Bcart受注管理.AppData.Ds;
using Bcart受注管理.AppData.Sql;
using Bcart受注管理.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bcart受注管理.Forms.frmMenu;
using static Bcart受注管理.Forms.ViewBuilder;

namespace Bcart受注管理.Forms
{
    internal partial class frmReserving : frmBase
    {
        /// <summary>
        /// 親フォームに次画面を知らせるためのデリゲート
        /// </summary>
        private event NextShowDialogDelegate SetNextShowDialogEvent;


        public frmReserving(NextShowDialogDelegate setNextShowDialogEvent)
        {
            InitializeComponent();

            this.SetNextShowDialogEvent = setNextShowDialogEvent;
        }

        private void frmReserving_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start Load");

            Program.ScLogger.Info($"end Load");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start btnSearch_Click");

            SearchReseving();

            Program.ScLogger.Info($"end btnSearch_Click");
        }


        private void SearchReseving()
        {
            Program.ScLogger.Info($"start SearchReseving {nameof(this.txtCustomer)}={this.txtCustomer.Text}");

            using (AppData.Sql.sqlTnbBCart tnb = new AppData.Sql.sqlTnbBCart())
            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchReserved2TableAdapter srTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchReserved2TableAdapter())
            using (dsBCartLink.S_SearchReserved2DataTable dt = new dsBCartLink.S_SearchReserved2DataTable())
            {
                // 取置の検索
                srTa.Fill(dt, this.txtCustomer.Text, this.textBarcode.Text);
                this.bsBcartLink.DataSource = dt;
            }
            Program.ScLogger.Info($"end SearchReseving {nameof(this.txtCustomer)}={this.txtCustomer.Text}");
        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.ScLogger.Info($"start");

            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnReservedDeital")     // 詳細ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Picking）
                dsBCartLink.S_SearchReserved2Row dbRow = (dsBCartLink.S_SearchReserved2Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                long id = dbRow.reserved_id;
                string customercode = dbRow.customer_code;
                string payment = dbRow.payment_disp;
                string pcicking = dbRow.picking;
                string cutomername = dbRow.顧客名;
                string reservestatus = dbRow.reserve_status;

                // 明細画面を開く
                var fReservedDEtail = new frmReservedDetail(id, customercode, payment, pcicking, cutomername, reservestatus);
                if (fReservedDEtail.ShowDialog() == DialogResult.OK)
                {
                    SearchReseving();
                }
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

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Program.ScLogger.Info($"start");
                SearchReseving();
                Program.ScLogger.Info($"end");
            }
        }

        /// <summary>
        /// 受注一覧画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.OderList);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
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
    }
}
