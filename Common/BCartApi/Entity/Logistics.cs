using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCartApi.Entity
{
    internal class Logistics
    {
    }

    // 出荷（取得用）
    public class cLogisticsGetResponse
    {
        public cLogisticsGet? logistic { get; set; }
    }

    public class cLogisticsGet
    {
        public long id { get; set; }
        public string? shipment_code { get; set; }
        public string? delivery_code { get; set; }
        public string? destination_code { get; set; }
        public int? shipping_group_id { get; set; }
	    public string? comp_name { get; set; }
	    public string? department {  get; set; }
        public string? name { get; set; }
	    public string? zip {  get; set; }
        public string? pref {  get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? address3 { get; set; }
        public string? tel { get; set; }
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? due_date { get; set; }
        public string? due_time { get; set; }
        public string? memo { get; set; }
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? shipment_date { get; set; }
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? arrival_date { get; set; }
        public string? status { get; set; }
	    public int complete { get; set; }
    }







}
