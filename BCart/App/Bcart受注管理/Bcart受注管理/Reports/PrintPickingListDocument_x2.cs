using System.Drawing.Printing;
using Bcart受注管理.AppData;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Metrics;
using System.Diagnostics.Eventing.Reader;
using Bcart受注管理.Forms;
using System.Text.RegularExpressions;
using Bcart受注管理.Utils;


namespace Bcart受注管理.Reports
{
    /// <summary>
    /// ピッキングリスト
    /// </summary>
    internal class PrintPickingListDocument_x2 : PrintDocument
    {
        #region "定数"
        /// <summary>
        /// ヘッダー部の1列目のX位置
        /// </summary>
        private const int HEADER_X_1 = 10;
        /// <summary>
        /// ヘッダー部の2列目のX位置
        /// </summary>
        private const int HEADER_X_2 = 230;
        /// <summary>
        /// ヘッダー部の3列目のX位置
        /// </summary>
        private const int HEADER_X_3 = 460;
        /// <summary>
        /// 明細部の1列目のX位置
        /// </summary>
        private const int DETAIL_X_1 = 10;

        /// <summary>
        /// ヘッダー部の1行目のY位置
        /// </summary>
        private const int HEADER_Y_1 = 10;
        /// <summary>
        /// ヘッダー部の2行目のY位置
        /// </summary>
        private const int HEADER_Y_2 = 38;
        /// <summary>
        /// ヘッダー部の3行目のY位置
        /// </summary>
        private const int HEADER_Y_3 = 66;
        /// <summary>
        /// ヘッダー部の4行目のY位置
        /// </summary>
        private const int HEADER_Y_4 = 86;
        /// <summary>
        /// ヘッダー部の5行目のY位置
        /// </summary>
        private const int HEADER_Y_5 = 106;
        /// <summary>
        /// ヘッダー部の6行目のY位置
        /// </summary>
        private const int HEADER_Y_6 = 126;

        /// <summary>
        /// ヘッダー部の高さ
        /// </summary>
        private const int HEADER_HEIGHT = 150;
        /// <summary>
        /// 1ページに印刷する最大明細数
        /// 0からカウントするのでPAGE_ITEM_MAX_NUM + 1 件の明細を印刷します
        /// </summary>
        private const int PAGE_MAX_ITEM_INDEX = 8;
        /// <summary>
        /// 1明細の高さ
        /// 1明細2行のレイアウトなので2行分の高さ
        /// </summary>
        private const int LINE_HEIGHT = 110;

        /// <summary>
        /// 明細部の1行あたりのすべて全角文字の場合の文字数
        /// </summary>
        private const int CHAR_LENGTH_PER_LINE = 46;
        /// <summary>
        /// お客様からの連絡事項の最大文字数
        /// </summary>
        private const int MAX_CUSTOMER_MESSAGE_LENGTH = 1000;
        /// <summary>
        /// お客様からの連絡事項の印字幅
        /// </summary>
        private const int CUSTOMER_MESSAGE_WIDTH = 760;
        #endregion

        #region "インスタンス変数"
        /// <summary>
        /// 印刷対象となるピッキングIDリスト
        /// </summary>
        private List<long> _reportIdList { get; set; }
        private Single _dpiX;
        private Single _dpiY;
        /// <summary>
        /// 現在印刷する対象となっているレコード位置
        /// データセットの行位置
        /// </summary>
        private int _currentRowIdx;
        /// <summary>
        /// /現在印刷しているピッキングIDのインデックス
        /// </summary>
        private int _currentPickingIdx;
        /// <summary>
        /// 現在印刷しているページ数
        /// </summary>
        private int _pageCnt;
        /// <summary>
        /// 総ページ数
        /// </summary>
        private int _totalPageCount;

        private AppData.Ds.dsBCartLinkTableAdapters.bc_PickingFloorCountTableAdapter? _pkFcTa;
        private AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter? _pkdTa;
        private AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter? _pkdTa2;
        private AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter? _odTa;
        private AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter? _odTa2;
        private AppData.Ds.dsBCartLinkTableAdapters.M_商品TableAdapter? _tsTa;
        private AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsTableAdapter? _odpTa;
        private AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter? _sspTa;
        private AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter? _sspTa2;
        private AppData.Ds.dsTnbTableAdapters.T_取置TableAdapter? _countTa;
        private AppData.Ds.dsBCartLink.bc_PickingDetailDataTable? _pkdDt;
        private AppData.Ds.dsBCartLink.bc_PickingDetailDataTable? _pkdDt2;
        private AppData.Ds.dsBCartLink.bc_OrderDataTable? _odDt;
        private AppData.Ds.dsBCartLink.bc_OrderDataTable? _odDt2;
        private AppData.Ds.dsBCartLink.M_商品DataTable? _tsDt;
        private AppData.Ds.dsBCartLink.bc_OrderProductsDataTable? _odpDt;
        private AppData.Ds.dsBCartLink.bc_PickingFloorCountDataTable? _pkFcDt;
        private AppData.Ds.dsBCartLink.S_SearchPickingDataTable? _sspDt;
        private AppData.Ds.dsBCartLink.S_SearchPickingDataTable? _sspDt2;
        private AppData.Ds.dsTnb.T_取置DataTable? _countDt;

        /// <summary>
        /// 大き目フォント
        /// </summary>
        private readonly Font _largeFont;
        /// <summary>
        /// 大き目フォント
        /// </summary>
        private readonly Font _largeFont2;
        /// <summary>
        /// デフォルトフォント
        /// </summary>
        private readonly Font _defFont;
        /// <summary>
        /// デフォルトフォント2
        /// </summary>
        private readonly Font _defFont2;
        /// <summary>
        /// デフォルトフォント3
        /// </summary>
        private readonly Font _defFont3;
        /// <summary>
        /// デフォルトフォント4
        /// </summary>
        private readonly Font _defFont4;
        /// <summary>
        /// デフォルトブラシ
        /// </summary>
        private readonly SolidBrush _defBrush;
        /// <summary>
        /// デフォルトペン
        /// </summary>
        private readonly Pen _defPen;
        /// <summary>
        /// フロア表作成用ペン
        /// </summary>
        private readonly Pen _defPen2;
        #endregion

