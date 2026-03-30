using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCartApi.Entity
{
    // JsonSerializerはパラメータしか変換できないので全て { get; set; } にする事



    // ********************************************************************************************
    // 在庫更新用
    // ********************************************************************************************


    /// <summary>
    /// 商品在庫更新用のリクエスト
    /// </summary>
    public class cProductSetStockRequest
    {
        public List<cProductSetStock>? product_sets { get; set; } = new List<cProductSetStock>();
    }

    /// <summary>
    /// 商品在庫更新用のレスポンス
    /// </summary>
    public class cProductSetStockResponse
    {
        public List<cProductSetStock>? product_sets { get; set; }
        public List<String>? errors;
    }

    /// <summary>
    /// 商品セットの在庫
    /// </summary>
    public class cProductSetStock
    {
        public long id { get; set; }
        public decimal stock { get; set; }
    }


    // ********************************************************************************************
    // 価格更新用
    // ********************************************************************************************

    /// <summary>
    /// 商品価格更新用のリクエスト
    /// </summary>
    public class cProductSetPriceRequest
    {
        public List<cProductSetPrice>? product_sets { get; set; } = new List<cProductSetPrice>();
    }

    /// <summary>
    /// 商品価格更新用のレスポンス
    /// </summary>
    public class cProductSetPriceResponse
    {
        public List<cProductSetPrice>? product_sets { get; set; }
        public List<String>? errors;
    }

    public class cProductSetPrice
    {
        public long id { get; set; }
        //public long product_id { get; set; }
        public decimal jodai { get; set; }
        public decimal unit_price { get; set; }
        //public int tax_type_id { get; set; } = 1;         // 消費税区分は更新しない(訳が分からなくなるから)
        public cGroupPrices group_price { get; set; } = new cGroupPrices();
    }

    public class cGroupPrices
    {
        [JsonPropertyName("1")]
        public cGroupPrice gp1 { get; set; } = new cGroupPrice();
        [JsonPropertyName("2")]
        public cGroupPrice gp2 { get; set; } = new cGroupPrice();
        [JsonPropertyName("3")]
        public cGroupPrice gp3 { get; set; } = new cGroupPrice();
        [JsonPropertyName("4")]
        public cGroupPrice gp4 { get; set; } = new cGroupPrice();
        [JsonPropertyName("5")]
        public cGroupPrice gp5 { get; set; } = new cGroupPrice();
        [JsonPropertyName("6")]
        public cGroupPrice gp6 { get; set; } = new cGroupPrice();
        [JsonPropertyName("7")]
        public cGroupPrice gp7 { get; set; } = new cGroupPrice();
        [JsonPropertyName("8")]
        public cGroupPrice gp8 { get; set; } = new cGroupPrice();
    }

    public class cGroupPrice
    {
        public decimal unit_price { get; set; }
        public decimal fixed_price { get; set; }
    }

    // ********************************************************************************************
    // 商品セット新規追加用
    // ********************************************************************************************

    /// <summary>
    /// 商品セット新規用のリクエスト（複数）
    /// </summary>
    public class cProductSetNewRequest
    {
        public List<cProductSetNew>? product_sets { get; set; } = new List<cProductSetNew>();
    }

    /// <summary>
    /// 商品セット新規用のレスポンス（複数）
    /// </summary>
    public class cProductSetNewResponse
    {
        public List<cProductSetGet>? product_sets { get; set; } = new List<cProductSetGet>();
    }


    /// <summary>
    /// 商品セットカスタム項目更新(PATCH ID指定 個別 または POST用)
    /// </summary>
    public class cProductSetCustomRequest
    {
        public cProductSetCustomByID? product_sets { get; set; } = new cProductSetCustomByID();
    }

    /// <summary>
    /// 商品セット新規用のレスポンス（個別）
    /// </summary>
    public class cProductSetResponse
    {
        public cProductSetGet? product_set { get; set; }
    }


    //






    public class cProductSetNew
    {
        public long product_id { get; set; }                    // 商品ID
        public string product_no { get; set; } = "";            // 品番
        public string name { get; set; }                        // セット名
        public string jodai_type { get; set; } = "カスタム";    // 上代タイプ
        public decimal jodai { get; set; }                     // 上代
        public decimal unit_price { get; set; }                 // 単価
        public int quantity { get; set; }                       // 入数
        public decimal stock {  get; set; }                     // 在庫
        public int stock_flag { get; set; } = 0;                   // 在庫フラグ
        public int stock_view_id { get; set; } = 1;             // 在庫表示パターン
        public int stock_few { get; set; } = 5;                 // 在庫残り僅か数     
        public int tax_type_id { get; set; } = 1;               // 税区分

        public cGroupPrices group_price { get; set; } = new cGroupPrices();

        public int shipping_group_id { get; set; } = 1;         // 配送グループ     
        public List<cProductSetCustom> customs { get; set; } = new List<cProductSetCustom>();  // カスタム項目

    }

    public class cProductSetGet
    {
        public long id { get; set; }                            // セットID
        public string product_no { get; set; } = "";                  // 商品No
        public long product_id { get; set; }                    // 商品ID
        public string name { get; set; }                        // セット名
        public string jodai_type { get; set; } = "カスタム";    // 上代タイプ
        public decimal jodai { get; set; }                     // 上代
        public decimal unit_price { get; set; }                 // 単価
        public int quantity { get; set; }                       // 入数
        public decimal stock { get; set; }                     // 在庫
        public int stock_flag { get; set; } = 0;                   // 在庫フラグ
        public int stock_view_id { get; set; } = 1;             // 在庫表示パターン
        public int stock_few { get; set; } = 5;                 // 在庫残り僅か数     
        public int tax_type_id { get; set; } = 1;               // 税区分

        public cGroupPrices group_price { get; set; } = new cGroupPrices();

        public int shipping_group_id { get; set; } = 1;         // 配送グループ     
        public List<cProductSetCustom> customs { get; set; } = new List<cProductSetCustom>();  // カスタム項目

    }

    public class cProductSetCustom
    {
        public int field_id { get; set; }
        public string value {  get; set; }
    }


    public class cProductSetCustomByID
    {
        public string? name { get; set; }
        public string? product_cd { get; set; }
        public List<cProductSetCustom> customs { get; set; } = new List<cProductSetCustom>();  // カスタム項目

        public decimal jodai { get; set; }                     // 上代
        public decimal unit_price { get; set; }                 // 単価
        public int tax_type_id { get; set; } = 1;               // 税区分
        public cGroupPrices group_price { get; set; } = new cGroupPrices();
        public decimal stock { get; set; }                     // 在庫
    }



    // ********************************************************************************************
    // 商品セット表示/非表示用
    // ********************************************************************************************

    public class cProductSetFlagRequest
    {
        public List<cProductSetFlag> product_sets { get; set; } = new List<cProductSetFlag>();
    }


    public class cProductSetFlag
    {
        public long id { get; set; }                            // セットID
        public string set_flag { get; set; }                    // 表示/非表示
    }


    /// <summary>
    /// 親の商品基本の取得
    /// </summary>
    public class cProductSetParentResponnse
    {
        public List<cProductSetParent> product_sets { get; set; }
    }

    public class cProductSetParent
    {
        public long id { get; set; }                            // セットID
        public long product_id { get; set; }                    // 商品基本ID
        public string set_flag { get; set; }                    // 表示/非表示
    }



    /*
 "product_sets": [
		{
			"product_id": 1,
			"product_no": "XXX-1008-AA",
			"jan_code": "xxx",
			"location_no": "1",
			"jodai_type": "メーカー希望小売価格",
			"jodai": 25000,
			"name": "単品販売 カラー：ブラウン",
			"unit_price": 20000,
			"min_order": null,
			"max_order": 10,
			"group_price": {
				"1": {
					"fixed_price": 12400,
					"volume_discount": {
						"2": 12000,
						"3": 11000
					}
				},
				"2": {
					"fixed_price": 4000,
					"volume_discount": {
						"2": 3600
					}
				},
				"3": {
					"fixed_price": 2000,
					"volume_discount": {
						"5": 1800
					}
				},
				"n": {
					"fixed_price": 21000,
					"volume_discount": {
						"5": 18000
					}
				}
			},
			"special_price": {
				"9888": {
					"unit_price": 15000,
					"volume_discount": {
						"5": 14000
					}
				},
				"10000": {
					"unit_price": 16800
				},
				"9999": {
					"unit_price": 17800,
					"volume_discount": {
						"5": 10000,
						"10": 9980
					}
				}
			},
			"volume_discount": {
				"2": 14200,
				"5": 13800
			},
			"quantity": 1,
			"unit": "脚",
			"stock": null,
			"stock_flag": 1,
			"stock_view_id": 1,
			"stock_few": 0,
			"priority": 0,
			"set_flag": "表示",
			"view_group_filter": "1,2",
			"visible_customer_id": "10000,5555",
			"customs": [
                {
                    "field_id": 17,
                    "value": "custom1"
                },
                {
                    "field_id": 18,
                    "value": "custom2"
                },
                {
                    "field_id": 19,
                    "value": "custom3"
                }
            ],
            "option_ids": [
                1,
                2
            ],
			"shipping_group_id": 3,
			"shipping_size": 0
		},
	]
}'
    */










}
