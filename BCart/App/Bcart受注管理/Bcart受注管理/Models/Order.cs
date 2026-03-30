using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Bcart受注管理.Converters;

namespace Bcart受注管理.Models
{
    /// <summary>
    /// BCartの受注データ
    /// </summary>
    internal class Order
    {
        public long? Id { get; set; }
        public string? Code { get; set; }
        public long? CustomerId { get; set; }
        public string? CustomerExtId { get; set; }
        public string? CustomerParentId { get; set; }
        public string? CustomerSalesmanId { get; set; }
        public string? CustomerCompName { get; set; }
        public string? CustomerDepartment {  get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerTel { get; set; }
        public string? CustomerMobilePhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPriceGroupId { get; set; }
        public string? CustomerZip { get; set; }
        public string? CustomerPref { get; set; }
        public string? CustomerAddress1 { get; set; }
        public string? CustomerAddress2 { get; set; }
        public string? CustomerAddress3 { get; set; }
        public List<CustomerCustom>? CustomerCustoms { get; set; }
        public string? Payment { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? PaymentAt { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Tax { get; set; }
        public string? TaxRate { get; set; }
        public decimal? CODCost { get; set; }
        public decimal? ShippingCost { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal? UsePoint { get; set; }
        public decimal? GetPoint { get; set; }
        public List<OrderTotal>? OrderTotals { get; set; }
        public string? CustomerMessage { get; set; }
        public string? AdminMessage { get; set; }
        public string? Memo { get; set; }
        public List<CustomerCustom>? Customs { get; set; }
        public string? Enquete1 { get; set; }
        public string? Enquete2 { get; set; }
        public string? Enquete3 { get; set; }
        public string? Enquete4 { get; set; }
        public string? Enquete5 { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? OrderedAt { get; set; }
        public string? AffiliateId { get; set; }
        public string? EstimateId { get; set; }
        public string? Status { get; set; }
    }
}
