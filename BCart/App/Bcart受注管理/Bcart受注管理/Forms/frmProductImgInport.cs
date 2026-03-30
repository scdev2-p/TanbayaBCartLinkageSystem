using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcart受注管理.Forms
{
    internal partial class frmProductImgInport : frmBase
    {
        public frmProductImgInport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = txtCsvFileName.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCsvFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            string outputFolder = Settings.Default.ProductImagePath;
            if (string.IsNullOrEmpty(txtCsvFileName.Text))
            {
                MessageBox.Show("CSVファイルを指定してください。");
                return;
            }


            int maxCnt = getLineCount(txtCsvFileName.Text);

            lblWait.Text = $"取込中・・・(0/{maxCnt})";
            lblWait.Visible = true;
            lblWait.Update();

            using (StreamReader sr = new StreamReader(txtCsvFileName.Text))
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                string line;
                int cnt = 0;

                // 1行目を読み飛ばす
                if (sr.ReadLine() == null)
                    return;

                while ((line = sr.ReadLine()) != null)
                {
                    cnt++;
                    lblWait.Text = $"取込中・・・({cnt}/{maxCnt})";
                    lblWait.Update();


                    string[] parts = line.Split(',');
                    if (parts.Length < 4)
                    {
                        continue;
                    }
                    string imageUrl = parts[3].Replace("\"", "").Trim();
                    string barcode = parts[2].Replace("\"", "").Trim();

                    if (string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(barcode))
                    {
                        continue;
                    }

                    // バーコードからファイル名を作成
                    string outPath = Path.Combine(outputFolder, barcode + Path.GetExtension(imageUrl));


                    // 追加分のみの場合はファイルがあればスキップ
                    if (chkContinue.Checked && File.Exists(outPath))
                    {
                        continue;
                    }

                    // 画像をダウンロードして保存する。
                    // 失敗してもピッキングリストに出ないだけ。
                    try
                    {
                        wc.DownloadFile(imageUrl, outPath);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"画像のダウンロードに失敗しました: {imageUrl}\n{ex.Message}");
                    }
                }

                lblWait.Visible = false;

                MessageBox.Show("完了しました。");
            }
        }

        private void frmProductImgInport_Load(object sender, EventArgs e)
        {
            lblOutFolder.Text = Settings.Default.ProductImagePath;
            lblWait.Visible = false;

        }

        private int getLineCount(string filePath)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
