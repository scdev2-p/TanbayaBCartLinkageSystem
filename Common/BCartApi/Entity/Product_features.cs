using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCartApi.Entity
{
    // JsonSerializerはパラメータしか変換できないので全て { get; set; } にする事


    /// <summary>
    /// カテゴリーマスタ一覧
    /// </summary>
    public class cProductFeatures
    {
        public List<cProductFeatureGet>? product_features { get; set; }
    }

    /// <summary>
    /// カテゴリーマスタ（取得用）
    /// </summary>
    public class cProductFeatureGet
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string rv_description { get; set; } = "";
        public string description { get; set; } = "";
        public string header_image { get; set; } = "";
        public string top_image { get; set; } = "";
        public string menu_image { get; set; } = "";
        public string meta_title { get; set; } = "";
        public string meta_keywords { get; set; } = "";
        public string meta_description { get; set; } = "";
    }

}
