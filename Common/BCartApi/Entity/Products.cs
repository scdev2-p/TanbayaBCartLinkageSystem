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
    /// 商品マスタ一覧
    /// </summary>
    public class cProducts
    {
        //public string? errors { get; set; }
        public List<cProductGet>? products { get; set; }
    }

    public class cProduct
    {
        //public string errors { get; set; }
        public cProductGet? product { get; set; }
    }

    /// <summary>
    /// 商品マスタ（取得用）
    /// </summary>
    public class cProductGet
    {
        //public string errors { get; set; }
        public long id { get; set; }
        public string main_no { get; set; } = "";
        public string name { get; set; } = "";
        public string catch_copy { get; set; } = "";
        public int? category_id { get; set; }
        public string sub_category_id { get; set; } = "";
        public int? feature_id1 { get; set; }
        public int? feature_id2 { get; set; }
        public int? feature_id3 { get; set; }
        public string made_in { get; set; } = "";
        public string size { get; set; } = "";
        public string sozai { get; set; } = "";
        public string caution { get; set; } = "";
        public string tag { get; set; } = "";
        public string description { get; set; } = "";
        public string meta_title { get; set; } = "";
        public string meta_keywords { get; set; } = "";
        public string meta_description { get; set; } = "";
        public string image { get; set; } = "";
        public string view_group_filter { get; set; } = "";
        public string visible_customer_id { get; set; } = "";   
        public string prepend_text { get; set; } = "";
        public string append_text { get; set; } = "";
        public string middle_text { get; set; } = "";
        public string rv_prepend_text { get; set; } = "";
        public string rv_append_text { get; set; } = "";
        public string rv_middle_text { get; set; } = "";
        public string file_download { get; set; } = "";
        public List<cCustom>? customs { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? hanbai_start { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? hanbai_end { get; set; }
        public string recommend_product_id { get; set; } = "";
        public int view_pattern { get; set; }
        public int priority { get; set; }
        public string flag { get; set; } = "";
        [JsonConverter(typeof(DateTimeJsonConverter))] 
        public DateTime? updated_at { get; set; }
        public cSub_images? sub_images { get; set; }
    }
    public class cCustom
    {
        public int field_id { get; set; }
        public string? value { get; set; }

    }
    public class cSub_image
    {
        public string? image { get; set; }
        public string? caption { get; set; }
    }
    public class cSub_images
    {
        [JsonPropertyName("1")]
        public cSub_image? image1 { get; set; }
        [JsonPropertyName("2")]
        public cSub_image? image2 { get; set; }
        [JsonPropertyName("3")]
        public cSub_image? image3 { get; set; }
        [JsonPropertyName("4")]
        public cSub_image? image4 { get; set; }
        [JsonPropertyName("5")]
        public cSub_image? image5 { get; set; }
        [JsonPropertyName("6")]
        public cSub_image? image6 { get; set; }
    }

    public class cInsertProductsRequest
    {
        public List<cProductsNew>? products { get; set; } = new List<cProductsNew>();
    }


    public class cInsertProductsDetailRequest
    {
        public List<cProductsNewDetail>? products { get; set; } = new List<cProductsNewDetail>();
    }

    public class cInsertProductsResponse
    {
        public List<cProductGet>? products { get; set; }
    }


    /// <summary>
    /// 商品マスタ（新規用）
    /// 必要な項目のみ定義する場合
    /// </summary>
    public class cProductsNew
    {
        //public string main_no { get; set; } = "";     // 商品管理番号
        public string name { get; set; } = "";          // 商品名
        //public string catch_copy { get; set; } = "";  //キャッチコピー
        public int? category_id { get; set; }           // カテゴリーID
        //public string sub_category_id { get; set; } = ""; // サブカテゴリーID
        //public int? feature_id1 { get; set; }             // 特集ID1
        //public int? feature_id2 { get; set; }             // 特集ID2
        //public int? feature_id3 { get; set; }             // 特集ID3
        public string made_in { get; set; } = "";         // 生産地
        public string size { get; set; } = "";            // サイズ
        //public string sozai { get; set; } = "";           // 素材
        //public string caution { get; set; } = "";         // 注意事項
        public string tag { get; set; } = "";               // 商品特徴
        //public string description { get; set; } = "";     // 説明
        //public string meta_title { get; set; } = "";      // meta title
        //public string meta_keywords { get; set; } = "";   // meta keyword
        //public string meta_description { get; set; } = "";    // meta description
        //public string image { get; set; } = "";               // 商品画像パス
        public string view_group_filter { get; set; } = "";   // 非表示のグループID
        //public string visible_customer_id { get; set; } = ""; // 例外表示会員ID
        //public string prepend_text { get; set; } = "";        // 上部フリースペース
        //public string append_text { get; set; } = "";         // 中部フリースペース
        //public string middle_text { get; set; } = "";         // 下部フリースペース
        //public string rv_prepend_text { get; set; } = "";     // レスポンシブ上部フリースペース
        //public string rv_append_text { get; set; } = "";      // レスポンシブ中部フリースペース
        //public string rv_middle_text { get; set; } = "";      // レスポンシブ下部フリースペース
        //public string? file_download { get; set; } = null;    // ダウンロードファイルパス
        //public List<cCustom>? customs { get; set; } = new List<cCustom>();  // カスタム項目
        //[JsonConverter(typeof(DateTimeJsonConverter))]
        //public DateTime? hanbai_start { get; set; }      // 販売開始日時
        //[JsonConverter(typeof(DateTimeJsonConverter))]
        //public DateTime? hanbai_end { get; set; }        // 販売終了日時
        //public string recommend_product_id { get; set; } = "";    //リコメンド商品ID
        public int view_pattern { get; set; } = 0;         // 商品一覧表示パターン
        public int priority { get; set; } = 0;             // 表示順
        public string flag { get; set; } = "非表示";       // 状態
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? updated_at { get; set; }           // 更新日時
        //public List<cSub_image>? sub_images { get; set; } // サブ画像パス
    }

    /// <summary>
    /// 商品マスタ（新規詳細登録用）
    /// </summary>
    public class cProductsNewDetail
    {
        //public string main_no { get; set; } = "";     // 商品管理番号
        public string name { get; set; } = "";          // 商品名
        public string catch_copy { get; set; } = "";  //キャッチコピー
        public int? category_id { get; set; }           // カテゴリーID
        public string sub_category_id { get; set; } = ""; // サブカテゴリーID
        public int? feature_id1 { get; set; }             // 特集ID1
        public int? feature_id2 { get; set; }             // 特集ID2
        public int? feature_id3 { get; set; }             // 特集ID3
        public string made_in { get; set; } = "";         // 生産地
        public string size { get; set; } = "";            // サイズ
        public string sozai { get; set; } = "";           // 素材
        public string caution { get; set; } = "";         // 注意事項
        public string tag { get; set; } = "";               // 商品特徴
        public string description { get; set; } = "";     // 説明
        //public string meta_title { get; set; } = "";      // meta title
        public string meta_keywords { get; set; } = "";   // meta keyword
        //public string meta_description { get; set; } = "";    // meta description
        public string image { get; set; } = "";               // 商品画像パス
        public string view_group_filter { get; set; } = "";   // 非表示のグループID
        //public string visible_customer_id { get; set; } = ""; // 例外表示会員ID
        //public string prepend_text { get; set; } = "";        // 上部フリースペース
        //public string append_text { get; set; } = "";         // 中部フリースペース
        //public string middle_text { get; set; } = "";         // 下部フリースペース
        //public string rv_prepend_text { get; set; } = "";     // レスポンシブ上部フリースペース
        //public string rv_append_text { get; set; } = "";      // レスポンシブ中部フリースペース
        //public string rv_middle_text { get; set; } = "";      // レスポンシブ下部フリースペース
        //public string? file_download { get; set; } = null;    // ダウンロードファイルパス
        public List<cCustom>? customs { get; set; } = new List<cCustom>();  // カスタム項目
        //[JsonConverter(typeof(DateTimeJsonConverter))]
        //public DateTime? hanbai_start { get; set; }      // 販売開始日時
        //[JsonConverter(typeof(DateTimeJsonConverter))]
        //public DateTime? hanbai_end { get; set; }        // 販売終了日時
        //public string recommend_product_id { get; set; } = "";    //リコメンド商品ID
        public int view_pattern { get; set; } = 0;         // 商品一覧表示パターン
        public int priority { get; set; } = 0;             // 表示順
        public string flag { get; set; } = "非表示";       // 状態
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? updated_at { get; set; }           // 更新日時
        public List<cSub_image>? sub_images { get; set; } // サブ画像パス
    }



    /// <summary>
    /// 商品マスタ（更新用）
    /// 必要な項目のみ定義する場合
    /// </summary>
    public class cProductUpdate
    {
        public long id { get; set; }
        public string main_no { get; set; } = "";
        public string name { get; set; } = "";
        public string catch_copy { get; set; } = "";    
        public int? category_id { get; set; }
        public string sub_category_id { get; set; } = "";
        public int? feature_id1 { get; set; }
        public int? feature_id2 { get; set; }
        public int? feature_id3 { get; set; }
        public string made_in { get; set; } = "";
        public string size { get; set; } = "";
        public string sozai { get; set; } = "";
        public string caution { get; set; } = "";
        public string tag { get; set; } = "";
        public string description { get; set; } = "";
        public string meta_title { get; set; } = "";
        public string meta_keywords { get; set; } = "";
        public string meta_description { get; set; } = "";
        public string image { get; set; } = "";
        public string view_group_filter { get; set; } = "";
        public string visible_customer_id { get; set; } = "";
        public string prepend_text { get; set; } = "";
        public string append_text { get; set; } = "";
        public string middle_text { get; set; } = "";
        public string rv_prepend_text { get; set; } = "";
        public string rv_append_text { get; set; } = "";
        public string rv_middle_text { get; set; } = "";
        public string file_download { get; set; } = "";
        public List<cCustom>? customs { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? hanbai_start { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? hanbai_end { get; set; }
        public string recommend_product_id { get; set; } = "";
        public int view_pattern { get; set; }
        public int priority { get; set; }
        public string flag { get; set; } = "";
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? updated_at { get; set; }
        public List<cSub_image>? sub_images { get; set; }
    }

    public class cSetProductsFlagRequest
    {
        public string flag { get; set; }
    }

    public class cSetProductSetFlagRequest
    {
        public string set_flag { get; set; }
    }



    public class cSetProductsFlagByIDRequest
    {
        public List<cSetProductsFlagByID> products { get; set; } = new List<cSetProductsFlagByID>();
    }

    public class cSetProductsFlagByID
    {
        public long id { get; set; }
        public string flag { get; set; }
    }





}
