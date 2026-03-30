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
    public partial class frmProductSet : Form
    {
        public frmProductSet()
        {
            InitializeComponent();

            foreach (DataGridViewColumn col in this.dgvMainList.Columns)
            {
                if (col.Index > 1)
                {
                    // 先頭のボタン列以外はReadOnly
                    col.ReadOnly = true;
                }
            }
        }

        private void frmProductSet_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductsID.Text) && string.IsNullOrEmpty(txtBarcode.Text) && string.IsNullOrEmpty(txtProductSetID.Text))
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

        private void SearchMainList()
        {
            if (string.IsNullOrEmpty(txtProductsID.Text) && string.IsNullOrEmpty(txtProductSetID.Text) && string.IsNullOrEmpty(txtBarcode.Text))
                return;

            long productsID = 0;
            long productSetID = 0;
            if (string.IsNullOrEmpty(txtProductsID.Text) || !long.TryParse(txtProductsID.Text, out productsID))
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
                else if (productSetID != 0)
                {
                    ta.FillByProductSetID(dt, productSetID);
                }
                else if (!string.IsNullOrEmpty(txtBarcode.Text))
                {
                    ta.FillBySetBarcode(dt, txtBarcode.Text);
                }

                bsMainList.DataSource = dt;
            }

        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnAdd")     //追加ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Order）
                dsTnbToBCart.bc登録済商品Row dbRow = (dsTnbToBCart.bc登録済商品Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                //long id = dbRow.order_id;

                // 明細画面を開く
                frmProductSetRegist fprodDetail = new frmProductSetRegist(dbRow,true);
                if (fprodDetail.ShowDialog() == DialogResult.OK)
                {
                    // 一覧再表示
                    SearchMainList();
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "btnChange")     //変更ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Order）
                dsTnbToBCart.bc登録済商品Row dbRow = (dsTnbToBCart.bc登録済商品Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                //long id = dbRow.order_id;

                // 明細画面を開く
                frmProductSetRegist fprodDetail = new frmProductSetRegist(dbRow,false);
                if (fprodDetail.ShowDialog() == DialogResult.OK)
                {
                    // 一覧再表示
                    SearchMainList();
                }
            }
        }
    }
}
