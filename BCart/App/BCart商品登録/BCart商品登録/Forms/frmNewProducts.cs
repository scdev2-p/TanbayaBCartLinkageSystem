using BCart商品登録.AppData;
using BCart商品登録.Task;
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
    public partial class frmNewProducts : Form
    {
        public frmNewProducts()
        {
            InitializeComponent();


            foreach (DataGridViewColumn col in this.dgvMainList.Columns)
            {
                if (col.Index > 1)
                {
                    // 先頭のチェックボックスとボタン列以外はReadOnly
                    col.ReadOnly = true;
                }
            }
        }

        private void frmNewProducts_Load(object sender, EventArgs e)
        {

            txtLimit.Text = Settings.Default.ListLimit.ToString();
            lblWeit.Visible = false;

            using (SqlTnbToBCart sql = new SqlTnbToBCart())
            {
                // 取込済の最大IDは画面を開いた時から保持する
                _maxTnbProductID = sql.GetMaxTnbProductID();
            }

            // 一覧検索
            //SearchMainList();

        }

        private string _maxTnbProductID = "";

        private void SearchMainList()
        {
            lblWeit.Visible = true;
            lblWeit.Update();

            using (AppData.dsTnbToBCartTableAdapters.S_新規商品差分抽出2TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.S_新規商品差分抽出2TableAdapter())
            using (dsTnbToBCart.S_新規商品差分抽出2DataTable dt = new dsTnbToBCart.S_新規商品差分抽出2DataTable())
            { 
                int limit;
                if (!int.TryParse(txtLimit.Text, out limit))
                {
                    MessageBox.Show("件数には数字を入れてください。");
                    return;
                }
                decimal jodai = 0;
                decimal.TryParse(txtJyodai.Text, out jodai);
                ta.CommandTimeout = 60 * 4;     // タイムアウトを4分にする
                ta.Fill(dt, limit, txtBarcode.Text, txtMakerCD.Text, txtFloorCD.Text, jodai);
                this.bsNewProductsList.DataSource = dt;

                this.lblCount.Text = string.Format("[{0:#,0} 件]", dt.Count);
            }

            lblWeit.Visible=false;
        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnDetail")     // 詳細ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Order）
                dsTnbToBCart.S_新規商品差分抽出2Row dbRow = (dsTnbToBCart.S_新規商品差分抽出2Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                //long id = dbRow.order_id;

                // 明細画面を開く
                frmProductDetail fprodDetail = new frmProductDetail(dbRow);
                fprodDetail.WindowState = FormWindowState.Maximized;
                if (fprodDetail.ShowDialog() == DialogResult.OK)
                {
                    // 一覧再表示
                    SearchMainList();
                }
            }
        }

        private void btnRegistProducts_Click(object sender, EventArgs e)
        {
            List<dsTnbToBCart.S_新規商品差分抽出2Row> Lst登録商品 = new List<dsTnbToBCart.S_新規商品差分抽出2Row>();


            for (int i = 0; i < dgvMainList.Rows.Count; i++)
            {
                if (dgvMainList.Rows[i].Cells[0].Value != null)
                {
                    dsTnbToBCart.S_新規商品差分抽出2Row dbRow = (dsTnbToBCart.S_新規商品差分抽出2Row)((System.Data.DataRowView)dgvMainList.Rows[i].DataBoundItem).Row;
                    Lst登録商品.Add(dbRow);
                }
            }

            if (Lst登録商品.Count == 0)
            {
                MessageBox.Show("商品が選択されていません。");
                return;
            }

            // 選択された商品をBカートに登録する
            if (chkRegDetail.Checked)
            {
                using (var f = new frmNewProductsDetaail(Lst登録商品))
                {
                    f.WindowState = FormWindowState.Maximized;
                    var ret = f.ShowDialog();
                }

                // 一覧検索
                SearchMainList();
                return;
            }

            if (MessageBox.Show("商品マスタをBカートに登録します。\nよろしいですか？", "商品マスタ登録", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            using (bcNewProductsRegist prod = new bcNewProductsRegist())
            {
                if (!prod.Do(Lst登録商品))
                {
                    MessageBox.Show("実行中にエラーが発生しました。\n管理者に連絡してください。");
                    return;
                }
            }

            // 一覧検索
            SearchMainList();

            MessageBox.Show("Bカートに商品を登録しました。");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMakerCD.Text)
            && string.IsNullOrEmpty(txtFloorCD.Text)
            && string.IsNullOrEmpty(txtBarcode.Text)
            && string.IsNullOrEmpty(txtJyodai.Text))
            {
                MessageBox.Show("検索条件を何か指定してください。");
                return;
            }
 
            // 一覧検索
            SearchMainList();
        }

        private void dgvMainList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvMainList.Rows.Count; i++)
            {

                dsTnbToBCart.S_新規商品差分抽出2Row dbRow = (dsTnbToBCart.S_新規商品差分抽出2Row)((System.Data.DataRowView)dgvMainList.Rows[i].DataBoundItem).Row;
                if (long.Parse(dbRow.商品管理番号) < long.Parse(_maxTnbProductID))
                {
                    dgvMainList.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
    }
}
