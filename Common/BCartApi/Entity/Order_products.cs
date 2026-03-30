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
    public class cOrder_products
    {
        public List<cOrder_productsGet>? order_products { get; set; }
    }
    public class cOrder_productsGet
    {   
        public long id { get; set; }
        public long order_id { get; set; }
        public long? logistics_id { get; set; }
        public long? product_id { get; set; }
        public string main_no { get; set; } = "";
        public string product_no { get; set; } = "";
        public string jan_code { get; set; } = "";
        public string location_no { get; set; } = "";
        public string product_name { get; set; } = "";
        public int? product_set_id { get; set; }
        public string set_name { get; set; } = "";
        public decimal? unit_price { get; set; }
        public int set_quantity { get; set; }
        public string set_unit { get; set; } = "";
        public int order_pro_count { get; set; }
        public int shipping_size { get; set; }
        public decimal? tax_rate { get; set; }
        public byte? tax_type_id { get; set; }
        public byte? tax_incl { get; set; }
        public string item_type { get; set; } = "";
        public string pro_custom1 { get; set; } = "";
        public string pro_custom2 { get; set; } = "";
        public string pro_custom3 { get; set; } = "";
        public List<cProduct_customs>? product_customs { get; set; } // 配列型
        public string set_custom1 { get; set; } = "";
        public string set_custom2 { get; set; } = "";
        public string set_custom3 { get; set; } = "";
        public List<cProduct_set_customs>? product_set_customs { get; set; } = new List<cProduct_set_customs>();　// 配列型
        public List<cOptions>? options { get; set; }　// 配列型
    }

    public class cProduct_customs
    {
        public int field_id { get; set; }
        public string? value { get; set; }

    }
    public class cProduct_set_customs
    {
        public int field_id { get; set; }
        public string value { get; set; } = "";
 
    }
    public class cOptions
    {
        public int field_id { get; set; }
        public string? value { get; set; }

    }
}
