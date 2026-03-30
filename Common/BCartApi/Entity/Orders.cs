using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCartApi.Entity
{
    // JsonSerializerはパラメータしか変換できないので全て { get; set; } にする事


    /// <summary>
    /// 受注一覧
    /// </summary>
    public class cOrders
    {
        public List<cOrdersGet>? orders { get; set; }
    }

    /// <summary>
    /// 受注（取得用）
    /// </summary>
    public class cOrdersGet
    {
        public long id { get; set; }
        public long code { get; set; }
        public long customer_id { get; set; }
        public string customer_ext_id { get; set; } = "";
        public string customer_parent_id { get; set; } = "";
        public string customer_salesman_id { get; set; } = "";
        public string customer_comp_name { get; set; } = "";
        public string customer_department { get; set; } = "";
        public string customer_name { get; set; } = "";
        public string customer_tel { get; set; } = "";
        public string customer_mobile_phone { get; set; } = "";
        public string customer_email { get; set; } = "";
        public string customer_price_group_id { get; set; } = "";
        public string customer_zip { get; set; } = "";
        public string customer_pref { get; set; } = "";
        public string customer_address1 { get; set; } = "";
        public string customer_address2 { get; set; } = "";
        public string customer_address3 { get; set; } = "";
        public string customer_custom1 { get; set; } = "";
        public string customer_custom2 { get; set; } = "";
        public string customer_custom3 { get; set; } = "";
        public List<cCustomer_custom>? customer_customs { get; set; }
        public string payment { get; set; } = "";

        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? payment_at { get; set; }
        
        public decimal? total_price { get; set; }
        public decimal? tax { get; set; }
        public decimal? tax_rate { get; set; }
        public decimal? COD_cost { get; set; } 
        public decimal? shipping_cost { get; set; }
        public decimal? final_price { get; set; }
        public decimal? use_point { get; set; }
        public decimal? get_point { get; set; }
        public List<cOrder_total>? order_totals { get; set; }
        public string customer_message { get; set; } = "";
        public string admin_message { get; set; } = "";
        public string memo { get; set; } = "";
        public List<cCustoms>? customs { get; set; }
        public string enquete1 { get; set; } = "";
        public string enquete2 { get; set; } = "";
        public string enquete3 { get; set; } = "";
        public string enquete4 { get; set; } = "";
        public string enquete5 { get; set; } = "";

        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime ordered_at { get; set; }
        
        public string affiliate_id { get; set; } = "";

        public string estimate_id { get; set; } = "";
        public string status { get; set; } = "";

    }

    public class cCustomer_custom
    {
        public int field_id { get; set; }
        public string value { get; set; } = "";
    }

    public class cOrder_total
    {
        public decimal? tax_rate { get; set; }
        public decimal? total { get; set; }
        public decimal? tax { get; set; }
        public decimal? total_incl_tax { get; set; }

    }
    public class cCustoms
    {
        public int field_id { get; set; }
        public string value { get; set; } = "";
    }



    /// <summary>
    /// 受注一覧(ステータス変更用)
    /// </summary>
    public class cOrder
    {
        public cOrderGet? order { get; set; }
    }

    /// <summary>
    /// 受注（ステータス変更用）
    /// </summary>
    public class cOrderGet
    {
        //public long id { get; set; }
        public string status { get; set; } = "";

    }


    /// <summary>
    /// 受注一覧(ステータス変更用)
    /// </summary>
    public class cOrderStatusRequest
    {
        public cOrderStatus? order { get; set; } = new cOrderStatus();
    }

    /// <summary>
    /// 受注（ステータス変更用）
    /// </summary>
    public class cOrderStatus
    {
        //public long id { get; set; }
        public string status { get; set; } = "";
    }

    public class cOrderResponse
    {
        public cOrdersGet order { get; set; }
    }

}
