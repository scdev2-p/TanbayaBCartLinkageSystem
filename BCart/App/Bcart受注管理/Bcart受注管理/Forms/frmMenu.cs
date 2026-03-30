using Bcart受注管理.AppData;
using static Bcart受注管理.Forms.ViewBuilder;

namespace Bcart受注管理.Forms
{
    internal partial class frmMenu : frmBase
    {
        /// <summary>
        /// 子フォームが次に表示して欲しい画面を知らせるためのデリゲート
        /// メソッドへの参照型を定義します
        /// </summary>
        /// <param name="nextShowDialog">次に表示したい画面を示す列挙型</param>
        public delegate void NextShowDialogDelegate(NextShowDialog nextShowDialog);
        /// <summary>
        /// 子フォームが次に表示して欲しい画面を知らせるためのデリゲートの実体
        /// </summary>
        private readonly NextShowDialogDelegate SetNextShowDialogEvent;

        public frmMenu()
        {
            InitializeComponent();

            SetNextShowDialogEvent = new NextShowDialogDelegate(SetNextShowDialog);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(Settings.Default.RegistTnb)}={Settings.Default.RegistTnb}");

            if (Settings.Default.RegistTnb)
            {
                // 連携ON
                LblRegistTnb.Text = string.Empty;
            }
            else
            {
                // 連携OFF
                LblRegistTnb.Text = "基幹連携OFF";
            }

            this.lblVersion.Text = Settings.Default.Version;
            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblDeliPrinter.Text = Settings.Default.PrinterDevice;

            // 画面の解像度を取得
            using (Graphics g = this.CreateGraphics())
            {
                PublicData.DpiX = g.DpiX;
                PublicData.DpiY = g.DpiY;

                this.lblDpi.Text = "Dpi:" + g.DpiX.ToString();
            }

            Program.ScLogger.Info($"end");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 受注管理
            using (frmOderList fOrderList = new frmOderList(SetNextShowDialogEvent))
            {
                fOrderList.WindowState = FormWindowState.Maximized;
                fOrderList.ShowDialog();
                FireMenuClick(nextShowDialog);
            }
            Program.ScLogger.Info($"end");
        }

        private void btnPicking_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // ピッキング作業
            using (frmPickingWork fPic = new frmPickingWork(SetNextShowDialogEvent))
            {
                fPic.WindowState = FormWindowState.Maximized;
                fPic.ShowDialog();
                FireMenuClick(nextShowDialog);
            }
            Program.ScLogger.Info($"end");
        }

        private void btnSipping_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 出荷締め処理
            using (frmSippingList fSip = new frmSippingList())
            {
                fSip.WindowState = FormWindowState.Maximized;
                fSip.ShowDialog();
            }
            Program.ScLogger.Info($"end");
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 顧客登録
            using (frmUnregCustomer fPic = new frmUnregCustomer())
            {
                fPic.WindowState = FormWindowState.Maximized;
                fPic.ShowDialog();
            }
            Program.ScLogger.Info($"end");
        }

        private void btnChangePrinter_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // プリンター設定
            using (frmSelectPrinter fSelPrn = new frmSelectPrinter())
            {
                fSelPrn.ShowDialog();
                this.lblDeliPrinter.Text = Settings.Default.PrinterDevice;
            }
            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReloadOrder_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            using (frmReloadOrder fRel = new frmReloadOrder(SetNextShowDialogEvent))
            {
                fRel.WindowState = FormWindowState.Maximized;
                fRel.ShowDialog();
                FireMenuClick(nextShowDialog);
            }
            Program.ScLogger.Info($"end");
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }

        /// <summary>
        /// 次に表示する画面を指定します
        /// </summary>
        private NextShowDialog nextShowDialog = NextShowDialog.NONE;
        /// <summary>
        /// 起動したフォームから次に表示してほしい画面が書き込まれます
        /// 対象画面はBCart受注管理、ピッキング作業、BCart受注再取込です
        /// </summary>
        /// <param name="nextShowDialog"></param>
        private void SetNextShowDialog(NextShowDialog nextShowDialog)
        {
            Program.ScLogger.Info($"start before:{this.nextShowDialog} after:{nextShowDialog}");
            this.nextShowDialog = nextShowDialog;
        }
        /// <summary>
        /// 子フォームが閉じられた時に設定されている値によって次画面を表示します
        /// 処理時に次に表示して欲しい画面の設定値を初期化（NextShowDialog.NONE）します
        /// </summary>
        /// <param name="nextShowDialog">次に表示して欲しい画面を示す列挙型</param>
        /// <exception cref="NotImplementedException">対応する画面が未実装な場合は例外をスロー</exception>
        private void FireMenuClick(NextShowDialog nextShowDialog)
        {
            Program.ScLogger.Info($"start {nameof(nextShowDialog)}={nextShowDialog}");
            switch (nextShowDialog)
            {
                case NextShowDialog.NONE:
                    break;

                case NextShowDialog.OderList:
                    SetNextShowDialog(NextShowDialog.NONE);
                    btnOrder_Click(btnOrder, EventArgs.Empty);
                    break;

                case NextShowDialog.PickingWork:
                    SetNextShowDialog(NextShowDialog.NONE);
                    btnPicking_Click(btnPicking, EventArgs.Empty);
                    break;

                case NextShowDialog.ReloadOrder:
                    SetNextShowDialog(NextShowDialog.NONE);
                    btnReloadOrder_Click(btnReloadOrder, EventArgs.Empty);
                    break;

                case NextShowDialog.Reserved:
                    SetNextShowDialog(NextShowDialog.NONE);
                    btnReserved_Click(btnReserved, EventArgs.Empty);
                    break;
                default:
                    throw new NotImplementedException($"未実装なパラメータが指定されました。実際の値={nextShowDialog}");
            }
        }

        private void btnRegi_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 受注管理
            using (frmRegiList fRegiList = new frmRegiList())
            {
                fRegiList.WindowState = FormWindowState.Maximized;
                fRegiList.ShowDialog();
                FireMenuClick(nextShowDialog);
            }
            Program.ScLogger.Info($"end");
        }

        private void btnReserved_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 受注管理
            using (frmReserving fOrderList = new frmReserving(SetNextShowDialogEvent))
            {
                fOrderList.ShowDialog();
                FireMenuClick(nextShowDialog);
            }
            Program.ScLogger.Info($"end");
        }

        private void btnShippingInspection_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 出荷検品
            using (frmShippingInspection frm = new frmShippingInspection())
            {
                frm.WindowState = FormWindowState.Maximized; ;
                frm.ShowDialog();
            }
            Program.ScLogger.Info($"end");
        }

        private void btnProductImage_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 商品画像取込
            using (frmProductImgInport frm = new frmProductImgInport())
            {
                frm.ShowDialog();
            }
            Program.ScLogger.Info($"end");
        }
    }
}
