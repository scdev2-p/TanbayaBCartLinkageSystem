using BCart商品登録.AppData;
using BCart商品登録.Task;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCartApi;

namespace BCart商品登録.Forms
{
    public partial class frmProductDetail : Form
    {
        private dsTnbToBCart.S_新規商品差分抽出2Row _ProductsRow;


        public frmProductDetail(dsTnbToBCart.S_新規商品差分抽出2Row dbRow)
        {
            InitializeComponent();

            foreach (DataGridViewColumn col in this.dgvMainList.Columns)
            {
                if (col.Index > 2)
                {
                    // 先頭のチェックボックス以外はReadOnly
                    col.ReadOnly = true;
                }
            }

            _ProductsRow = dbRow;
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            lblTnbProductsNo.Text = _ProductsRow.商品管理番号;
            lblBarcode.Text = _ProductsRow.バーコード;
            lblProductsName.Text = _ProductsRow.商品名;
            lblFloor.Text = _ProductsRow.フロア名;
            lblOversea.Text = (_ProductsRow.Is海外禁止Null() || _ProductsRow.海外禁止 == 0) ? "" : "禁止";
            lblNetNG.Text = _ProductsRow.WEB販売拒否フラグ ? "禁止" : "";

            lblRegisted.Visible = false;

            // 一覧検索
            SearchMainList();
        }

        private void SearchMainList()
        {
            using (AppData.dsTnbToBCartTableAdapters.S_バーコード重複商品抽出TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.S_バーコード重複商品抽出TableAdapter())
            using (dsTnbToBCart.S_バーコード重複商品抽出DataTable dt = new dsTnbToBCart.S_バーコード重複商品抽出DataTable())
            {
                ta.Fill(dt, _ProductsRow.バーコード);

                this.bsMainList.DataSource = dt;
            }

        }

        private void btnRegistProducts_Click(object sender, EventArgs e)
        {
            List<dsTnbToBCart.S_バーコード重複商品抽出Row> LstBarcode削除商品 = new List<dsTnbToBCart.S_バーコード重複商品抽出Row>();


            for (int i = 0; i < dgvMainList.Rows.Count; i++)
            {
                if (dgvMainList.Rows[i].Cells[0].Value != null)
                {
                    dsTnbToBCart.S_バーコード重複商品抽出Row dbRow = (dsTnbToBCart.S_バーコード重複商品抽出Row)((System.Data.DataRowView)dgvMainList.Rows[1].DataBoundItem).Row;
                    LstBarcode削除商品.Add(dbRow);
                }
            }

            if (LstBarcode削除商品.Count == 0)
            {
                MessageBox.Show("商品が選択されていません。");
                return;
            }

            if (MessageBox.Show("商品マスタをBカートに登録します。\nよろしいですか？", "商品マスタ登録", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            // 選択された商品をBカートに登録する

            using (bcDeleteBarcodeProducts prod = new bcDeleteBarcodeProducts())
            {
                if (!prod.Do(LstBarcode削除商品))
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

        private void btnBcRegist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("商品をBカートに登録します。\nよろしいですか？", "Bカート商品登録", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            using (bcNewProductsRegist bc = new bcNewProductsRegist())
            {
                if (!bc.RegistNew(_ProductsRow))
                {
                    return;
                }
            }
            lblRegisted.Visible = true;
            //btnBcRegist.Visible = false;

            MessageBox.Show("Bカートに登録しました。");
        }

        private void frmProductDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblRegisted.Visible)
            {
                this.DialogResult = DialogResult.OK;    // 登録済みの場合はリストの再表示
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnChange")     // 詳細ボタンがクリックされた場合
            {
                //// クリックされた行にバインドされているRowデータを取得（Order）
                //dsTnbToBCart.S_バーコード重複商品抽出Row dbRow = (dsTnbToBCart.S_バーコード重複商品抽出Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                ////long id = dbRow.order_id;


                //using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
                //using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
                //{
                //    ta.FillByID(dt, dbRow.基本_Bカート商品ID, dbRow.セット_BカートセットID);
                //    if(dt.Count == 0)
                //    {
                //        Log.ErrWrite(string.Format("bc登録済商品 取得エラー:productID[{1}] SetID[{1}]", dbRow.基本_Bカート商品ID, dbRow.セット_BカートセットID));                        
                //        MessageBox.Show("システムエラー");
                //        return;
                //    }
                //    // 明細画面を開く
                //    frmChangeBarcodeDetail fprodDetail = new frmChangeBarcodeDetail(dt[0]);
                //    //fprodDetail.WindowState = FormWindowState.Maximized;
                //    if (fprodDetail.ShowDialog() == DialogResult.OK)
                //    {
                //        // 一覧再表示
                //        SearchMainList();
                //    }
                //}
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "btnDelete")     // 詳細ボタンがクリックされた場合
            {
                //// クリックされた行にバインドされているRowデータを取得（Order）
                //dsTnbToBCart.S_バーコード重複商品抽出Row dbRow = (dsTnbToBCart.S_バーコード重複商品抽出Row)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                ////long id = dbRow.order_id;


                //using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
                //using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
                //{
                //    ta.FillByID(dt, dbRow.基本_Bカート商品ID, dbRow.セット_BカートセットID);
                //    if (dt.Count == 0)
                //    {
                //        Log.ErrWrite(string.Format("bc登録済商品 取得エラー:productID[{1}] SetID[{1}]", dbRow.基本_Bカート商品ID, dbRow.セット_BカートセットID));
                //        MessageBox.Show("システムエラー");
                //        return;
                //    }
                //    // 明細画面を開く
                //    frmProductDelete fprodDetail = new frmProductDelete(dt[0].基本_Bカート商品ID);
                //    //fprodDetail.WindowState = FormWindowState.Maximized;
                //    if (fprodDetail.ShowDialog() == DialogResult.OK)
                //    {
                //        // 一覧再表示
                //        SearchMainList();
                //    }
                //}
            }
        }
    }
}
