namespace Bcart受注管理.Models
{
    /// <summary>
    /// BCartの受注商品データ
    /// </summary>
    internal class OrderProduct
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long? LogisticsId { get; set; }
        public long? ProductId { get; set; }
        public string? MainNo { get; set; }
        public string? ProductNo { get; set; }
        public string? JanCode { get; set; }
        public string? LocationNo { get; set; }
        public string? ProductName { get; set; }
        public long? ProductSetId { get; set; }
        public string? SetName { get; set; }
        public double UnitPrice { get; set; }
        public double SetQuantity { get; set; }
        public string? SetUnit { get; set; }
        public long OrderProCount { get; set; }
        public double ShippingSize { get; set; }
        public string? TaxRate { get; set; }
        public int TaxTypeId { get; set; }
        public int TaxIncl { get; set; }
        public string? ItemType { get; set; }
        public string? ProCustom1 { get; set; }
        public string? ProCustom2 { get; set; }
        public string? ProCustom3 { get; set; }
        public string? SetCustom1 { get; set; }
        public string? SetCustom2 { get; set; }
        public string? SetCustom3 { get; set; }
        public List<CustomerCustom>? ProductCustoms { get; set; }
        public List<CustomerCustom>? ProductSetCustoms { get; set; }
        public List<CustomerCustom>? Options { get; set; }
    }
}
