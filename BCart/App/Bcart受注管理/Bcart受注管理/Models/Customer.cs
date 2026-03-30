namespace Bcart受注管理.Models
{
    /// <summary>
    /// BCartの会員情報
    /// </summary>
    internal class Customer
    {
        public long? Id { get; set; }
        public string? ExtId { get; set; }
        public string? AgentId { get; set; }
        public decimal? AgentRate { get; set; }
        public string? ParentId { get; set; }
        public string? DestinationCode { get; set; }
        public string? CompName { get; set; }
        public string? CompNameKana { get; set; }
        public string? CeoLastName { get; set; }
        public string? CeoFirstName { get; set; }
        public string? CeoLastNameKana { get; set; }
        public string? CeoFirstNameKana { get; set; }
        public string? Department { get; set; }
        public string? TantoLastName { get; set; }
        public string? TantoFirstName { get; set; }
        public string? TantoLastNameKana { get; set; }
        public string? TantoFirstNameKana { get; set; }
        public string? Zip { get; set; }
        public string? Pref { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Email { get; set; }
        public string? EmailCc { get; set; }
        public string? Tel { get; set; }
        public string? MobilePhone { get; set; }
        public string? Fax { get; set; }
        public string? Url { get; set; }
        public string? Foundation { get; set; }
        public long? sales { get; set; }
        public string? Job { get; set; }
        public string? Memo { get; set; }
        public string? Payment { get; set; }
        public string? SpecialShippingCost { get; set; }
        public int? MmFlag { get; set; }
        public long? Point { get; set; }
        public long? PriceGroupId { get; set; }
        public long? ViewGroupId { get; set; }
        public List<CustomerCustom>? Customs { get; set; }
        public string? SalesmanId { get; set; }
        public string? AfId { get; set; }
        public decimal? CreditLimit { get; set; }
        public string? CutoffDate { get; set; }
        public string? PaymentMonth { get; set; }
        public string? PaymentDate { get; set; }
        public long? DefaultOtherShippingId { get; set; }
        public string? DefaultPayment { get; set; }
        public int? HiddenPrice { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
