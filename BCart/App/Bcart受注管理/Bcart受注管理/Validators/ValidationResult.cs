namespace Bcart受注管理.Validators
{   
    /// <summary>
    /// 検証結果を示します
    /// </summary>
    internal class ValidationResult
    {   
        /// <summary>
        /// エラーの場合はtrue。それ以外の場合はfalse
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// エラーの理由をセットします。
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// IsError=trueならメッセージを表示してtrueを返します
        /// それ以外はfalseを返します
        /// </summary>
        /// <returns>エラーならtrue。それ以外はfalse。</returns>
        public bool ShowError()
        {
            if (IsError)
            {
                MessageBox.Show(ErrorMessage, "入力エラー");
                return true;
            }
            return false;
        }
    }

}
