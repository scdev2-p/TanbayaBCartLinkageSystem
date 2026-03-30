namespace Bcart受注管理.Models
{
    /// <summary>
    /// BCartの受注データにある料金情報
    /// </summary>
    internal class OrderTotal
    {
        public string? TaxRate { get; set; }
        public decimal? Total { get; set; }
        public decimal? Tax { get; set;}
        public decimal? TotalInclTax { get; set; }
    }
}
