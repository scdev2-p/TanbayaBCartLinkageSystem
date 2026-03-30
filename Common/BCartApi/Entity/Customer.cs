using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCartApi.Entity
{
    public class cCustomerGet
    {
        public long id { get; set; }
        public string ext_id { get; set; }
        public string agent_id { get; set; }
        public string agent_rate { get; set; }
        public string parent_id { get; set; }
        public string destination_code { get; set; }
        public string comp_name { get; set; }
        public string comp_name_kana { get; set; }
        public string ceo_last_name { get; set; }
        public string ceo_first_name { get; set; }
        public string ceo_last_name_kana { get; set; }
        public string ceo_first_name_kana { get; set; }
        public string department { get; set; }
        public string tanto_last_name { get; set; }
        public string tanto_first_name { get; set; }
        public string tanto_last_name_kana { get; set; }
        public string tanto_first_name_kana { get; set; }
        public string zip { get; set; }
        public string pref { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string email { get; set; }
        public string email_cc { get; set; }
        public string tel { get; set; }
        public string mobile_phone { get; set; }
        public string fax { get; set; }
        public string url { get; set; }
        public string foundation { get; set; }
        public int? sales { get; set; }
        public string job { get; set; }
        public string memo { get; set; }
        public string payment { get; set; }
        public string special_shipping_cost { get; set; }
        public int mm_flag { get; set; }
        public int point { get; set; }
        public int? price_group_id { get; set; }
        public int? view_group_id { get; set; }
        public List<cCustomer_custom>? customs { get; set; }
        public int? salesman_id { get; set; }
        public int? af_id { get; set; }
        public int? credit_limit { get; set; }
        public string cutoff_date { get; set; }
        public string payment_month { get; set; }
        public string payment_date { get; set; }
        public int? default_other_shipping_id { get; set; }
        public string default_payment { get; set; }
        public int hidden_price { get; set; }
        public string status { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))] 
        public DateTime? created_at { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))] 
        public DateTime? updated_at { get; set; }
    }


    public class cCustomerRank
    {
        public long id { get; set; }
        public int? price_group_id { get; set; }
    }

    public class cCustomerRankRequest
    {
        public List<cCustomerRank> customers { get; set; } = new List<cCustomerRank>();
    }

    public class cCustomerResponse
    {
        public List<cCustomerGet> customers { get; set; }
    }

}