        public PrintPickingListDocument_x2(long reportId)
        {
            this._reportIdList = new List<long> { reportId };

            this._dpiX = PublicData.DpiX;
            this._dpiY = PublicData.DpiY;

            _currentRowIdx = 0;
            _currentPickingIdx = 0;
            _pageCnt = 0;
            _totalPageCount = 0;

            _largeFont = new Font("メイリオ", 15.0F, FontStyle.Bold);
            _largeFont2 = new Font("メイリオ", 12.0F, FontStyle.Bold);
            _defFont = new Font("メイリオ", 14.0F);
            _defFont2 = new Font("メイリオ", 24.0F);
            _defFont3 = new Font("メイリオ", 11.0F);
            _defFont4 = new Font("メイリオ", 13.0F);
            _defBrush = new SolidBrush(Color.Black);
            _defPen = new Pen(Color.Black, 3);
            _defPen2 = new Pen(Color.Black, 1);

            this.BeginPrint += PrintPickingListDocument_BeginPrint;
            this.PrintPage += PrintPickingListDocument_PrintPage;
            this.EndPrint += PrintPickingListDocument_EndPrint;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="reportIdList">ピッキングIDのリスト</param>
        public PrintPickingListDocument_x2(List<long> reportIdList)
        {
            this._reportIdList = reportIdList;
            this._dpiX = PublicData.DpiX;
            this._dpiY = PublicData.DpiY;

            _currentRowIdx = 0;
            _currentPickingIdx = 0;
            _pageCnt = 0;
            _totalPageCount = 0;

            _largeFont = new Font("メイリオ", 15.0F, FontStyle.Bold);
            _largeFont2 = new Font("メイリオ", 12.0F, FontStyle.Bold);
            _defFont = new Font("メイリオ", 14.0F);
            _defFont2 = new Font("メイリオ", 24.0F);
            _defFont3 = new Font("メイリオ", 11.0F);
            _defFont4 = new Font("メイリオ", 13.0F);
            _defBrush = new SolidBrush(Color.Black);
            _defPen = new Pen(Color.Black, 3);
            _defPen2 = new Pen(Color.Black, 1);

            this.BeginPrint += PrintPickingListDocument_BeginPrint;
            this.PrintPage += PrintPickingListDocument_PrintPage;
            this.EndPrint += PrintPickingListDocument_EndPrint;
        }

        #region "イベントハンドラー"
        /// <summary>
        /// 印刷処理の開始前処理イベントハンドラー
        /// </summary>
        private void PrintPickingListDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            Program.ScLogger.Info("start");

            _pkFcTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingFloorCountTableAdapter();
            _pkdTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter();
            _pkdTa2 = new AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter();
            _odTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter();
            _odTa2 = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter();
            _tsTa = new AppData.Ds.dsBCartLinkTableAdapters.M_商品TableAdapter();
            _odpTa = new AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsTableAdapter();
            _sspTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter();
            _sspTa2 = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter();
            _countTa = new AppData.Ds.dsTnbTableAdapters.T_取置TableAdapter();
            _pkdDt = new AppData.Ds.dsBCartLink.bc_PickingDetailDataTable();
            _pkdDt2 = new AppData.Ds.dsBCartLink.bc_PickingDetailDataTable();
            _odDt = new AppData.Ds.dsBCartLink.bc_OrderDataTable();
            _odDt2 = new AppData.Ds.dsBCartLink.bc_OrderDataTable();
            _tsDt = new AppData.Ds.dsBCartLink.M_商品DataTable();
            _odpDt = new AppData.Ds.dsBCartLink.bc_OrderProductsDataTable();
            _pkFcDt = new AppData.Ds.dsBCartLink.bc_PickingFloorCountDataTable();
            _sspDt = new AppData.Ds.dsBCartLink.S_SearchPickingDataTable();
            _sspDt2 = new AppData.Ds.dsBCartLink.S_SearchPickingDataTable();
            _countDt = new AppData.Ds.dsTnb.T_取置DataTable();

            Program.ScLogger.Info("end");
        }

        /// <summary>
        /// 印刷処理後の処理イベントハンドラー
        /// </summary>
        private void PrintPickingListDocument_EndPrint(object sender, PrintEventArgs e)
        {
            Program.ScLogger.Info("start");
            XscDispose();
            Program.ScLogger.Info("end");
        }

        /// <summary>
        /// ページ印刷処理のイベントハンドラー
        /// 複数のピッキングIDの印刷制御を行います。
        /// 印刷を継続する場合はHasMorePagesにtrueをセットします。印刷を終了する場合はfalseをセットします。
        /// DrawPage関数がfalseを返してきた場合は、未印刷のピッキングIDがあれば印刷を継続し、存在しない場合は印刷を終了します。
        /// DrawPage関数がtrueを返してきた場合は、DrawPage関数内でのセット内容に従います。
        /// </summary>
        private void PrintPickingListDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(_reportIdList)}={string.Join(",", _reportIdList)}");

