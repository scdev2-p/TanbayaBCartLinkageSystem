using BCartApi.Entity;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.AppData.Sql;
using System.Windows.Forms;

namespace Bcart受注管理.Forms
{
    public partial class frmReservedDetail : Form
    {
        /// <summary>
        /// ピッキング詳細の一覧の欠品チェックボックスの位置
        /// </summary>
        private const int COLINDEX_SHORTAGE_CHECK = 5;
        /// <summary>
        /// bc_Pickingテーブルのid
        /// コンストラクタからセット
        /// </summary>
        private string CustomerCode { get; set; }
        private string Payment { get; set; }
        private long ReservedID { get; set; }
        private string Picking { get; set; }
        private string Cutomername { get; set; }
        private string Reservestatus { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pickingID">bc_Pickingテーブルのid</param>
        public frmReservedDetail(long reservedID, string custoemrcode, string payment, string picking, string cusname, string reservestatus)
        {
            InitializeComponent();
            ReservedID = reservedID;
            CustomerCode = custoemrcode;
            Payment = payment;
            Picking = picking;
            Cutomername = cusname;
            Reservestatus = reservestatus;

        }

        private void frmReservedDetail_Load(object sender, EventArgs e)
        {
            LblCustomerCode.Text = CustomerCode;
            lblpaymat.Text = Payment;
            lblPikking.Text = Picking;
            lblCusname.Text = Cutomername;
            lblResevedStatus.Text = Reservestatus;
            splitContainer1.Panel1Collapsed = true;
            saerchReservedRank();
            saerchDetail();
        }

        //変数
        long orderid = 0;
        dsBCartLink.S_SearchReservedDetailDataTable dt;
        
        //一覧検索処理
        private void saerchDetail()
        {
            Program.ScLogger.Info($"start Load");

            using (AppData.Sql.sqlTnbBCart tnb = new AppData.Sql.sqlTnbBCart())
            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchReservedDetailTableAdapter srTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchReservedDetailTableAdapter())
            using (dt = new dsBCartLink.S_SearchReservedDetailDataTable())
            {
                // 取置明細の検索
                srTa.Fill(dt, ReservedID);
                this.bsBcartLink.DataSource = dt;
                orderid = long.Parse(dt.Rows[0]["order_id"].ToString());
            }

            Program.ScLogger.Info($"end Load");
        }

        //取り置きのランク検索
        private void saerchReservedRank()
        {
            Program.ScLogger.Info($"start Load");

            using (AppData.Sql.sqlTnbBCart tnb = new AppData.Sql.sqlTnbBCart())
            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchReservedRankTableAdapter srTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchReservedRankTableAdapter())
            using (dsBCartLink.S_SearchReservedRankDataTable rrdt = new dsBCartLink.S_SearchReservedRankDataTable())
            {
                srTa.Fill(rrdt, ReservedID);
                if (rrdt.Count >= 2)
                {
                    splitContainer1.Panel1Collapsed = false;
                    rankGridview.Visible = true;
                    this.bsBcartLink2.DataSource = rrdt;
                }
                
            }

            Program.ScLogger.Info($"end Load");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.Close();
            Program.ScLogger.Info($"end");
        }

        // 取置をW_レジに登録する
        private void button1_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            
            // この受注のレジ伝票明細がすでに存在するかチェック
            using var checkRegistedRegOrderTa = new AppData.Ds.dsBCartLinkTableAdapters.S_CheckRegistedRegOrderTableAdapter();
            using var checkRegistedRegOrderDt = new dsBCartLink.S_CheckRegistedRegOrderDataTable();
            checkRegistedRegOrderTa.Fill(checkRegistedRegOrderDt, orderid);

            if (checkRegistedRegOrderDt.Any())
            {
                if (MessageBox.Show($"{checkRegistedRegOrderDt[0].カード番号} {checkRegistedRegOrderDt[0].顧客名}は別の支払方法でレジに事前登録されています。\nよろしいですか？。", "取置登録 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    Program.ScLogger.Info($"end レジ伝票明細登録あり キャンセルクリック");
                    return;
                }
            }

            //ピッキングチェック
            if (lblPikking.Text.Equals("未"))
            {
                if (MessageBox.Show($"ピッキングが済んでいない商品があります。\nよろしいでしょうか？", "取置登録 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    Program.ScLogger.Info($"end ピッキングが済んでいない キャンセルクリック");
                    return;
                }
            }
            // 操作ログ記載
            string machinname = Environment.MachineName;
            using AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter bco = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter();
            bco.Insert_bcOperationLog(DateTime.Now, machinname, "取り置きレジ登録", "Reserved_id:" + ReservedID);
            // ランクを基幹とBCARTで比較
            using var checkRankTa = new AppData.Ds.dsBCartLinkTableAdapters.S_CheckOrderRankChangedTableAdapter();
            using var checkRankDt = new dsBCartLink.S_CheckOrderRankChangedDataTable();
            checkRankTa.Fill(checkRankDt, ReservedID);
            if (checkRankDt.Count >= 1)
            {
                if (MessageBox.Show($"顧客ランクが変更されています。\nBカート：{checkRankDt[0].tnb_rank_name} → 基幹：{checkRankDt[0].bc_rank_name}\nレジに登録してよろしいですか？", "取置登録 明細", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    Program.ScLogger.Info($"end 顧客ランクに差異あり キャンセルクリック");
                    return;
                }
            }

            using (sqlTnbBCart sqlBc = new sqlTnbBCart())
            // 基幹のレジに登録してしまうので本番環境で実行する時はスキップさせる
            if (Settings.Default.RegistTnb)
            {
                // 基幹のw_レジ伝票明細の登録
                // ストアドプロシージャ S_MakeRegiDetail orderID
                if (!sqlBc.MakeRegiByReserved(ReservedID))
                {
                    MessageBox.Show("基幹のw_レジ伝票明細の登録でエラーが発生しました。");
                    Program.ScLogger.Info($"{nameof(orderid)}={orderid},\"基幹のw_レジ伝票明細の登録でエラーが発生しました。\"");
                    return;
                }
                //再検索
                saerchDetail();
            }

            // Bカート受注の顧客情報よりe飛伝用のcsvファイルに書き込み
            if (!OrderCustomerAddress.WriteSagawaCsvFromReserved(ReservedID))
            {
                MessageBox.Show("佐川用住所を出力できませんでした。");
            }

            MessageBox.Show("登録しました。", "取置更新");
            // 画面を閉じる
            DialogResult = DialogResult.OK;
            this.Close();
            Program.ScLogger.Info($"end");
        }
    }
}
