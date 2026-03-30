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
    public partial class frmProductsImport : Form
    {
        public frmProductsImport()
        {
            InitializeComponent();
        }

        private void frmProductsImport_Load(object sender, EventArgs e)
        {

        }

        private void btnDoImport_Click(object sender, EventArgs e)
        {
            long idFrom = 0;
            long idTo = 0;


            // 入力チェック
            if (rdoIDRange.Checked)
            {
                // 範囲
                if(string.IsNullOrEmpty(txtIDRangeFrom.Text))
                {
                    MessageBox.Show("Bカート商品ID(From)を指定してください。");
                    txtIDRangeFrom.Focus();
                    return;
                }
                if(!long.TryParse(txtIDRangeFrom.Text, out idFrom))
                {
                    MessageBox.Show("Bカート商品ID(From)は数字で入力してください。");
                    txtIDRangeFrom.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtIDRangeTo.Text))
                {
                    MessageBox.Show("Bカート商品ID(To)を指定してください。");
                    txtIDRangeTo.Focus();
                    return;
                }
                if (!long.TryParse(txtIDRangeTo.Text, out idTo))
                {
                    MessageBox.Show("Bカート商品ID(To)は数字で入力してください。");
                    txtIDRangeTo.Focus();
                    return;
                }

                if(idFrom + 99 < idTo)
                {
                    MessageBox.Show("Bカート商品IDの範囲は100件以内にしてください。");
                    txtIDRangeTo.Focus();
                    return;
                }
            }
            else
            {
                // ID指定
                if (string.IsNullOrEmpty(txtIDOnlly.Text))
                {
                    MessageBox.Show("Bカート商品IDを指定してください。");
                    txtIDOnlly.Focus();
                    return;
                }
                if (!long.TryParse(txtIDOnlly.Text, out idFrom))
                {
                    MessageBox.Show("Bカート商品IDは数字で入力してください。");
                    txtIDOnlly.Focus();
                    return;
                }


            }

            if (MessageBox.Show("Bカートの商品情報を連携世用システムに取り込みます。\nよろしいですか？", "商品取込", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            // 取込実行
            using (Task.bcProductsImport t = new Task.bcProductsImport())
            {

                if (rdoIDRange.Checked)
                {
                    if (!t.ImportProductsByRange(idFrom, idTo, rdoOverrideON.Checked))
                    {
                        MessageBox.Show("エラーが発生しました。\n管理者に連絡してください。");
                        return;
                    }
                }
                else
                {
                    if(!t.ImportProductsByID(idFrom, rdoOverrideON.Checked))
                    {
                        MessageBox.Show("エラーが発生しました。\n管理者に連絡してください。");
                        return;

                    }
                }

                if (t.RegistCount == 0)
                {
                    MessageBox.Show("【注意】取り込まれた商品はありませんでした。");
                    return;
                }
                MessageBox.Show(string.Format("{0} 件のBカートの商品を連携用DBに取り込みました。",t.RegistCount));
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIDRangeFrom_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIDRangeFrom.Text) && string.IsNullOrEmpty(txtIDRangeTo.Text))
            {
                // Toが無ければ ＋99
                long idFrom = 0;
                if (long.TryParse(txtIDRangeFrom.Text, out idFrom))
                {
                    txtIDRangeTo.Text = (idFrom + 99).ToString();
                }
            }
        }
    }
}
