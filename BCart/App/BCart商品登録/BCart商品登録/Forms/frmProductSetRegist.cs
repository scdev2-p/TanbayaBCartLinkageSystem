using BCartApi;
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
using System.Xml.Linq;

namespace BCart商品登録.Forms
{
    public partial class frmProductSetRegist : Form
    {

        private dsTnbToBCart.bc登録済商品Row productsRow;
        private bool isAddSet;

        public frmProductSetRegist(dsTnbToBCart.bc登録済商品Row row, bool isAdd)
        {
            InitializeComponent();
            productsRow = row;
            isAddSet = isAdd;
        }

        private void frmProductSetRegist_Load(object sender, EventArgs e)
        {
            lblProductsID.Text = productsRow.基本_Bカート商品ID.ToString();
            lblName.Text = productsRow.基本_商品名;
            lblNoData.Visible = false;
            if (isAddSet)
            {
                lblSetID.Text = "";
                txtSetName.Text = "";
                txtSetNo.Text = "";
                txtBarcode.Text = "";
                lblJyodai.Text = "";
                lblStock.Text = "";
                btnRegist.Text = "追加登録";
            }
            else
            {
                lblSetID.Text = productsRow.セット_BカートセットID.ToString();
                txtSetName.Text = productsRow.Isセット_セット名Null()? "" : productsRow.セット_セット名;
                txtSetNo.Text = "";
                txtBarcode.Text = productsRow.Isセット_カスタム項目1Null()? "" : productsRow.セット_カスタム項目1;
                lblJyodai.Text = productsRow.Isセット_上代Null()? "" : productsRow.セット_上代.ToString();
                lblStock.Text = productsRow.Isセット_在庫Null() ? "" : productsRow.セット_在庫.ToString();
                btnRegist.Text = "変更";
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private dsTnbToBCart.M_商品Row getProductsByBarcode(string barcode)
        {
            try
            {
                using (AppData.dsTnbToBCartTableAdapters.M_商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.M_商品TableAdapter())
                using (dsTnbToBCart.M_商品DataTable dt = new dsTnbToBCart.M_商品DataTable())
                {
                    ta.FillByBarcode(dt, barcode);
                    if (dt.Rows.Count > 0)
                        return dt[0];
                }

            }
            catch (Exception ex)
            {
                Log.ErrWrite("SystemError!", ex);
                return null;
            }

            return null;
        }

        //private dsTnbToBCart.m

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                lblJyodai.Text = "";
                lblStock.Text = "";
                lblNoData.Visible = false;
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    return;
                }

                // バーコードから商品マスタを取得
                dsTnbToBCart.M_商品Row row = getProductsByBarcode(txtBarcode.Text);
                if (row == null)
                {
                    lblNoData.Visible=true;
                    lblNoData.Update();
                    MessageBox.Show("商品マスタにありません。");
                    return;
                }

                lblJyodai.Text = row.上代単価.ToString();
                using(AppData.dsTnbToBCartTableAdapters.vw商品在庫TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.vw商品在庫TableAdapter())
                using (dsTnbToBCart.vw商品在庫DataTable dt = new dsTnbToBCart.vw商品在庫DataTable())
                {
                    ta.FillByBarcode(dt, row.バーコード);
                    if (dt.Count > 0)
                    {
                        lblStock.Text = dt[0].数量.ToString();
                    }
                }


                // メーカー製品情報をセット
                setMakerProductInfo(txtBarcode.Text);
            }
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            // 入力チェック

            // セット名（必須）
            if (string.IsNullOrEmpty(txtSetName.Text))
            {
                MessageBox.Show("セット名は必須です。");
                return;
            }

            // バーコード（必須）
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("バーコードは必須です。");
                return;
            }

            // バーコードが商品マスタにあるか
            dsTnbToBCart.M_商品Row row = getProductsByBarcode(txtBarcode.Text);
            if (row == null)
            {
                MessageBox.Show("バーコードが商品マスタにありません。");
                return;
            }
            string tnb商品管理番号 = row.商品管理番号;

            using (Task.bcProductSetRegist t = new Task.bcProductSetRegist())
            {

                //追加または更新
                if (isAddSet)
                {
                    // 追加
                    if (!t.RegistNewSet(this.productsRow.基本_Bカート商品ID, txtSetName.Text, txtSetNo.Text, txtBarcode.Text, tnb商品管理番号))
                    {
                        MessageBox.Show("エラーが発生しました。\\n管理者に連絡してください。");
                        return;
                    }
                }
                else
                {
                    // 更新
                    if (!t.UpdateSet(this.productsRow.基本_Bカート商品ID, productsRow.セット_BカートセットID, txtSetName.Text, txtSetNo.Text, txtBarcode.Text, tnb商品管理番号))
                    {
                        MessageBox.Show("エラーが発生しました。\\n管理者に連絡してください。");
                        return;
                    }
                }

            }

            // 登録したら閉じる
            // 親画面の一覧をリロード
            this.DialogResult = DialogResult.OK;
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = "";
        }

        private void setMakerProductInfo(string barcode)
        {
            using (AppData.dsTnbToBCartTableAdapters.dt_メーカー商品情報TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.dt_メーカー商品情報TableAdapter())
            using (dsTnbToBCart.dt_メーカー商品情報DataTable dt = new dsTnbToBCart.dt_メーカー商品情報DataTable())
            {
                ta.FillByBarcode(dt, barcode);

                if (dt.Count > 0)
                {
                    var row = dt[0];

                    if (!row.Is商品セット名Null())
                        txtSetName.Text = row.商品セット名;
                    if (!row.Is品番Null())
                        txtSetNo.Text = row.品番;
                }
            }
        }

    }
}
