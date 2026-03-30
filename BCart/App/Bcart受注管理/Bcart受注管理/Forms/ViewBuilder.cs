using Bcart受注管理.AppData;

namespace Bcart受注管理.Forms
{
    /// <summary>
    /// ビューの各項目のビルダー
    /// </summary>
    internal class ViewBuilder
    {
        /// <summary>
        /// 次に表示するフォームを示します
        /// NONE：表示しない
        /// OderList：次に受注管理画面を表示します
        /// PickingWork：次にピッキング一覧画面を表示します
        /// ReloadOrder：次に受注再取込画面を表示します
        /// Reserved：次に取置一覧画面を表示します
        /// </summary>
        public enum NextShowDialog
        {
            NONE,
            OderList,
            PickingWork,
            ReloadOrder,
            Reserved,
        }

        /// <summary>
        /// ステータスのコンボボックスをビルドします
        /// </summary>
        /// <param name="cmb">ステータスのコンボボックス</param>
        /// <param name="selectIndex">初回選択するインデックス。初期値は１です。</param>
        public static void BuildCmbStatus(ComboBox cmbStatus, Consts.OrderStatusIndex selectIndex = Consts.OrderStatusIndex.NewOnly)
        {
            cmbStatus.Items.Clear();
            for (int i = 0; i < Consts.OrderStatus.Count; i++)
            {
                cmbStatus.Items.Add(Consts.OrderStatus[i]);
            }
            cmbStatus.SelectedIndex = (int)selectIndex;
        }

        /// <summary>
        /// ピッキングステータスのコンボボックスをビルドします
        /// </summary>
        /// <param name="cmbPickingStatus">ピッキングステータスのコンボボックス</param>
        /// <param name="selectIndex">初回選択するインデックス。初期値は１です。</param>
        public static void BuildCmbPickingStatus(ComboBox cmbPickingStatus, Consts.PickingStatusIndex selectIndex = Consts.PickingStatusIndex.UnprocessedOnly)
        {
            cmbPickingStatus.Items.Clear();
            for (int i = 0; i < Consts.PickingStatus.Count; i++)
            {
                cmbPickingStatus.Items.Add(Consts.PickingStatus[i]);
            }
            cmbPickingStatus.SelectedIndex = (int)selectIndex;
        }

        /// <summary>
        /// 日付範囲をセットします
        /// FROMは当日－1ヶ月、TOは当日をセットします
        /// </summary>
        /// <param name="from">FROM日付</param>
        /// <param name="to">TO日付</param>
        public static void BuildDateSpan(DateTimePicker from, DateTimePicker to)
        {
            from.Value = DateTime.Now.AddMonths(-1);
            to.Value = DateTime.Now;
        }

        /// <summary>
        /// 検索条件の日付期間で使用するDateTimePickerの時刻部分にFROMには0:0:0を、TOには23:59:59をセットします
        /// </summary>
        /// <param name="from">FROM日付</param>
        /// <param name="to">TO日付</param>
        public static void SetSearchTime(DateTimePicker from, DateTimePicker to)
        {
            from.Value = new DateTime(from.Value.Year, from.Value.Month, from.Value.Day, 0, 0, 0);
            to.Value = new DateTime(to.Value.Year, to.Value.Month, to.Value.Day, 23, 59, 59);
        }

        /// <summary>
        /// 検索用ステータスの文字列を返します
        /// ステータスが「(すべて)」の場合はnullを返します
        /// ステータスが「出荷完了以外」の場合は「(すべて)」と「出荷完了」と「出荷完了以外」以外のステータス文言をカンマ区切りにした文字列を返します
        /// クエリ側でSTRING_SPLIT関数を使って分解される想定です
        /// </summary>
        /// <param name="cmbStatus">検索用のステータスのコンボボックス</param>
        /// <returns>検索用の文字列</returns>
        /// <exception cref="ArgumentException">ステータスコンボ用の列挙対で未実装があれば例外をスローします</exception>
        public static string? GetSearchStatusLabel(ComboBox cmbStatus)
        {
            switch(cmbStatus.SelectedIndex)
            {
                case (int)Consts.OrderStatusIndex.All:
                    // (すべて)
                    return null;

                case (int)Consts.OrderStatusIndex.NewOnly:
                    // 新規注文
                case (int)Consts.OrderStatusIndex.Picked:
                    // ピック済
                case (int)Consts.OrderStatusIndex.ShippingCompleted:
                    // 出荷完了
                    return Consts.OrderStatus[cmbStatus.SelectedIndex];

                case (int)Consts.OrderStatusIndex.OtherThanShippingCompleted:
                    // 出荷完了以外
                    var tmp = new List<string>();
                    foreach (Consts.OrderStatusIndex value in Enum.GetValues(typeof(Consts.OrderStatusIndex)))
                    {
                        if (!value.Equals(Consts.OrderStatusIndex.All) && !value.Equals(Consts.OrderStatusIndex.ShippingCompleted) && !value.Equals(Consts.OrderStatusIndex.OtherThanShippingCompleted))
                        {
                            tmp.Add(Consts.OrderStatus[(int)value]);
                        }
                    }
                    return string.Join(",", tmp);

                default:
                    throw new ArgumentException($"検索用ステータス文字列取得処理に未実装なインデックス[{cmbStatus.SelectedIndex}]が渡されました");
            }
        }

        /// <summary>
        /// 検索用ピッキングステータスの文字列を返します
        /// </summary>
        /// <param name="cmbPickingStatus">検索用のピッキングステータスのコンボボックス</param>
        /// <returns>検索用の数値</returns>
        /// <exception cref="ArgumentException">ピッキングステータスコンボ用の列挙対で未実装があれば例外をスローします</exception>
        public static int? GetSearchPickingStatusLabel(ComboBox cmbPickingStatus)
        {
            switch (cmbPickingStatus.SelectedIndex)
            {
                case (int)Consts.PickingStatusIndex.All:
                    // (すべて)
                    return null;

                case (int)Consts.PickingStatusIndex.UnprocessedOnly:
                    // 新規注文
                    return 0;

                case (int)Consts.PickingStatusIndex.ProcessedOnly:
                    // ピック済
                    return 1;

                default:
                    throw new ArgumentException($"検索用ステータス文字列取得処理に未実装なインデックス[{cmbPickingStatus.SelectedIndex}]が渡されました");
            }
        }

        /// <summary>
        /// データグリッドのセルのチェックボックスのチェック状態を取得します
        /// null⇒true⇒false⇒true⇒false・・・・と状態遷移する
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="cellIndex">対象セルのインデックス</param>
        /// <returns>チェック状態ならtrue。それ以外はfalse。</returns>
        public static bool GetCheckedFromDataGridViewRow(DataGridViewRow row, int cellIndex)
        {
            var cellValue = row.Cells[cellIndex].Value;
            
            if (cellValue == null) return false;
            if (cellValue is bool checkedValue)
            {
                return checkedValue;
            }

            return false;
        }

        /// <summary>
        /// 支払い方法の表示名を変更します
        /// カスタム=yhカード、カスタム2=您所配合的代工
        /// </summary>
        /// <remarks>
        /// この変換はストアドS_SearchOrderでやっていたりしますが、
        /// ロジックを極力コード側に集めようとなり、この関数を作成します。
        /// </remarks>
        /// <param name="payment">支払方法</param>
        /// <returns>画面表示用の支払い方法名</returns>
        public static string GetPaymentText(string payment)
        {
            switch (payment)
            {
                case "カスタム":
                    return  "yhカード";

                case "カスタム2":
                    return "您所配合的代工";

                default:
                    return payment;
            }
        }

    }
}
