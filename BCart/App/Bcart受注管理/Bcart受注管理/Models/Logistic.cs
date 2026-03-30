using Bcart受注管理.Converters;
using System.Text.Json.Serialization;

namespace Bcart受注管理.Models
{
    /// <summary>
    /// BCartの出荷データ
    /// </summary>
    internal class Logistic
    {
        public long Id { get; set; }
        public string? ShipmentCode { get; set; }
        public string? DeliveryCode { get; set; }
        public string? DestinationCode { get; set; }
        public long ShippingGroupId { get; set; }
        public string? CompName { get; set; }
        public string? Department { get; set; }
        public string? Name { get; set; }
        public string? Zip { get; set; }
        public string? Pref { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Tel { get; set; }
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? DueDate { get; set; }
        public string? DueTime { get; set; }
        public string? Memo { get; set; }
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? ShipmentDate { get; set; }
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? ArrivalDate { get; set; }
        public string? Status { get; set; }
        public long? Complete { get; set; }
    }
}
