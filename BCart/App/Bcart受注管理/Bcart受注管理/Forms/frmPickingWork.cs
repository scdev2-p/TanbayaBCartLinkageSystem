using BCartApi;
using BCartApi.Entity;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.Models;
using Bcart受注管理.Reports;
using Bcart受注管理.Utils;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using static Bcart受注管理.Forms.frmMenu;
using static Bcart受注管理.Forms.ViewBuilder;

namespace Bcart受注管理.Forms
{
    /// <summary>
    /// ピッキング一覧のフォーム
    /// </summary>
    internal partial class frmPickingWork : frmBase
    {

        //private PrintPickingListDocument pickDoc;

        /// <summary>
        /// 親フォームに次画面を知らせるためのデリゲート
        /// </summary>
        private event NextShowDialogDelegate SetNextShowDialogEvent;

        public frmPickingWork(NextShowDialogDelegate setNextShowDialogEvent)
        {
            InitializeComponent();

            this.SetNextShowDialogEvent = setNextShowDialogEvent;
        }

        private void frmPickingWork_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(Settings.Default.PrintPreview)}={Settings.Default.PrintPreview}");

            if (Settings.Default.PrintPreview)
            {
                // デバック用。プリントプレビューON。
                chkPreview.Visible = true;
                chkPreview.Enabled = true;
                chkPreview.Checked = true;
            }
            else
            {
                // デバック用。プリントプレビューOFF。
                chkPreview.Visible = false;
                chkPreview.Enabled = false;
                chkPreview.Checked = false;
            }

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "ピッキング一覧";

            // ステータスコンボの初期化
            ViewBuilder.BuildCmbStatus(cmbStatus);
            ViewBuilder.BuildCmbPickingStatus(cmbPickingStatus);

            // 検索条件初期値
            ViewBuilder.BuildDateSpan(dtOrderFrom, dtOrderTo);