            try
            {
                // ページ数加算
                _pageCnt += 1;

                // 仕様変更のため不要
                //if (_pageCnt == 1)
                //{
                //    // 総ページを計算します
                //    (_totalPageCount, _) = CalcTotalPageCount(_reportIdList, e);
                //}

                long picking_id = _reportIdList[_currentPickingIdx];
                if (this.DrawPage(picking_id, e))
                {
                    // 同じピッキングIDで印刷を継続
                    e.HasMorePages = true;
                }
                else
                {
                    // ページ数初期化
                    _pageCnt = 0;

                    if (_currentPickingIdx == _reportIdList.Count - 1)
                    {
                        // 最後のレポートであれば改ページ終了
                        e.HasMorePages = false;
                    }
                    else
                    {
                        // 改ページ
                        e.HasMorePages = true;
                        _currentPickingIdx++;
                        _currentRowIdx = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error("チェックリストの印刷処理に失敗しました");
                Program.ScLogger.Error(ex);
                XscDispose();
                throw;
            }

            Program.ScLogger.Info("end");
        }
        #endregion

        #region "インスタンス関数"
        /// <summary>
        /// 1ページ分の印刷処理
        /// </summary>
        /// <param name="picking_id">印刷対象のピッキングID</param>
        /// <param name="e">プリントページイベントパラメータ</param>
        /// <returns>印刷対象のピッキングIDのデータが全て印刷済みならfalse。まだ残りがあるならtrue。</returns>
        /// <exception cref="Exception"></exception>
        private bool DrawPage(long picking_id, PrintPageEventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(picking_id)}={picking_id}");

            // null許容型を外す
            if (_pkFcTa is null) throw new NullReferenceException($"{nameof(_pkFcTa)}がnull参照です");
            if (_pkdTa is null) throw new NullReferenceException($"{nameof(_pkdTa)}がnull参照です");
            if (_odTa is null) throw new NullReferenceException($"{nameof(_odTa)}がnull参照です");
            if (_odpTa is null) throw new NullReferenceException($"{nameof(_odpTa)}がnull参照です");
            if (_tsTa is null) throw new NullReferenceException($"{nameof(_tsTa)}がnull参照です");
            if (_sspTa is null) throw new NullReferenceException($"{nameof(_sspTa)}がnull参照です");
            if (_countTa is null) throw new NullReferenceException($"{nameof(_countTa)}がnull参照です");
            if (_pkdDt is null) throw new NullReferenceException($"{nameof(_pkdDt)}がnull参照です");
            if (_odDt is null) throw new NullReferenceException($"{nameof(_odDt)}がnull参照です");
            if (_odpDt is null) throw new NullReferenceException($"{nameof(_odpDt)}がnull参照です");
            if (_tsDt is null) throw new NullReferenceException($"{nameof(_tsDt)}がnull参照です");
            if (_pkFcDt is null) throw new NullReferenceException($"{nameof(_pkFcDt)}がnull参照です");
            if (_sspDt is null) throw new NullReferenceException($"{nameof(_sspDt)}がnull参照です");
            if (_countDt is null) throw new NullReferenceException($"{nameof(_countDt)}がnull参照です");
            if (e.Graphics is null) throw new NullReferenceException($"{nameof(e.Graphics)}がnull参照です");


            // ピッキング情報（出荷情報含む）
            var pkRow = GetSSearchPickingDetailRowByPickingId(picking_id, _sspTa, _sspDt);
            // 受注情報の取得
            var odRow = GetBcOrderRowByOrderID(picking_id, pkRow.order_id, _odTa, _odDt);
            // 同オーダーの別フロアのフロア情報を取得
            _pkFcTa.Fill(_pkFcDt, pkRow.order_id);
            // 取置有無
            var existsTorioki = (int)_countTa.ReserveCount(odRow.customer_ext_id) > 0;
            // カウンター
            int pageItemCnt = 0;
            // 総ページ数
            int totalPage = 0;
            // 画像ファイルフォルダ
            string productImagePath = Settings.Default.ProductImagePath;
            string productImageFile = "";

            // ====================================================================================
            // 明細出力

            // ピッキング明細の取得
            FillPickingDetailDatasByPickingId(picking_id, _pkdTa, _pkdDt);

            // 同じオーダー内に別フロア商品がある場合、そのピッキングIDとフロアを取得
            var (pickingIdList, pickingFloorList) = GetSomeOrderFloor(_pkFcDt);



            for (; _currentRowIdx < _pkdDt.Count; _currentRowIdx++)
            {
                var pkdRow = _pkdDt[_currentRowIdx];

                // 受注明細の取得
                var odpRow = GetBcOrderProductsRowByOrderProductId(pkdRow.order_products_id, picking_id, pkRow.order_id, _odpTa, _odpDt);
                // 上代取得
                var jodai = odpRow.Isproduct_set_customs1Null() || string.IsNullOrEmpty(odpRow.product_set_customs1) ? "" : FillByProductSetCustom1(odpRow.product_set_customs1, _tsTa, _tsDt).ToString();

                // ページ内で最初の行であればヘッダー部を出力
                if (pageItemCnt == 0)
                {
                    // ヘッダー出力
                    // ページ数取得
                    var (totalPageCount, totalPageBreakDown) = CalcTotalPageCount(pickingIdList, e);

                    // このピッキングリストの合計枚数を取得
                    var thisFloor = 0;
                    for (int i = 0; i < pickingIdList.Count; i++)
                    {
                        if (pickingIdList[i] == picking_id)
                        {
                            totalPage = (int)totalPageBreakDown[i];
                            thisFloor = int.Parse(pickingFloorList[i]);
                        }
                    }

                    // 1行目：顧客コード＋顧客名
                    e.Graphics.DrawString($"顧客：{odRow.customer_customs3}  {odRow.customer_comp_name}", _largeFont, _defBrush, new PointF(HEADER_X_1, HEADER_Y_1));

                    // 2行目：取置有無＋配送希望日
                    var torioki = existsTorioki ? "有り" : "無し";
                    var kiboubi = $"{pkRow.due_date} {pkRow.due_time}";
                    if (string.IsNullOrWhiteSpace(kiboubi))
                    {
                        kiboubi = "無し";
                    }

                    e.Graphics.DrawString($"HD取置登録：{torioki}", _largeFont2, _defBrush, new PointF(HEADER_X_1, HEADER_Y_2));
                    e.Graphics.DrawString($"配送希望日：{kiboubi}", _largeFont2, _defBrush, new PointF(HEADER_X_2, HEADER_Y_2));

                    // 3行目：ピッキング番号＋フロア
                    string pickingCode = pkRow.picking_code;
                    e.Graphics.DrawString($"ﾋﾟｯｷﾝｸﾞ番号:{pickingCode}", _defFont3, _defBrush, new PointF(HEADER_X_1, HEADER_Y_3));
                    e.Graphics.DrawString($"ﾍﾟｰｼﾞ:{_pageCnt}/{totalPage}枚", _defFont3, _defBrush, new PointF(HEADER_X_2, HEADER_Y_3));

                    // 4行目：受注番号＋決済方法
                    e.Graphics.DrawString($"受注番号:{odRow.order_code}", _defFont3, _defBrush, new PointF(HEADER_X_1, HEADER_Y_4));
                    e.Graphics.DrawString($"受注日:{odRow.ordered_at.ToString("MM/dd HH:mm")}", _defFont3, _defBrush, new PointF(HEADER_X_2, HEADER_Y_4));

                    // 5行目：顧客管理番号
                    var payment = ViewBuilder.GetPaymentText(odRow.payment);
                    e.Graphics.DrawString($"顧客管理番号:{odRow.customer_ext_id}", _defFont3, _defBrush, new PointF(HEADER_X_1, HEADER_Y_5));
                    e.Graphics.DrawString($"決済方法:{payment}", _defFont3, _defBrush, new PointF(HEADER_X_2, HEADER_Y_5));

                    // 6行目：お客様からの連絡事項
                    var existsCustomerMessage = ExistsCustomerMessage(odRow.customer_message);
                    var headerCustomerMessage = "無し";
                    var customerMessage = string.Empty;
                    if (existsCustomerMessage)
                    {
                        // メッセージ有り
                        // 改行置換＋文字数調整
                        (customerMessage, var isOverflow) = AdjustmentLength(ReplaceNewlinesWithEmpty(odRow.customer_message), MAX_CUSTOMER_MESSAGE_LENGTH);
                        headerCustomerMessage = "有り" + (isOverflow ? "(桁数超過のため全文はBCartでご確認ください)" : string.Empty);
                    }
                    e.Graphics.DrawString($"お客様からの連絡事項:{headerCustomerMessage}", _defFont3, _defBrush, new PointF(HEADER_X_1, HEADER_Y_6));

                    // フロアごとの枚数と合計の表を作成
                    // 枠線
                    // 横
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 - 60, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 150, HEADER_Y_3 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 - 60, HEADER_Y_4 + 3), new Point(HEADER_X_3 + 150, HEADER_Y_4 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 - 60, HEADER_Y_5 + 3), new Point(HEADER_X_3 + 150, HEADER_Y_5 + 3));
                    // 縦
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 - 60, HEADER_Y_3 + 3), new Point(HEADER_X_3 - 60, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 - 30, HEADER_Y_3 + 3), new Point(HEADER_X_3 - 30, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3, HEADER_Y_3 + 3), new Point(HEADER_X_3, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 + 30, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 30, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 + 60, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 60, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 + 90, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 90, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 + 120, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 120, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 + 150, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 150, HEADER_Y_5 + 3));
                    e.Graphics.DrawLine(_defPen2, new Point(HEADER_X_3 + 180, HEADER_Y_3 + 3), new Point(HEADER_X_3 + 180, HEADER_Y_5 + 3));

                    // フロア表記
                    e.Graphics.DrawString($"1F 2F 3F 4F 5課 営 計\n", _defFont4, _defBrush, new PointF(HEADER_X_3 - 60, HEADER_Y_3));
                    // フロアごとの枚数
                    int allFloorTotalPage = 0;
                    for (int i = 1; i <= 6; i++)
                    {
                        for (int j = 0; j < pickingFloorList.Count; j++)
                        {
                            if (pickingFloorList[j] == i.ToString())
                            {
                                e.Graphics.DrawString($"{totalPageBreakDown[j]}", _defFont, _defBrush, new PointF(HEADER_X_3 - 60 + i * 30 - 24, HEADER_Y_4));
                                allFloorTotalPage += (int)totalPageBreakDown[j];
                                if (thisFloor == i)
                                {
                                    e.Graphics.DrawString("〇", _defFont2, _defBrush, new PointF(HEADER_X_3 - 60 + i * 30 - 37, HEADER_Y_3 - 9));
                                }
                            }
                        }
                    }
                    // 合計
                    e.Graphics.DrawString($"{allFloorTotalPage}", _defFont, _defBrush, new PointF(HEADER_X_3 + 125, HEADER_Y_4));

                    if (existsCustomerMessage && _currentRowIdx == 0)
                    {
                        // ピッキングIDで取得したデータセットの初回ループの場合
                        var customerMessageRectangleF = BuildRectangleF(e.Graphics, customerMessage, _defFont, CUSTOMER_MESSAGE_WIDTH, DETAIL_X_1, CalcRowY(0));
                        e.Graphics.DrawString(customerMessage, _defFont, _defBrush, customerMessageRectangleF);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(customerMessageRectangleF));

                        pageItemCnt = CalcNextPageItemCntFromHeight(e.Graphics, _defFont, customerMessageRectangleF.Height);
                    }

                    // ページ右上：ピッキングバーコード＋顧客コードバーコード
                    try
                    {
                        string picBarcode = Barcode.ToJAN13(pickingCode);
                        e.Graphics.DrawImage(Barcode.MakeBarcodeImage(picBarcode, 160, 52), new PointF(620, 10));
                    }
                    catch (Exception)
                    {
                        Program.ScLogger.Info("ピッキングバーコードでエラー");
                    }

                    try
                    {
                        string kokyaCodeBarcode = Barcode.GetCreateBarcodeFromKokyakuCD(odRow.customer_customs3.ToString());
                        // 社員の場合はスキップ
                        if (!Regex.IsMatch(kokyaCodeBarcode, "^\\]"))
                        {
                            e.Graphics.DrawImage(Barcode.MakeBarcodeImage(kokyaCodeBarcode, 160, 52), new PointF(620, 60));
                        }
                    }
                    catch (Exception)
                    {
                        Program.ScLogger.Info("顧客コードバーコードでエラー");
                    }

                }


                // 明細の行座標はpageItemCntから計算
                int rowY = CalcRowY(pageItemCnt);
                if (_pageCnt == 1 )
                    rowY -= 60;

                // 区切り線
                e.Graphics.DrawLine(_defPen, new Point(10, rowY), new Point(790, rowY));

                // 商品番号
                e.Graphics.DrawString(odpRow.product_no, _defFont3, _defBrush, new PointF(30, rowY));

                // 上代
                //e.Graphics.DrawString($"上代：{jodai}円", _defFont, _defBrush, new PointF(340, rowY));
                e.Graphics.DrawString($"上代：{jodai}円", _defFont3, _defBrush, new PointF(285, rowY));

                // バーコード
                try
                {
                    var ProductPicBarcode = odpRow.Isproduct_set_customs1Null() || string.IsNullOrEmpty(odpRow.product_set_customs1) ? "" : Barcode.ToJAN13(odpRow.product_set_customs1);
                    //e.Graphics.DrawImage(Barcode.MakeBarcodeImage(ProductPicBarcode, 160, 33), new PointF(615, rowY + 3));
                    e.Graphics.DrawImage(Barcode.MakeBarcodeImage(ProductPicBarcode, 160, 33), new PointF(515, rowY + 3));
                }
                catch (Exception)
                {
                    Program.ScLogger.Info("商品コードバーコードでエラー");
                }

                // 商品名
                e.Graphics.DrawString(odpRow.product_name, _defFont3, _defBrush, new PointF(30, rowY + 30));

                // 個数
                string opCnt = string.Format("{0:#,0}", odpRow.order_pro_count);
                //e.Graphics.DrawString(opCnt, _defFont, _defBrush, new PointF(548 - (opCnt.Length * 12), rowY));
                //e.Graphics.DrawString("個", _defFont, _defBrush, new PointF(560, rowY));
                e.Graphics.DrawString(opCnt, _defFont3, _defBrush, new PointF(468 - (opCnt.Length * 11), rowY));
                e.Graphics.DrawString("個", _defFont3, _defBrush, new PointF(473, rowY));
                // 商品画像
                try
                {
                    foreach (var file in Directory.GetFiles(productImagePath, $"{odpRow.product_set_customs1}.*", SearchOption.TopDirectoryOnly))
                    {
                        if (Path.GetExtension(file).ToLower() == ".webp")
                        {
                            // WebPは対応できない
                            var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                            byte[] bs = new byte[fs.Length];
                            fs.Read(bs, 0, bs.Length);
                            fs.Close();
                            fs.Dispose();
                            var img = Dynamicweb.WebP.Decoder.Decode(bs);
                            e.Graphics.DrawImage(imgEf(img), new RectangleF(677, rowY + 3, 100, 100));
                        }
                        else
                        {
                            try
                            {
                                e.Graphics.DrawImage(imgEf(Image.FromFile(file)), new RectangleF(677, rowY + 3, 100, 100));
                            }
                            catch { }
                        }

                        // 最初に見つかったファイルをセット
                        break;
                    }

                }
                catch (Exception ex)
                {
                    Program.ScLogger.Info($"商品画像でエラー {odpRow.product_set_customs1}");
                }

                // 改ページの判定
                if (pageItemCnt != 0 && pageItemCnt % PAGE_MAX_ITEM_INDEX == 0 && _currentRowIdx + 1 < _pkdDt.Count)
                {
                    // 改ページ
                    e.HasMorePages = true;
                    _currentRowIdx++;
                    return true;
                }
                else
                {
                    e.HasMorePages = false;
                    pageItemCnt++;
                }

            }
            // ====================================================================================


            return false;
        }

        /// <summary>
        /// Imageの変換
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private Image imgEf(Image img)
        {
            // 彩度を上げる
            return ImageUtil.AdjustContrast(ImageUtil.ChangeSaturation(img, 1), -2);
        }


        /// <summary>
        /// 総ページ数を計算します
        /// </summary>
        /// <param name="reportIdList">ピッキングIDのリスト</param>
        /// <param name="e">印刷用オブジェクト</param>
        /// <returns>総ページ数＋内訳リスト</returns>
        private (int, List<long>) CalcTotalPageCount(List<long> reportIdList, PrintPageEventArgs e)
        {
            Program.ScLogger.Info($"start");

            // null許容型を外す
            if (_pkdTa2 is null) throw new NullReferenceException($"{nameof(_pkdTa2)}がnull参照です");
            if (_odTa2 is null) throw new NullReferenceException($"{nameof(_odTa2)}がnull参照です");
            if (_sspTa2 is null) throw new NullReferenceException($"{nameof(_sspTa2)}がnull参照です");
            if (_pkdDt2 is null) throw new NullReferenceException($"{nameof(_pkdDt2)}がnull参照です");
            if (_odDt2 is null) throw new NullReferenceException($"{nameof(_odDt2)}がnull参照です");
            if (_sspDt2 is null) throw new NullReferenceException($"{nameof(_sspDt2)}がnull参照です");
            if (e.Graphics is null) throw new NullReferenceException($"{nameof(e.Graphics)}がnull参照です");

            var totalPageCount = 0;
            var totalPageBreakDown = new List<long>();

            reportIdList.ForEach(pickingId =>
            {
                var pageItemCnt = 0;

                // お客様からの連絡事項による高さ
                // ピッキング情報（出荷情報含む）
                var pkRow = GetSSearchPickingDetailRowByPickingId(pickingId, _sspTa2, _sspDt2);
                // 受注情報の取得
                var odRow = GetBcOrderRowByOrderID(pickingId, pkRow.order_id, _odTa2, _odDt2);

                // お客様からの連絡事項
                var existsCustomerMessage = ExistsCustomerMessage(odRow.customer_message);
                if (existsCustomerMessage)
                {
                    // メッセージ有り
                    // 改行置換＋文字数調整
                    (var customerMessage, _) = AdjustmentLength(ReplaceNewlinesWithEmpty(odRow.customer_message), MAX_CUSTOMER_MESSAGE_LENGTH);
                    // 印字領域取得
                    var customerMessageRectangleF = BuildRectangleF(e.Graphics, customerMessage, _defFont, CUSTOMER_MESSAGE_WIDTH, DETAIL_X_1, CalcRowY(0));
                    // 印字位置を進める
                    pageItemCnt = CalcNextPageItemCntFromHeight(e.Graphics, _defFont, customerMessageRectangleF.Height);
                }

                // ピッキングリストに印字する明細数を加算
                // ピッキング明細の取得
                FillPickingDetailDatasByPickingId(pickingId, _pkdTa2, _pkdDt2);
                if (_pkdDt2.Count > 0)
                {
                    // 加算前のpageItemCntは次に印刷するインデックス値になっているので
                    // 明細が1件の場合はそのインデックスが最終インデックスとなるので、件数-1を加算します
                    pageItemCnt += _pkdDt2.Count - 1;
                }

                // pageItemCntから必要なページ数を計算する
                if (pageItemCnt == 0)
                {
                    totalPageCount = 1;
                    totalPageBreakDown.Add(1);
                }
                else
                {
                    var addPageCount = (int)Math.Ceiling(((double)pageItemCnt + 1) / ((double)PAGE_MAX_ITEM_INDEX + 1));
                    totalPageBreakDown.Add(addPageCount);
                    totalPageCount = addPageCount;
                }
            });

            Program.ScLogger.Info($"end {nameof(totalPageCount)}={totalPageCount}");
            return (totalPageCount, totalPageBreakDown);
        }

        /// <summary>
        /// DBオブジェクトの破棄
        /// </summary>
        private void XscDispose()
        {
            Program.ScLogger.Info($"start");

            try
            {
                // データテーブルの破棄
                ExecuteXsdDispose(() => _pkdDt?.Dispose());
                ExecuteXsdDispose(() => _pkdDt2?.Dispose());
                ExecuteXsdDispose(() => _odDt?.Dispose());
                ExecuteXsdDispose(() => _odDt2?.Dispose());
                ExecuteXsdDispose(() => _odpDt?.Dispose());
                ExecuteXsdDispose(() => _pkFcDt?.Dispose());
                ExecuteXsdDispose(() => _sspDt?.Dispose());
                ExecuteXsdDispose(() => _sspDt2?.Dispose());
                ExecuteXsdDispose(() => _countDt?.Dispose());

                // データアダプターの破棄
                ExecuteXsdDispose(() => _pkFcTa?.Dispose());
                ExecuteXsdDispose(() => _pkdTa?.Dispose());
                ExecuteXsdDispose(() => _pkdTa2?.Dispose());
                ExecuteXsdDispose(() => _odTa?.Dispose());
                ExecuteXsdDispose(() => _odTa2?.Dispose());
                ExecuteXsdDispose(() => _odpTa?.Dispose());
                ExecuteXsdDispose(() => _sspTa?.Dispose());
                ExecuteXsdDispose(() => _sspTa2?.Dispose());
                ExecuteXsdDispose(() => _countTa?.Dispose());
            }
            catch (Exception)
            {
                Program.ScLogger.Info("DB関連オブジェクトの破棄に失敗しました");
            }
        }
        #endregion

        #region "クラス関数"
        #region "DB関係"
        /// <summary>
        /// S_SearchPickingストアドプロシージャをピッキングIDを条件に実行します
        /// </summary>
        /// <param name="pickingId">抽出条件とするピッキングID</param>
        /// <param name="sspTa">S_SearchPickingストアドプロシージャのテーブルアダプター</param>
        /// <param name="sspDt">S_SearchPickingストアドプロシージャのデータテーブル</param>
        /// <returns>S_SearchPickingストアドプロシージャの結果</returns>
        /// <exception cref="Exception">情報が取得できなかった場合は例外をスロー</exception>
        private static AppData.Ds.dsBCartLink.S_SearchPickingRow GetSSearchPickingDetailRowByPickingId(long pickingId, AppData.Ds.dsBCartLinkTableAdapters.S_SearchPickingTableAdapter sspTa, AppData.Ds.dsBCartLink.S_SearchPickingDataTable sspDt)
        {
            Program.ScLogger.Info($"start {nameof(pickingId)}={pickingId}");

            sspTa.Fill(sspDt, pickingId, null, null, null, null, null, null, null, null, null, null, null);
            if (sspDt.Count == 0)
                // データ取得エラー
                throw new Exception("ピッキング情報が取得できませんでした(S_SearchPicking):" + pickingId.ToString());

            return sspDt[0];
        }

        /// <summary>
        /// bc_Orderからorder_idを条件に受注情報を取得します
        /// </summary>
        /// <param name="pickingId">ピッキングID（ログ出力用）</param>
        /// <param name="orderId">抽出対象の受注ID</param>
        /// <param name="odTa">bc_Orderのテーブルアダプター</param>
        /// <param name="odDt">bc_Orderのデータテーブル</param>
        /// <returns>受注情報</returns>
        /// <exception cref="Exception">受注情報が取得できなかった場合は例外をスロー</exception>
        private static AppData.Ds.dsBCartLink.bc_OrderRow GetBcOrderRowByOrderID(long pickingId, long orderId, AppData.Ds.dsBCartLinkTableAdapters.bc_OrderTableAdapter odTa, AppData.Ds.dsBCartLink.bc_OrderDataTable odDt)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");

            odTa.FillByOrderID(odDt, orderId);
            if (odDt.Count == 0)
                // データ取得エラー
                throw new Exception("受注情報が取得できませんでした:" + pickingId.ToString() + ":" + orderId.ToString());

            return odDt[0];
        }

        /// <summary>
        /// ピッキング詳細情報をピッキングIDを条件に取得します
        /// </summary>
        /// <param name="pickingId">抽出条件とするピッキングID</param>
        /// <param name="pkdTa">bc_PickingDetailのテーブルアダプター</param>
        /// <param name="pkdDt">bc_PickingDetailのデータテーブル</param>
        /// <exception cref="Exception">ピッキング詳細情報が取得できなかった場合は例外をスロー</exception>
        private static void FillPickingDetailDatasByPickingId(long pickingId, AppData.Ds.dsBCartLinkTableAdapters.bc_PickingDetailTableAdapter pkdTa, AppData.Ds.dsBCartLink.bc_PickingDetailDataTable pkdDt)
        {
            Program.ScLogger.Info($"start {nameof(pickingId)}={pickingId}");

            pkdTa.FillByPickingID(pkdDt, pickingId);
            if (pkdDt.Count == 0)
                // データ取得エラー
                throw new Exception("ピッキング明細が取得できませんでした:" + pickingId.ToString());
        }

        /// <summary>
        /// ピッキングリストの明細に記載する上代を取得
        /// bc_OrderProductのxsdでjoinできなかったためこちらで取得
        /// </summary>
        /// <param name="productSetCustom1">条件となるセット_カスタム項目1</param>
        /// <param name="tsTa">bc登録済商品のテーブルアダプター</param>
        /// <param name="tsDt">bc登録済商品のデータテーブル</param>
        /// <exception cref="Exception"></exception>
        private static string FillByProductSetCustom1(string productSetCustom1, AppData.Ds.dsBCartLinkTableAdapters.M_商品TableAdapter tsTa, AppData.Ds.dsBCartLink.M_商品DataTable tsDt)
        {
            Program.ScLogger.Info($"start {nameof(productSetCustom1)}={productSetCustom1}");

            tsTa.Fill(tsDt, productSetCustom1);
            if (tsDt.Count == 0)
            {
                return "";
            }


            return tsDt[0].上代単価.ToString();
        }

        // 受注IDを条件にピッキング情報を取得
        private static AppData.Ds.dsBCartLink.bc_PickingDataTable FillPickingDatasByOrderId(long orderId, AppData.Ds.dsBCartLinkTableAdapters.bc_PickingTableAdapter pkTa, AppData.Ds.dsBCartLink.bc_PickingDataTable pkDt)
        {
            Program.ScLogger.Info($"start {nameof(orderId)}={orderId}");
            pkTa.FillBy(pkDt, orderId);

            if (pkDt.Count == 0)
                // データ取得エラー
                throw new Exception("ピッキング明細が取得できませんでした:" + orderId.ToString());
            return pkDt;
        }

        /// <summary>
        /// 受注明細を受注明細IDを条件に取得します
        /// </summary>
        /// <param name="orderProductsId">抽出条件とする受注明細ID</param>
        /// <param name="pickingId">ピッキングID（ログ出力用）</param>
        /// <param name="orderId">受注ID（ログ出力用）</param>
        /// <param name="odpTa">bc_OrderProductsのテーブルアダプター</param>
        /// <param name="odpDt">bc_OrderProductsのデータテーブル</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static AppData.Ds.dsBCartLink.bc_OrderProductsRow GetBcOrderProductsRowByOrderProductId(long orderProductsId, long pickingId, long orderId, AppData.Ds.dsBCartLinkTableAdapters.bc_OrderProductsTableAdapter odpTa, AppData.Ds.dsBCartLink.bc_OrderProductsDataTable odpDt)
        {
            Program.ScLogger.Info($"start {nameof(orderProductsId)}={orderProductsId}");

            odpTa.FillByOrderProductID(odpDt, orderProductsId);
            if (odpDt.Count == 0)
                // データ取得エラー
                throw new Exception("受注商品情報が取得できませんでした:" + pickingId.ToString() + ":" + orderId.ToString() + ":" + orderProductsId);

            return odpDt[0];
        }
        #endregion

        /// <summary>
        /// 複数フロアーをカンマ区切りで結合します
        /// ピッキングidのリストを返します
        /// </summary>
        /// <param name="pkFcDt">bc_Pickingのデータテーブル</param>
        /// <returns>
        /// item1 = 複数フロアーの場合はそれをカンマ区切りにした文字列を返します。１フロアーのみの場合は空文字を返します。
        /// item2 = ピッキングidのリスト
        /// item3 = フロアーのリスト
        /// </returns>
        private static (List<long>, List<string>) GetSomeOrderFloor(AppData.Ds.dsBCartLink.bc_PickingFloorCountDataTable pkFcDt)
        {
            Program.ScLogger.Info($"start {nameof(pkFcDt.Count)}={pkFcDt.Count}");

            var pickingIdList = new List<long>();
            var pickingFloorList = new List<string>();
            // var someOrderFloor = string.Empty;
            if (pkFcDt.Count > 0)
            {
                foreach (DataRow row in pkFcDt.Rows)
                {
                    foreach (DataColumn column in pkFcDt.Columns)
                    {
                        if (column.ColumnName == "floor")
                        {
                            if (row[column].Equals("9")) row[column] = "6";
                            pickingFloorList.Add((string)row[column]);
                        }
                        else if (column.ColumnName == "picking_id")
                        {
                            pickingIdList.Add((long)row[column]);

                        }

                    }
                }
                // someOrderFloor = someOrderFloor.Substring(0, someOrderFloor.Length - 1) + ")";
            }

            // Program.ScLogger.Info($"emd {nameof(someOrderFloor)}={someOrderFloor}");
            return (pickingIdList, pickingFloorList);
        }

        /// <summary>
        /// お客様からの連絡事項が有る場合はtrueを返します。それ以外はfalseを返します。
        /// </summary>
        /// <param name="customerMessage">お客様からの連絡事項</param>
        /// <returns>設定有りならtrue。なければfalse。</returns>
        private static bool ExistsCustomerMessage(string? customerMessage)
        {
            Program.ScLogger.Info($"start {nameof(customerMessage)}={customerMessage}");
            return !string.IsNullOrWhiteSpace(customerMessage);
        }

        /// <summary>
        /// 改行を空白文字に置換します
        /// </summary>
        /// <param name="value">置換対象の文字列</param>
        /// <returns>置換後の文字列</returns>
        private static string ReplaceNewlinesWithEmpty(string value)
        {
            Program.ScLogger.Info($"start {nameof(value)}={value}");
            return value.Replace(Environment.NewLine, string.Empty) ?? string.Empty;
        }

        /// <summary>
        /// 最大桁数のチェック結果を返します
        /// </summary>
        /// <param name="value">テスト対象の文字列</param>
        /// <param name="maxLength">最大文字列</param>
        /// <returns></returns>
        private static bool IsOverflow(string value, int maxLength)
        {
            Program.ScLogger.Info($"start {nameof(value)}={value}, {nameof(maxLength)}={maxLength}");
            return value.Length > maxLength;
        }

        /// <summary>
        /// 文字数を最大桁数までに調整します。
        /// 調整後の文字列と超過有無を示す真偽値のタプルを返します。
        /// 最大桁数を超過している場合は最大桁数まで文字列を切り取って、そこから末尾３文字切り取って、残った文字列の末尾に「...」を付加した文字列を返します。
        /// </summary>
        /// <param name="value">処理対象の文字列</param>
        /// <param name="maxLength">最大桁数</param>
        /// <returns>調整後の文字列、超過ならtrue。以外ならfalseのタプル</returns>
        private static (string, bool) AdjustmentLength(string value, int maxLength)
        {
            Program.ScLogger.Info($"start {nameof(value)}={value}, {nameof(maxLength)}={maxLength}");
            if (IsOverflow(value, maxLength))
            {
                return (value[..(maxLength - 3)] + "...", true);
            }
            return (value, false);
        }

        /// <summary>
        /// 指定された幅で、指定された文字列を端で折り返して印字した時に得られる四角形を返します
        /// </summary>
        /// <param name="graphics">描画用オブジェクト</param>
        /// <param name="value">印字する文字列</param>
        /// <param name="font">フォント</param>
        /// <param name="width">文字列を印字する領域の幅</param>
        /// <param name="x">描画するテキストの左上隅のX座標</param>
        /// <param name="y">描画するテキストの左上隅のY座標</param>
        /// <returns>RectangleFオブジェクト</returns>
        private static RectangleF BuildRectangleF(Graphics graphics, string value, Font font, int width, float x, float y)
        {
            Program.ScLogger.Info($"start {nameof(value)}={value}, {nameof(width)}={width}, {nameof(x)}={x}, {nameof(y)}={y}");
            var stringSize = graphics.MeasureString(value, font, width);
            return new RectangleF(x, y, width, stringSize.Height);
        }

        /// <summary>
        /// 印字する明細のインデックスに対応するY方向の印字開始位置を計算します
        /// </summary>
        /// <param name="pageItemCnt">計算対象の明細のインデックス</param>
        /// <param name="headerHeight">ヘッダー高さ。初期値は定数HEADER_HEIGHT。</param>
        /// <param name="lineHeight">行間。初期値は定数LINE_HEIGHT。</param>
        /// <returns>Y方向の印字開始位置</returns>
        private static int CalcRowY(int pageItemCnt, int headerHeight = HEADER_HEIGHT, int lineHeight = LINE_HEIGHT)
        {
            Program.ScLogger.Info($"start {nameof(pageItemCnt)}={pageItemCnt}, {nameof(headerHeight)}={headerHeight}, {nameof(lineHeight)}={lineHeight}");

            return headerHeight + (pageItemCnt * lineHeight);
        }

        /// <summary>
        /// 印字位置を決めるインデックスを指定された高さから逆算します。
        /// 指定された高さを超えるまで必要となるインデックス値を返します。
        /// 指定された高さ＝すでに印字済みの領域（ヘッダー高さを除く）として計算します。
        /// 条件を満たすインデックスがない場合は最大インデックスを返します。
        /// </summary>
        /// <param name="graphics">描画用オブジェクト</param>
        /// <param name="font">フォント</param>
        /// <param name="height">逆算対象の高さ</param>
        /// <returns>次に印字できるインデックス</returns>
        private static int CalcNextPageItemCntFromHeight(Graphics graphics, Font font, float height)
        {
            Program.ScLogger.Info($"start {nameof(height)}={height}");

            var stringSize = graphics.MeasureString(nameof(CalcNextPageItemCntFromHeight), font);
            for (var i = 0; i <= PAGE_MAX_ITEM_INDEX; i++)
            {
                // 単純な高さだけの比較をしたいのでヘッダー高さに0を指定
                if (height < CalcRowY(i, headerHeight: 0))
                {
                    Program.ScLogger.Info($"end {nameof(i)}={i}");
                    return i;
                }
            }

            // 異常値
            Program.ScLogger.Info($"end {nameof(PAGE_MAX_ITEM_INDEX)}={PAGE_MAX_ITEM_INDEX}");
            return PAGE_MAX_ITEM_INDEX;
        }

        /// <summary>
        /// 受け取ったAction型の関数を実行します。
        /// 例外発生時は隠蔽して処理を継続するため、DBオブジェクトのDispose関数の実行以外に使用しないでください。
        /// </summary>
        /// <param name="disposeFun">Dispose関数を実行する関数</param>
        private static void ExecuteXsdDispose(Action disposeFun)
        {
            Program.ScLogger.Info($"start");

            try
            {
                disposeFun();
            }
            catch (Exception)
            {
                Program.ScLogger.Info("DB関連オブジェクトの破棄に失敗しました");
            }
        }
        #endregion
    }
}
