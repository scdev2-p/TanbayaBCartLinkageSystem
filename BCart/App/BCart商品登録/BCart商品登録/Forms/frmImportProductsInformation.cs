using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace BCart商品登録.Forms
{
    public partial class frmImportProductsInformation : Form
    {
        public frmImportProductsInformation()
        {
            InitializeComponent();
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = this.txtFileName.Text;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFileName.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtFileName.Text))
            {
                MessageBox.Show("インポートするファイルを指定してください。");
                return;
            }


            try
            {
                // Excelファイルを開く
                using (IXLWorkbook wb = new XLWorkbook(this.txtFileName.Text))
                {
                    using (AppData.dsTnbToBCartTableAdapters.dt_メーカー商品情報TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.dt_メーカー商品情報TableAdapter())
                    using (AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter qa = new AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter())
                    using (TransactionScope ts = new TransactionScope())
                    {
                        try
                        {
                            IXLWorksheet ws = wb.Worksheet(1);
                            int groupNo = (int)qa.GetNextImportGroupNo();
                            int rowNo = 3;
                            while (rowNo <= ws.LastRow().RowNumber())
                            {
                                // JAMコードが空白ならスキップ
                                if (!ws.Cell(rowNo, 1).IsEmpty())
                                {

                                    // データ取得
                                    string barcode = ws.Cell(rowNo, 9).GetString();
                                    string maker = (string)qa.GetMakerByBarcode(barcode);

                                    // Delete
                                    qa.DeleteMalerProductInfo(barcode);

                                    // Insert
                                    ta.Insert(
                                        groupNo,    // 取込グループNo
                                        DateTime.Now, // 取込日時
                                        maker, // メーカー
                                        ws.Cell(rowNo, 1).GetString(), // 商品番号
                                        ws.Cell(rowNo, 2).GetString(), // 商品名
                                        ws.Cell(rowNo, 3).GetString(), // ブランド
                                        ws.Cell(rowNo, 4).GetString(), // 生産地
                                        ws.Cell(rowNo, 5).GetString(), // サイズ
                                        ws.Cell(rowNo, 6).GetString(), // 素材
                                        ws.Cell(rowNo, 7).GetString(), // 説明
                                        ws.Cell(rowNo, 8).GetString(), // 注意事項
                                        ws.Cell(rowNo, 9).GetString(), // JANコード
                                        ws.Cell(rowNo, 10).GetString(), // 品番
                                        ws.Cell(rowNo, 11).GetString() // 商品セット名
                                    );
                                }
                                rowNo++;
                            }

                            ts.Complete();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("インポートが完了しました。");
        }
    }
}
