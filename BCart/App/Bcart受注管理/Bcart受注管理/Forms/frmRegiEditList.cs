using Bcart受注管理.AppData.Ds;
using NLog.LayoutRenderers.Wrappers;
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
    public partial class frmRegiEditList : Form
    {
        public frmRegiEditList()
        {
            InitializeComponent();
        }

        private void frmRegiEditList_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "レジ事前登録の修正";
            this.txtChangeDate.Text = DateTime.Now.ToString("yyyyMMdd");

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerNo.Text))
            {
                return;
            }

            // 検索
            searchData();

        }

        private void searchData()
        {
            dgvMain.DataSource = null;

            using (var ta = new AppData.Ds.dsBCartLink2TableAdapters.W_レジ伝票明細TableAdapter())
            using (var dt = new AppData.Ds.dsBCartLink2.W_レジ伝票明細DataTable())
            {
                ta.Fill(dt, txtCustomerNo.Text);

                if (dt.Count == 0)
                {
                    MessageBox.Show("該当データがありません。");
                    return;
                }

                dgvMain.DataSource = dt;
            }

        }


        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                //if (dgvMain.Rows[i].Cells[4].Value.ToString() != "99500")
                //{
                    dgvMain.Rows[i].Cells["選択"] = new DataGridViewTextBoxCell();
                    dgvMain.Rows[i].Cells["選択"].Value = "";
                    dgvMain.Rows[i].Cells["選択"].ReadOnly = true;
                //}

            }
        }

        private void btnChangeDate_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                return;
            }

            DateTime dt;
            if(!DateTime.TryParse(txtChangeDate.Text.Substring(0,4) + "-" + txtChangeDate.Text.Substring(4, 2) + "-" + txtChangeDate.Text.Substring(6, 2), out dt))
            {
                MessageBox.Show("日付はyyyymmdd形式で入力してください。");
                return;
            }

            if(DateTime.Now.Date > dt)
            {
                MessageBox.Show("過去の日付には変更できません。");
                return;

            }

            using (var ta = new AppData.Ds.dsBCartLink2TableAdapters.QueriesTableAdapter())
            {
                var ret = ta.getEigyoFlag(txtChangeDate.Text);
                if (ret is null || !(bool)ret)
                {
                    MessageBox.Show("休業日には変更できません。");
                    return;
                }

            }

            if (MessageBox.Show(String.Format("伝票年月日を{0:yyyyMMdd}に変更します。\nよろしいですか？", dt), "", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            const string wkDate = "99999999";
            using (var trn = new System.Transactions.TransactionScope())
            using (var ta = new AppData.Ds.dsBCartLink2TableAdapters.W_レジ伝票明細TableAdapter())
            using (var wkDt = new dsBCartLink2.W_レジ伝票明細DataTable())
            {
                try
                {
                    int wkCnt = 0;
                    foreach (DataGridViewRow row in this.dgvMain.Rows)
                    {
                        dsBCartLink2.W_レジ伝票明細Row dbRow = (dsBCartLink2.W_レジ伝票明細Row)((System.Data.DataRowView)row.DataBoundItem).Row;

                        // 一旦日付をダミーに置き換えて明細番号を振り直す
                        ta.UpdateChangeDate(wkDate, wkCnt, dbRow.伝票年月日, dbRow.入力レジ番号, dbRow.カード番号, dbRow.明細番号);
                        wkCnt++;
                    }

                    ta.Fill(wkDt, txtCustomerNo.Text);

                    foreach(var row in wkDt)
                    {
                        // 変更後の伝票年月日に更新
                        ta.UpdateChangeDate(txtChangeDate.Text, row.明細番号, row.伝票年月日, row.入力レジ番号, row.カード番号, row.明細番号);
                    }

                    trn.Complete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB登録でエラーが発生しました。\n" + ex.Message);
                    return;
                }
            }

            // 検索
            searchData();

            MessageBox.Show("伝票年月日を変更しました。");
        }

        private void btnDelFare_Click(object sender, EventArgs e)
        {
            if(dgvMain.Rows.Count == 0)
            {
                return;
            }

            int fareCnt = 0;
            int checkCnt = 0;

            foreach (DataGridViewRow row in this.dgvMain.Rows)
            {
                dsBCartLink2.W_レジ伝票明細Row dbRow = (dsBCartLink2.W_レジ伝票明細Row)((System.Data.DataRowView)row.DataBoundItem).Row;

                if(dbRow.バーコード == "99500")  //運賃をカウント
                {
                    fareCnt++;

                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)     //チェックされているものをカウント
                        { checkCnt++; }
                }

            }

            if(fareCnt - checkCnt != 1)
            {
                MessageBox.Show("運賃を一つ残してください。");
                return;
            }

            if (checkCnt == 0)
            {
                MessageBox.Show("削除する運賃が選ばれていません。");
                return;
            }

            if (MessageBox.Show("選択した運賃を削除します。\nよろしいですか？", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            using (var trn = new System.Transactions.TransactionScope())
            using (AppData.Ds.dsBCartLink2TableAdapters.W_レジ伝票明細TableAdapter ta = new AppData.Ds.dsBCartLink2TableAdapters.W_レジ伝票明細TableAdapter())
            {
                try
                {
                    foreach (DataGridViewRow row in this.dgvMain.Rows)
                    {
                        dsBCartLink2.W_レジ伝票明細Row dbRow = (dsBCartLink2.W_レジ伝票明細Row)((System.Data.DataRowView)row.DataBoundItem).Row;

                        if (dbRow.バーコード == "99500")  //運賃を
                        {
                            if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)
                            {
                                ta.DeleteRegiRow(dbRow.伝票年月日,dbRow.入力レジ番号, dbRow.カード番号, dbRow.明細番号);
                            }
                        }
                    }

                    trn.Complete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB登録でエラーが発生しました。\n" + ex.Message);
                    return;
                }
            }

            // 検索
            searchData();

            MessageBox.Show("運賃を削除しました。");
        }
    }
}
