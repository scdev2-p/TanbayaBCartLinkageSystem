using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;

namespace Bcart受注管理.Forms
{
    public partial class frmShippingInspection : Form
    {

        const string C_BtnReset = "リセット";
        const string C_BtnConfirm = "確認";

        const string C_StatusOK = "OK";
        const string C_StatusNG = "NG";

        public frmShippingInspection()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private StringBuilder readBuff = new StringBuilder();
        private bool isPickingCdInput = true;

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sCode;

            if (e.KeyChar == (char)Keys.Enter)
            {
                sCode = readBuff.ToString();
                readBuff = new StringBuilder();

                if (sCode.Length < 1)
                {
                    return;
                }

                if (txtPickingCD.Focused)
                {
                    // ピッキング番号は最後の1桁はチェックデジットなので除外
                    if (sCode.Length == 13)
                    {
                        txtPickingCD.Text = sCode.Substring(0, sCode.Length - 1);
                    }

                    this.lblSearch.Visible = true;
                    this.Update();
                    if (!SearchMainList())
                    {
                        // データ無し
                        txtPickingCD.Text = "";

                        this.lblSearch.Visible = false;
                        lblNoData.Visible = true;
                        this.Update();
                        System.Threading.Thread.Sleep(2000);
                        lblNoData.Visible = false;
                        txtPickingCD.Focus();
                        return;
                    }

                    this.lblSearch.Visible = false;
                    isPickingCdInput = false;
                    txtPickingCD.ReadOnly = true;
                    dgvMainList.Focus();


                }
                else if (dgvMainList.Focused)
                {
                    // バーコード
                    string barcode = sCode;


                    for (int i = 0; i < dgvMainList.Rows.Count; i++)
                    {
                        if (dgvMainList.Rows[i].Cells[0].Value != null)
                        {
                            dsBCartLink2.PickingDetailRow dbRow = (dsBCartLink2.PickingDetailRow)((System.Data.DataRowView)dgvMainList.Rows[i].DataBoundItem).Row;

                            if (dbRow.Barcode.Trim() == barcode.Trim())     // バーコードにスペースが入っているものがある
                            {
                                dbRow.CheckCount += 1;
                                if (dbRow.CheckCount == dbRow.order_pro_count)
                                {
                                    dbRow.Status = C_StatusOK;
                                    dgvMainList.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
                                }
                                else if (dbRow.CheckCount > dbRow.order_pro_count)
                                {
                                    dbRow.Status = C_StatusNG;
                                    dgvMainList.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.OrangeRed;
                                }

                                if (dbRow.CheckCount == 0 &&  dbRow.order_pro_count == 0)
                                {
                                    dgvMainList.Rows[i].Cells[6].Value = C_BtnConfirm;      // 確認
                                }
                                else
                                {
                                    dgvMainList.Rows[i].Cells[6].Value = C_BtnReset;        // リセット
                                }

                                break;
                            }
                        }
                    }

                    checkAllRows();


                    dgvMainList.Focus();


                }

            }
            else
            {
                readBuff.Append(e.KeyChar.ToString());
            }

        }

        private void checkAllRows()
        {
            bool checkComplete = true;
            for (int i = 0; i < dgvMainList.Rows.Count; i++)
            {
                if (dgvMainList.Rows[i].Cells[0].Value != null)
                {
                    dsBCartLink2.PickingDetailRow dbRow = (dsBCartLink2.PickingDetailRow)((System.Data.DataRowView)dgvMainList.Rows[i].DataBoundItem).Row;
                    if (dbRow.CheckCount != dbRow.order_pro_count)
                        checkComplete = false;
                    else if(dbRow.order_pro_count == 0 && dbRow.Status != C_StatusOK)
                        checkComplete = false;
                }
            }
            // 全てOKの場合
            if (checkComplete)
            {
                lblCheckComplete.Visible = true;
                btnClearAll.Visible = true;
            }
        }

