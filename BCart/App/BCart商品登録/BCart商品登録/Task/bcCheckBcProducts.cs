using BCartApi;
using BCartApi.Entity;
using BCart商品登録.AppData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart商品登録.Task
{
    internal class bcCheckBcProducts : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        // 検索結果
        public cProductSetNewResponse PloductSetList { get; set; }


        public bcCheckBcProducts()
        {



        }

        public void Dispose()
        {

        }

        /// <summary>
        /// BCartの商品セット情報を取得
        /// </summary>
        /// <returns></returns>
        public dsTnbToBCart.bc商品バーコード登録リストDataTable getBcProductByBarcode(string barcode)
        {
            dsTnbToBCart.bc商品バーコード登録リストDataTable ret = new dsTnbToBCart.bc商品バーコード登録リストDataTable();


            // Bカートのセット情報検索で同一のバーコードがあるか取得する


            // api
            ApiCommandParam[] prmProductSetGet = { new ApiCommandParam("limit", "100"), new ApiCommandParam("offset", "0"), new ApiCommandParam(string.Format("customs[{0}]", ProductSetCustom1_ID), barcode) };
            cProductSetNewResponse retProducts = api.GetListCommand<cProductSetNewResponse>(commandUrlProductSets, prmProductSetGet);
            if (retProducts == null || retProducts.product_sets == null)
            {
                return ret;
            }

            foreach (var productRow in retProducts.product_sets)
            {
                var p = ret.Newbc商品バーコード登録リストRow();
                p.ProductsID = productRow.product_id.ToString();
                p.ProductSetID = productRow.id.ToString();
                p.ProductSetName = productRow.name;
                p.ProductSetCD = productRow.product_no;
                foreach(var c in productRow.customs)
                {
                    if(c.field_id == ProductSetCustom1_ID)
                    {
                        p.Barcode = c.value;
                    }
                }
                p.Jodai = productRow.jodai.ToString();
                p.Stock = productRow.stock.ToString();

                // 商品基本を取得
                cProduct tmpPro = api.GetCommandId<cProduct>(commandUrlProducts, productRow.product_id.ToString());
                if(tmpPro != null && tmpPro.product != null)
                {
                    p.ProductsName = tmpPro.product.name;
                }

                ret.Addbc商品バーコード登録リストRow(p);
            }

            return ret; 
        }



    }
}
