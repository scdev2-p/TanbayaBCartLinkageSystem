namespace Bcart受注管理.Dtos
{   
    /// <summary>
    /// BCartから帰ってきたエラーメッセージを格納します
    /// </summary>
    internal class BCartApiErrorDto
    {   
        /// <summary>
        /// エラー内容を格納
        /// </summary>
        public List<Dictionary<string, string>> Errors { get; set; }
    }
}