        private bool SearchMainList()
        {
            try
            {
                using (AppData.Ds.dsBCartLink2TableAdapters.PickingDetailTableAdapter ta = new AppData.Ds.dsBCartLink2TableAdapters.PickingDetailTableAdapter())
                using (dsBCartLink2.PickingDetailDataTable dt = new dsBCartLink2.PickingDetailDataTable())
                {

                    ta.FillByPickingCD(dt, txtPickingCD.Text);
                    if (dt.Rows.Count < 1)
                    {
                        this.dgvMainList.DataSource = null;
                        return false;
                    }

                    this.dgvMainList.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex.Message);
                Program.ScLogger.Error(ex.StackTrace);
                MessageBox.Show("エラーが発生しました。\n他の人が同じデータを開いてないか確認し、\n操作をやり直してください。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // クリックされた行にバインドされているRowデータを取得（Picking）
            if (dgvMainList.Rows.Count > 0)
            {
                dsBCartLink2.PickingDetailRow dbRow = (dsBCartLink2.PickingDetailRow)((System.Data.DataRowView)dgvMainList.Rows[0].DataBoundItem).Row;
                lblCustomerCD.Text = dbRow.CustomerCD;
                lblCustomerName.Text = dbRow.customer_comp_name;
                lblOrderCD.Text = dbRow.order_code.ToString();
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // リセット
            txtPickingCD.ReadOnly = false;
            txtPickingCD.Text = "";
            lblCustomerCD.Text = "";
            lblCustomerName.Text = "";
            lblOrderCD.Text = "";
            lblCheckComplete.Visible = false;
            btnClearAll.Visible = false;
            dgvMainList.DataSource = null;
            readBuff = new StringBuilder();
            isPickingCdInput = true;

            txtPickingCD.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNoData.Visible = false;
            lblCheckComplete.Visible = false;
            btnClearAll.Visible = false;
            this.lblSearch.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPickingCD.Text) || isPickingCdInput)
            {
                txtPickingCD.Focus();
            }
            else
            {
                dgvMainList.Focus();
            }
        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnReset")     // 詳細ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Picking）
                dsBCartLink2.PickingDetailRow dbRow = (dsBCartLink2.PickingDetailRow)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;

                if (dbRow.order_pro_count == 0 && dbRow.CheckCount == 0)
                {
                    // 確認
                    dbRow.Status = C_StatusOK;
                    dgvMainList.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;

                    checkAllRows();
                }
                else
                {
                    // リセット
                    dbRow.CheckCount = 0;
                    dbRow.Status = "";

                    dgvMainList.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void dgvMainList_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPickingCD.Text) || isPickingCdInput)
            {
                txtPickingCD.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // リセット
            txtPickingCD.ReadOnly = false;
            txtPickingCD.Text = "";
            lblCustomerCD.Text = "";
            lblCustomerName.Text = "";
            lblOrderCD.Text = "";
            lblCheckComplete.Visible = false;
            btnClearAll.Visible = false;
            dgvMainList.DataSource = null;
            readBuff = new StringBuilder();
            isPickingCdInput = true;

            txtPickingCD.Focus();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            // リセット
            txtPickingCD.ReadOnly = false;
            txtPickingCD.Text = "";
            lblCustomerCD.Text = "";
            lblCustomerName.Text = "";
            lblOrderCD.Text = "";
            lblCheckComplete.Visible = false;
            btnClearAll.Visible = false;
            dgvMainList.DataSource = null;
            readBuff = new StringBuilder();
            isPickingCdInput = true;

            txtPickingCD.Focus();
        }

        private void dgvMainList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgvMainList.Rows)
            {
                dsBCartLink2.PickingDetailRow dbRow = (dsBCartLink2.PickingDetailRow)((System.Data.DataRowView)row.DataBoundItem).Row;
                if(dbRow.order_pro_count == 0)
                {
                    row.Cells[6].Value = C_BtnConfirm;  // 確認
                }
                else
                {
                    row.Cells[6].Value = C_BtnReset;    // リセット
                }
            }

        }
    }
}