            // 検索実行
            doSearchPicking();

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.Close();
            Program.ScLogger.Info($"end");
        }

        private void frmPickingWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.ScLogger.Info($"start");

            if (e.KeyChar == ControlChars.Cr)
            {
                e.Handled = true;

                // 検索条件にフォーカスがある場合は検索を再実行する
                if (this.dtOrderFrom.Focused
                    || this.dtOrderTo.Focused
                    || this.cmbStatus.Focused)
                {
                    doSearchPicking();
                }
            }
            else
            {
                //readbuff.Append(e.KeyChar);
            }

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// ピッキング一覧を検索します
        /// </summary>
        private void doSearchPicking()
        {
            Program.ScLogger.Info($"start {nameof(chkF1)}={chkF1.Checked}, {nameof(chkF2)}={chkF2.Checked}, {nameof(chkF3)}={chkF3.Checked}, {nameof(chkF4)}={chkF4.Checked}, {nameof(chkF5)}={chkF5.Checked}, {nameof(chkF9)}={chkF9.Checked}, {nameof(cmbStatus)}={ViewBuilder.GetSearchStatusLabel(cmbStatus)}, {nameof(chkRegiDate)}={chkRegiDate.Checked}, {nameof(dtOrderFrom)}={dtOrderFrom.Value}, {nameof(dtOrderTo)}={dtOrderTo.Value}, {nameof(cmbPickingStatus)}={ViewBuilder.GetSearchPickingStatusLabel(cmbPickingStatus)}");

            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter pickingTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter())
            using (dsBCartLink.S_SearchPickingDataTable dt = new dsBCartLink.S_SearchPickingDataTable())
            {

                // 受注の検索
                ViewBuilder.SetSearchTime(this.dtOrderFrom, this.dtOrderTo);
                pickingTa.Fill(dt,
                    null,
                    ViewBuilder.GetSearchPickingStatusLabel(cmbPickingStatus),
                    null,
                    this.chkF1.Checked ? 1 : null,
                    this.chkF2.Checked ? 1 : null,
                    this.chkF3.Checked ? 1 : null,
                    this.chkF4.Checked ? 1 : null,
                    this.chkF5.Checked ? 1 : null,
                    this.chkF9.Checked ? 1 : null,
                    ViewBuilder.GetSearchStatusLabel(cmbStatus),
                    this.chkRegiDate.Checked ? this.dtOrderFrom.Value : null,
                    this.chkRegiDate.Checked ? this.dtOrderTo.Value : null);
                this.bsBcartLink.DataSource = dt;

                // 総数取得
                this.lblCount.Text = string.Format("{0:#,0}件", dt.Count);
                Program.ScLogger.Info($"{nameof(lblCount)}={lblCount.Text}");
            }
            this.txtPickingCode.Focus();
        }

        private void dgvMainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.ScLogger.Info($"start");

            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "btnDetail")     // 詳細ボタンがクリックされた場合
            {
                // クリックされた行にバインドされているRowデータを取得（Picking）
                dsBCartLink.S_SearchPickingRow dbRow = (dsBCartLink.S_SearchPickingRow)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                long id = dbRow.picking_id;

                // 明細画面を開く
                var fOrderDEtail = new frmPickingWorkDetail(id);
                if (fOrderDEtail.ShowDialog() == DialogResult.OK)
                {
                    doSearchPicking();
                }
            }
            Program.ScLogger.Info($"end");
        }


        private void btnDeliverySlipPrint_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(chkPreview)}={chkPreview.Checked}");

            // ここでチェックされたデータを取得
            List<long> pickingIDList = new List<long>();
            foreach (DataGridViewRow row in this.dgvMainList.Rows)
            {
                if (ViewBuilder.GetCheckedFromDataGridViewRow(row, 0))
                {
                    // クリックされた行にバインドされているRowデータを取得（Picking）
                    dsBCartLink.S_SearchPickingRow dbRow = (dsBCartLink.S_SearchPickingRow)((System.Data.DataRowView)row.DataBoundItem).Row;
                    pickingIDList.Add(dbRow.picking_id);
                }
            }
            Program.ScLogger.Info($"{nameof(pickingIDList)}={string.Join(",", pickingIDList)}");

            if (pickingIDList.Count == 0)
            {
                MessageBox.Show("印刷対象が未選択です。", "ピッキングリスト印刷", MessageBoxButtons.OK);
                Program.ScLogger.Info($"end 対象未選択");
                return;
            }

            if (MessageBox.Show("選択されたピッキングリストを印刷します。\nよろしいですか？", "ピッキングリスト印刷", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                Program.ScLogger.Info($"end キャンセルクリック");
                return;
            }

            // 商品画像をダウンロードして保存
            //saveProductsImage(pickingIDList);


            // 印刷用ドキュメント
            try
            {
                //pickDoc = new PrintPickingListDocument_x2(pickingIDList);

                // プレビュー表示
                if (this.chkPreview.Checked)
                {
                    using (PrintPreviewDialog pd = new PrintPreviewDialog())
                    {
                        pd.PrintPreviewControl.Zoom = 0.75;
                        //pd.Document = pickDoc;
                        pd.Document = new PrintPickingListDocument(pickingIDList);
                        pd.ShowDialog();
                    }
                    return;
                }

                using (PrintDialog pd = new PrintDialog())
                {
                    //pd.Document = pickDoc;
                    //pd.Document = new PrintPickingListDocument_x2(pickingIDList[0]);        // dummy

                    if (pd.ShowDialog(this) == DialogResult.OK)
                    {
                        foreach(long pickId in pickingIDList)
                        {
                            // 印刷ドキュメント作成
                            var pickDoc = new PrintPickingListDocument(pickId);

                            // プリンタ名設定
                            pickDoc.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;

                            // 用紙設定  A4
                            foreach (PaperSize ps in pickDoc.PrinterSettings.PaperSizes)
                            {
                                if (ps.Kind == PaperKind.A4)
                                {
                                    pickDoc.DefaultPageSettings.PaperSize = ps;
                                    break;
                                }
                            }

                            // 用紙の向き  
                            pickDoc.DefaultPageSettings.Landscape = false;   // true:横  false:縦

                            // 片面印刷
                            //pickDoc.DefaultPageSettings.Duplex = Duplex.Simplex;

                            // 印刷実行
                            pickDoc.Print();

                            // 印刷済みに更新
                            using var pickingTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingTableAdapter();
                            using var pickingDa = new dsBCartLink.bc_PickingDataTable();
                            pickingIDList.ForEach(id =>
                            {
                                Debug.WriteLine(id);

                                pickingTa.FillByPickingID(pickingDa, id);

                                Program.ScLogger.Info($"{nameof(id)}={id}, before {nameof(pickingDa.copy_statusColumn)}={pickingDa[0].copy_status}");
                                pickingDa[0].copy_status = 1;
                                Program.ScLogger.Info($"{nameof(id)}={id}, after {nameof(pickingDa.copy_statusColumn)}={pickingDa[0].copy_status}");

                                pickingTa.Update(pickingDa);
                            });

                        }     // foreach

                        doSearchPicking();
                    }

                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("印刷ドキュメント作成エラー", ex);
                Program.ScLogger.Error(ex);
                MessageBox.Show("印刷に失敗しました。\n管理者に連絡してください。");
                return;
            }

            Program.ScLogger.Info($"end");
        }

        private void txtPickingCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(txtPickingCode)}={txtPickingCode.Text}");

            if (e.KeyChar == ControlChars.Cr)
            {
                e.Handled = true;

                string pickingCode = this.txtPickingCode.Text;
                if (pickingCode.Length > 12)
                    pickingCode = pickingCode.Substring(0, 12);

                long pickingID;
                using (AppData.Sql.sqlTnbBCart tnb = new AppData.Sql.sqlTnbBCart())
                {
                    pickingID = tnb.GetPickingIdByCOde(pickingCode);
                }

                if (pickingID >= 0)
                {
                    // 明細画面を開く
                    var fOrderDEtail = new frmPickingWorkDetail(pickingID);
                    if (fOrderDEtail.ShowDialog() == DialogResult.OK)
                    {
                        // 検索実行
                        doSearchPicking();
                    }
                    // ピッキング番号のテキストを初期化
                    txtPickingCode.Text = string.Empty;
                    // ピッキング番号にフォーカス
                    txtPickingCode.Focus();
                }
                else
                {
                    // 該当なし
                    // ピッキング番号のテキストを初期化
                    txtPickingCode.Text = string.Empty;
                    Interaction.Beep();     // VBのBeep
                }

            }
            else
            {
            }

            Program.ScLogger.Info($"end");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            doSearchPicking();
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmPickingWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.OderList);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// BCart受注再取込画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnReloadOrder_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.ReloadOrder);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// セルのフォーマットイベントハンドラー
        /// このイベントハンドラーのログは保存しません
        /// </summary>
        private void dgvMainList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            // セルの列を確認
            if (dgv.Columns[e.ColumnIndex].Name == "copystatusDataGridViewTextBoxColumn" && e.Value is string copyStatus)
            {
                // セルの値により、背景色を変更する
                // 済⇒未に状態が変わることはないのでelseは書かない
                if (copyStatus == "済")
                {
                    e.CellStyle.BackColor = Color.Gray;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        /// <summary>
        /// 取置一覧画面への移動ボタン
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnReserved_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");

            // 次画面を指定
            SetNextShowDialogEvent(NextShowDialog.Reserved);
            // 画面を閉じる
            this.Close();

            Program.ScLogger.Info($"end");
        }

        private string[] searchFiles;
        private bool ExistFile(string fname)
        {
            var file = Directory.GetFiles(Settings.Default.ProductImagePath, fname + ".*");
            if(file != null && file.Length > 0)
            {
                return true;
            }
            return false;
        }


        private void saveProductsImage(List<long> pickingIdList)
        {
            Dictionary<string, long> productIdList = new Dictionary<string, long>();
            string imageFolder = Settings.Default.ProductImagePath;


            // ピッキングIDリストからバーコードを取得
            using (AppData.Ds.dsBCartLink2TableAdapters.PickingDetailTableAdapter ta = new AppData.Ds.dsBCartLink2TableAdapters.PickingDetailTableAdapter())
            using (dsBCartLink2.PickingDetailDataTable dt = new dsBCartLink2.PickingDetailDataTable())
            {
                foreach (var pickingId in pickingIdList)
                {
                    ta.FillByPickingID(dt, pickingId);

                    foreach (var row in dt)
                    {
                        // 画像ファイルが無ければ取得対象
                        if (!productIdList.Keys.Contains(row.Barcode) && !ExistFile(row.Barcode))
                        {
                            // ダウンロード対象に追加
                            productIdList.Add(row.Barcode, row.product_id);
                        }
                    }
                }
            }

            // 不足している商品画像をダウンロード
            using (var api = new BCartApi.HttpApiCommon())
            using (var wc = new System.Net.WebClient())
            {
                List<long> downloadedProductIdList = new List<long>();  
                for (int i = 0; i < productIdList.Count; i++)
                {
                    if (i != 0 && i % 100 == 0)
                    {
                        downloadImage(api, wc, productIdList, downloadedProductIdList, imageFolder);

                        downloadedProductIdList.Clear();
                    }

                    if (!downloadedProductIdList.Contains(productIdList.ElementAt(i).Value))
                    {
                        downloadedProductIdList.Add(productIdList.ElementAt(i).Value);
                    }

                }

                if (downloadedProductIdList.Count > 0)
                {
                    downloadImage(api, wc, productIdList, downloadedProductIdList, imageFolder);
                }

            }
            
        }


        private void downloadImage(BCartApi.HttpApiCommon api, System.Net.WebClient wc, Dictionary<string, long> productIdList, List<long> downloadedProductIdList, string imageFolder)
        {
            // apiで商品の画像を取得
            ApiCommandParam[] prm = {
                        new ApiCommandParam("limit", "100"),
                        new ApiCommandParam("offset", "0"),
                        new ApiCommandParam("ids", string.Join(",",downloadedProductIdList.ToArray())),
                        new ApiCommandParam("fields", "id,image")
                        };

            var ret = api.GetListCommand<cProducts>("products", prm);
            if (ret == null || ret.products == null || ret.products.Count == 0)
            {
                Log.ErrWrite("商品取得エラー");
                return;
            }
            foreach (var product in ret.products)
            {
                // ダウンロード
                if (!string.IsNullOrEmpty(product.image))
                {
                    string barcode = "";
                    foreach (var kv in productIdList)
                    {
                        if (kv.Value == product.id)
                        {
                            barcode = kv.Key;
                            break;
                        }
                    }

                    string outPath = Path.Combine(imageFolder, barcode + Path.GetExtension(product.image));
                    try
                    {
                        wc.DownloadFile(product.image, outPath);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrWrite($"商品画像のダウンロードに失敗しました: {product.image}", ex);
                        return;
                    }
                }
            }

        }

    }
}
