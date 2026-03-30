using BCart商品登録.AppData;
using BCartApi;
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
    public partial class frmProductsDeleteTool : Form
    {
        public frmProductsDeleteTool(bool isProducts)
        {
            InitializeComponent();
            this.isProducts = isProducts;
        }

        private bool isProducts = true;

        private void frmProductsDeleteTool_Load(object sender, EventArgs e)
        {
            if (isProducts)
            {
                this.Text = "商品基本の削除";
                this.lblInputFile.Text = "削除するBカート商品IDのリスト";
                this.lblInfo1.Text = "連携用DBの商品に削除を設定し、";
            }
            else
            {
                this.Text = "商品セット情報の削除";
                this.lblInputFile.Text = "削除するBカートセットIDのリスト";
                this.lblInfo1.Text = "連携用DBの商品セットに削除を設定し、";
            }
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = this.txtInputFile.Text;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtInputFile.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnDoDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInputFile.Text))
            {
                MessageBox.Show("ファイルを指定してください。");
                return;
            }

            if (!File.Exists(this.txtInputFile.Text))
            {
                MessageBox.Show("指定したファイルがありません。");
                return;
            }

            saveFileDialog1.Title = "出力ファイルの指定";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string outputFile = saveFileDialog1.FileName;
            //if(File.Exists(outputFile) && MessageBox.Show("","上書き確認",MessageBoxButtons.OKCancel) != DialogResult.OK)
            //{
            //    return;
            //}

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない

            using (StreamReader sr = new StreamReader(this.txtInputFile.Text))
            using (StreamWriter sw = new StreamWriter(outputFile, false, System.Text.Encoding.GetEncoding("shift_jis")))
            using (SqlTnbToBCart sql = new SqlTnbToBCart())
            {
                if (isProducts)
                {
                    sw.WriteLine("削除フラグ,【基本】Bカート商品ID");
                }
                else
                {
                    sw.WriteLine("削除フラグ,【基本】Bカート商品ID,【セット】BカートセットID");
                }

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] tmp = line.Split(',');
                    if (!long.TryParse(tmp[0], out long id))
                        continue;

                    // Bカートに商品IDがあるか確認した方がよいか？


                    // 取込済商品に削除IDをセットする
                    if (isProducts)
                    {
                        sql.updateDeleteFlagByProducts(id);

                        sw.WriteLine("p," + id.ToString());
                    }
                    else
                    {
                        long productId = sql.GetProductsIDBySetID(id);
                        if ((productId != 0))
                        {
                            sql.updateDeleteFlagBySets(id);
                            sw.WriteLine(string.Format("s,{0},{1}", productId, id));
                        }
                        else
                        {
                            Log.Write("商品IDが不明なセット:" + id.ToString(), Log.Level.Warning);
                        }
                    }

                }

                sr.Close();
                sw.Close();
            }

            MessageBox.Show("商品csvを出力しました。\nBカートにインポートしてください。");

            System.Diagnostics.Process.Start("EXPLORER.EXE", @"/select,""" + outputFile + @"""");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
