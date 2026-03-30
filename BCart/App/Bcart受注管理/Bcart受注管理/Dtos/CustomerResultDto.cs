namespace Bcart受注管理.Dtos
{
    /// <summary>
    /// 顧客APIの登録結果DTO
    /// </summary>
    internal class CustomerResultDto
    {
        /// <summary>
        /// 登録が成功した場合に登録後の顧客情報をセットします
        /// </summary>
        public CustomerDto? Customer { get; set; }

        /// <summary>
        /// 登録が失敗した場合にエラー情報をセットします
        /// nullの場合は成功です
        /// </summary>
        public BCartApiErrorDto? ErrorInfo { get; set; }

        /// <summary>
        /// BCart側でInternalServerErrorを補足した場合にセットします
        /// </summary>
        public string Error {  get; set; }
    }
}
