using BCart商品登録.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCart商品登録.Forms
{
    public partial class frmProductDelete : Form
    {
        public frmProductDelete()
        {
            InitializeComponent();

            foreach (DataGridViewColumn col in this.dgvMainList.Columns)
            {
                if (col.Index > 0)
                {
                    // 先頭のチェックボックス以外はReadOnly
                    col.ReadOnly = true;
                }
            }
        }

        public frmProductDelete(long productID)
        {
            InitializeComponent();

            txtProductsID.Text = productID.ToString();

            foreach (DataGridViewColumn col in this.dgvMainList.Columns)
            {
                if (col.Index > 0)
                {
                    // 先頭のチェックボックス以外はReadOnly
                    col.ReadOnly = true;
                }
            }
        }



        private void frmProductDelete_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnDoDelete.Enabled = false;

            if(!string.IsNullOrEmpty(txtProductsID.Text))
            {
                // 検索実行
                SearchMainList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtProductsID.Text) && string.IsNullOrEmpty(txtBarcode.Text) && string.IsNullOrEmpty(txtProductSetID.Text))
            {
                MessageBox.Show("検索条件を指定してください。");
                return;
            }

            // 検索実行
            SearchMainList();
            if (dgvMainList.Rows.Count == 0)
            {
                MessageBox.Show("商品が見つかりませんでした。");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoDelete_Click(object sender, EventArgs e)
        {
            if(dgvMainList.Rows.Count == 0)
            { return; }

            if(rdoDelProducts.Checked)
            {
                if(MessageBox.Show("商品を削除可能にします。\nよろしいですか？","",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using(SqlTnbToBCart sql = new SqlTnbToBCart())
                    {
                        for (int i = 0; i < dgvMainList.Rows.Count; i++)
                        {
                            if (dgvMainList.Rows[i].Cells[0].Value != null)
                            {
                                dsTnbToBCart.bc登録済商品Row dbRow = (dsTnbToBCart.bc登録済商品Row)((System.Data.DataRowView)dgvMainList.Rows[i].DataBoundItem).Row;
                                long productID = dbRow.基本_Bカート商品ID;

                                sql.updateDeleteFlagByProducts(productID);
                            }
                        }
                    }

                    // 検索実行
                    SearchMainList();
                }
            }
            else
            {
                if (MessageBox.Show("セット毎に削除可能にします。\nよろしいですか？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    using (SqlTnbToBCart sql = new SqlTnbToBCart())
                    {
                        for (int i = 0; i < dgvMainList.Rows.Count; i++)
                        {
                            if (dgvMainList.Rows[i].Cells[0].Value != null)
                            {
                                dsTnbToBCart.bc登録済商品Row dbRow = (dsTnbToBCart.bc登録済商品Row)((System.Data.DataRowView)dgvMainList.Rows[i].DataBoundItem).Row;
                                long setID = dbRow.セット_BカートセットID;

                                sql.updateDeleteFlagBySets(setID);
                            }
                        }
                    }
                    // 検索実行
                    SearchMainList();
                }
            }
        }

        private void SearchMainList()
        {
            if (string.IsNullOrEmpty(txtProductsID.Text) && string.IsNullOrEmpty(txtProductSetID.Text) && string.IsNullOrEmpty(txtBarcode.Text))
                return;

            long productsID = 0;
            long productSetID = 0;
            if(string.IsNullOrEmpty(txtProductsID.Text) || !long.TryParse(txtProductsID.Text, out productsID))
                productsID = 0;
            if (string.IsNullOrEmpty(txtProductSetID.Text) || !long.TryParse(txtProductSetID.Text, out productSetID))
                productSetID = 0;

            using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
            using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
            {
                if (productsID != 0)
                {
                    ta.FillByProductID(dt, productsID);
                }
                else if(productSetID != 0)
                {
                    ta.FillByProductSetID(dt, productSetID);
                }
                else if (!string.IsNullOrEmpty(txtBarcode.Text))
                {
                    ta.FillBySetBarcode(dt, txtBarcode.Text);
                }
                int delCnt = 0;
                foreach (var row in dt)
                {
                    if (!row.Is削除フラグNull() && row.削除フラグ == 1)
                        delCnt++;
                }
                if (delCnt == dt.Count)
                {
                    lblMessage.Text = "この商品はBカートから削除できます。";
                    btnDoDelete.Enabled = false;
                }
                else if (delCnt > 0)
                {
                    lblMessage.Text = "セット商品毎に削除できます。";
                    btnDoDelete.Enabled = true;
                }
                else
                {
                    lblMessage.Text = "";
                    btnDoDelete.Enabled = true;
                }

                if(dt.Count == 1)
                {
                    rdoDelProducts.Checked = true;
                    rdoDelSet.Enabled = false;
                }
                else
                {
                    rdoDelSet.Enabled = true;
                }

                bsMainList.DataSource = dt;

            }
        }

    }
}
