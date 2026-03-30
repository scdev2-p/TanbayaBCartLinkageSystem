namespace Bcart受注管理.AppData
{
    /// <summary>
    /// 定数を定義します
    /// </summary>
    internal static class Consts
    {
        /// <summary>
        /// ステータスコンボの候補のセレクトインデックス
        /// All：すべて
        /// NewOnly：新規注文
        /// Picked：ピック済
        /// ShippingCompleted：出荷完了
        /// OtherThanShippingCompleted：出荷完了以外
        /// </summary>
        public enum OrderStatusIndex
        {
            All,
            NewOnly,
            Picked,
            ShippingCompleted,
            OtherThanShippingCompleted
        }

        /// <summary>
        /// ステータスコンボの候補
        /// </summary>
        public static Dictionary<int, string> OrderStatus = new(){
            { (int)OrderStatusIndex.All, "(すべて)" },
            { (int)OrderStatusIndex.NewOnly, "新規注文" },
            { (int)OrderStatusIndex.Picked, "ピック済" },
            { (int)OrderStatusIndex.ShippingCompleted, "出荷完了" },
            { (int)OrderStatusIndex.OtherThanShippingCompleted, "出荷完了以外" }};


        public enum FormMode
        {
            ReadOnly, Sipping
        }

        /// <summary>
        /// ピッキングステータスコンボの候補のセレクトインデックス
        /// All：すべて
        /// UnprocessedOnly：未処理
        /// ProcessedOnly：処理済
        /// </summary>
        public enum PickingStatusIndex
        {
            All,
            UnprocessedOnly,
            ProcessedOnly
        }

        /// <summary>
        /// ピッキングステータスコンボの候補
        /// </summary>
        public static Dictionary<int, string> PickingStatus = new(){
            { (int)PickingStatusIndex.All, "(すべて)" },
            { (int)PickingStatusIndex.UnprocessedOnly, "未処理" },
            { (int)PickingStatusIndex.ProcessedOnly, "ピック済" }};
    }
}
