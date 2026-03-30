using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.AppData.Sql;
using Bcart受注管理.Models;
using Bcart受注管理.Services;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bcart受注管理.Forms
{
    /// <summary>
    /// ピッキング一覧のフォーム
    /// </summary>
    public partial class frmPickingWorkDetail : Form
    {
        /// <summary>
        /// ピッキング詳細の一覧の欠品チェックボックスの位置
        /// </summary>
        private const int COLINDEX_SHORTAGE_CHECK = 5;
        /// <summary>
        /// bc_Pickingテーブルのid
        /// コンストラクタからセット
        /// </summary>
        private long PickingID { get; set; }
        private long OrderID { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pickingID">bc_Pickingテーブルのid</param>
        public frmPickingWorkDetail(long pickingID)
        {
            InitializeComponent();
            PickingID = pickingID;
        }

        private void frmPickingWorkDetail_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(this.PickingID)}={this.PickingID}");

            {
                this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
                this.lblTitle.Text = "ピッキング作業 明細";

                using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter pickingTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter())
                using (dsBCartLink.S_SearchPickingDataTable dt = new dsBCartLink.S_SearchPickingDataTable())
                using (AppData.Ds.dsBCartLinkTableAdapters.bc_PickingWorkDetailTableAdapter pkwdTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingWorkDetailTableAdapter())
                using (AppData.Ds.dsBCartLink.bc_PickingWorkDetailDataTable pkwdDt = new AppData.Ds.dsBCartLink.bc_PickingWorkDetailDataTable())
                {
                    // 受注の検索
                    pickingTa.Fill(dt,
                        this.PickingID,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null);
                    this.bsBcartLink.DataSource = dt;

                    OrderID = dt[0].order_id;

                    // ピッキング詳細
                    pkwdTa.Fill(pkwdDt, this.PickingID);
                    this.bcPickingDetailBindingSource.DataSource = pkwdDt;

                    // 欠品チェック反映
                    foreach (DataGridViewRow row in this.dgvDetailList.Rows)
                    {
                        var dbRow = (dsBCartLink.bc_PickingWorkDetailRow)((System.Data.DataRowView)row.DataBoundItem).Row;
                        if (dbRow.shortage == 1)
                        {
                            row.Cells[COLINDEX_SHORTAGE_CHECK].Value = true;
                        }
                    }
                }
            }

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            DialogResult = DialogResult.Cancel;
            this.Close();
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// ピッキング済にするボタンのクリックイベントハンドラー
        /// 受注及び受注明細をピッキング済みに更新します
        /// 欠品のチェックが入っている明細については、その個数を基幹システムとBCartに反映します
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnDoPicked_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(Settings.Default.RegistTnb)}={Settings.Default.RegistTnb}");

            // 機能追加（TANBAYA-334 20240712）
            // orderIdでレジ伝票明細データを取得
            using var checkRegistedRegOrderTa = new AppData.Ds.dsBCartLinkTableAdapters.S_CheckRegistedRegOrderTableAdapter();
            using var checkRegistedRegOrderDt = new dsBCartLink.S_CheckRegistedRegOrderDataTable();
            checkRegistedRegOrderTa.Fill(checkRegistedRegOrderDt, OrderID);

            // 明細を取得した場合はその趣旨をメッセージで表示。
            if (checkRegistedRegOrderDt.Any())
            {
                if (MessageBox.Show($"{checkRegistedRegOrderDt[0].カード番号} {checkRegistedRegOrderDt[0].顧客名} {checkRegistedRegOrderDt[0].伝票年月日}は既にレジに事前登録した受注があります。\n実行してもよろしいですか？", "ピッキング作業 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    Program.ScLogger.Info($"end レジ伝票明細登録あり キャンセルクリック");
                    return;
                }
            } else if (MessageBox.Show("ピッキング済に更新します。\nよろしいですか？", "ピッキング作業 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                Program.ScLogger.Info($"end レジ伝票なし　キャンセルクリック");
                return;
            }

            //操作ログ記載
            string machinname = Environment.MachineName;
            using AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter bco = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter();
            bco.Insert_bcOperationLog(DateTime.Now, machinname, "ピッキング済み", "Picking_id::" + PickingID);

            // ピッキングのピッキング状態を「済」に更新
            using var pickingTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingTableAdapter();
            using var pickingDt = new dsBCartLink.bc_PickingDataTable();
            UpdatePickingStatusToPicked(pickingTa, pickingDt, PickingID);

            // ピッキング詳細のピッキング状態を「済」に更新
            // ピッキング詳細の欠品を「欠品」に更新
            using var pickingDetailTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter();
            using var pickingDetailDt = new dsBCartLink.bc_PickingDetailDataTable();
            var shortagePickingIDList = new List<long>();
            
            foreach (DataGridViewRow row in this.dgvDetailList.Rows)
            {
                var shortage = 0;
                var dbRow = (dsBCartLink.bc_PickingWorkDetailRow)((System.Data.DataRowView)row.DataBoundItem).Row;
                if (ViewBuilder.GetCheckedFromDataGridViewRow(row, COLINDEX_SHORTAGE_CHECK))
                {
                    // 欠品へ更新
                    shortage = 1;
                }
                // ピッキング済へ更新
                UpdatePickingDetailStatusToPicked(pickingDetailTa, pickingDetailDt, dbRow.picking_detail_id, shortage);
            }

            using var searchPickingDetailTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingDetailTableAdapter();
            using var searchPickingDetailDt = new dsBCartLink.S_SearchPickingDetailDataTable();
            var orderId = (long)(LblOrderCode.Tag ?? 0);
            searchPickingDetailTa.Fill(searchPickingDetailDt, orderId, 0, null);

            if(searchPickingDetailDt.Count ==0)
            {
                // 受注のステータスを「ピック済」に更新
                using var orderTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter();
                using var orderDt = new dsBCartLink.bc_OrderDataTable();
                UpdateOrderToPicked(orderTa, orderDt, orderId);

                // 受注ステータスのピッキングステータスを「1」に更新
                using var orderStatusTa = new AppData.Ds.dsBCartLink2TableAdapters.bc_OrderStatusTableAdapter();
                using var orderStatusDt = new dsBCartLink2.bc_OrderStatusDataTable();
                UpdateOrderStatusToPicked(orderStatusTa, orderStatusDt, orderId);

                // 欠品が無かった場合
                searchPickingDetailTa.Fill(searchPickingDetailDt, orderId, null, 1);
                if (searchPickingDetailDt.Count == 0)
                {
                    using var sqlBc = new sqlTnbBCart();
                    // 基幹のレジに登録してしまうので本番環境で実行する時はスキップさせる
                    if (Settings.Default.RegistTnb)
                    {
                        //操作ログ記載
                        bco.Insert_bcOperationLog(DateTime.Now, machinname, "ピッキング済レジ登録", "Picking_id::" + PickingID);

                        // 基幹のw_レジ伝票明細の登録
                        // ストアドプロシージャ S_MakeRegiDetail orderID
                        if (!sqlBc.MakeRegiDetail(orderId))
                        {
                            MessageBox.Show("基幹のw_レジ伝票明細の登録でエラーが発生しました。");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("基幹連携機能解除中のためレジ伝票明細の登録をスキップします。");
                    }

                    // Bカート受注の顧客情報よりe飛伝用のcsvファイルに書き込み
                    if(!OrderCustomerAddress.WriteSagawaCsvFromOrder(orderId))
                    {
                        MessageBox.Show("佐川用住所を出力できませんでした。");
                    }

                }
                else
                {
                    Program.ScLogger.Info($"欠品有り");
                }
            }
            else
            {
                Program.ScLogger.Info($"未ピッキング有");
            }
            MessageBox.Show("ピック済みにしました。", "ピッキング更新");


            // 閉じる
            DialogResult = DialogResult.OK;
            this.Close();

            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// 受注のステータスを「ピック済」に更新します
        /// </summary>
        /// <param name="ta">bc_Orderのデータアダプター</param>
        /// <param name="dt">bc_Orderのデータテーブル</param>
        /// <param name="orderId">bc_Orderのid値</param>
        private static void UpdateOrderToPicked(AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter ta, dsBCartLink.bc_OrderDataTable dt, long orderId)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");
            ta.FillByOrderID(dt, orderId);

            Program.ScLogger.Info($"before {nameof(dt.statusColumn)}={dt[0].status}");
            dt[0].status = Consts.OrderStatus[(int)Consts.OrderStatusIndex.Picked];
            Program.ScLogger.Info($"after {nameof(dt.statusColumn)}={dt[0].status}");

            ta.Update(dt);
        }

        /// <summary>
        /// 受注ステータスのピッキングステータスを「1」に更新します
        /// </summary>
        /// <param name="ta">bc_OrderStatusのデータアダプター</param>
        /// <param name="dt">bc_OrderStatusのデータテーブル</param>
        /// <param name="orderId">bc_Orderのid値</param>
        private static void UpdateOrderStatusToPicked(AppData.Ds.dsBCartLink2TableAdapters.bc_OrderStatusTableAdapter ta, dsBCartLink2.bc_OrderStatusDataTable dt, long orderId)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");
            ta.FillByOrderId(dt, orderId);

            Program.ScLogger.Info($"before {nameof(dt.exist_pickingColumn)}={dt[0].exist_picking}");
            dt[0].exist_picking = 1;
            Program.ScLogger.Info($"after {nameof(dt.exist_pickingColumn)}={dt[0].exist_picking}");

            ta.Update(dt);
        }

        /// <summary>
        /// ピッキングのピッキング状態を「済」に更新します
        /// </summary>
        /// <param name="ta">bc_Pickingのデータアダプター</param>
        /// <param name="dt">bc_Pickingのデータテーブル</param>
        /// <param name="pickingId">bc_Pickingのid値</param>
        private static void UpdatePickingStatusToPicked(AppData.Ds.dsBCartLinkTableAdapters.bc_PickingTableAdapter ta, dsBCartLink.bc_PickingDataTable dt, long pickingId)
        {
            Program.ScLogger.Info($"start {nameof(pickingId)}={pickingId}");
            ta.FillByPickingID(dt, pickingId);

            Program.ScLogger.Info($"before {nameof(dt.picking_statusColumn)}={dt[0].picking_status}");
            dt[0].picking_status = 1;
            Program.ScLogger.Info($"after {nameof(dt.picking_statusColumn)}={dt[0].picking_status}");

            ta.Update(dt);
        }

        /// <summary>
        /// ピッキング詳細のピッキング状態を「済」に更新します
        /// </summary>
        /// <param name="ta">bc_PickingDetailのデータアダプター</param>
        /// <param name="dt">bc_PickingDetailのデータテーブル</param>
        /// <param name="pickingDetailId">bc_PickingDetailのid値</param>
        /// <param name="shortage">欠品フラグ。初期値は0。</param>
        private static void UpdatePickingDetailStatusToPicked(AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter ta, dsBCartLink.bc_PickingDetailDataTable dt, long pickingDetailId, int shortage = 0)
        {
            Program.ScLogger.Info($"start {nameof(pickingDetailId)}={pickingDetailId}, {nameof(shortage)}={shortage}");
            ta.FillById(dt, pickingDetailId);

            Program.ScLogger.Info($"before {nameof(dt.picking_statusColumn)}={dt[0].picking_status}, {nameof(dt.shortageColumn)}={dt[0].shortage}");
            dt[0].picking_status = 1;
            dt[0].shortage = shortage;
            Program.ScLogger.Info($"before {nameof(dt.picking_statusColumn)}={dt[0].picking_status}, {nameof(dt.shortageColumn)}={dt[0].shortage}");

            ta.Update(dt);
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmPickingWorkDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }
    }
}
