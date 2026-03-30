using BCartApi;
using BCartApi.Entity;
using BCart商品登録.AppData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCart商品登録.AppData;
using BCartApi;

namespace BCart商品登録.Task
{
    internal class bcProductsImport : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        public int RegistCount { get; set; }

        public bcProductsImport()
        {
            this._con = new SqlConnection(Settings.Default.TnbToBCart);

            this.RegistCount = 0;
        }

        public void Dispose()
        {
            if (this._con.State == System.Data.ConnectionState.Open)
                this._con.Close();

            this._con.Dispose();
            api.Dispose();
        }


        public bool ImportProductsByRange(long productIdFrom, long productIdTo, bool isOverride)
        {
            // BCart商品基本情報を取得

            List<string> idList = new List<string>();
            for (long i = productIdFrom; i <= productIdTo; i++)
            {
                idList.Add(i.ToString());
            }


            // api
            ApiCommandParam[] prmProductGet = { new ApiCommandParam("limit", "100"), new ApiCommandParam("ids", string.Join(',', idList.ToArray())) };
            cProducts retProducts = api.GetListCommand<cProducts>(commandUrlProducts, prmProductGet);
            if (retProducts == null || retProducts.products == null)
            {
                return false;
            }
    
            foreach(var productRow in retProducts.products)
            {
                // 商品の登録
                if(!import登録済商品(productRow, isOverride))
                {

                    return false;
                }
            }


            return true;
        }

        public bool ImportProductsByID(long productId, bool isOverride)
        {
            // BCart商品基本情報を取得


            // api
            cProduct retProducts = api.GetCommandId<cProduct>(commandUrlProducts, productId.ToString());
            if (retProducts == null || retProducts.product == null)
            {
                return false;
            }

            // 商品の登録
            if (!import登録済商品(retProducts.product, isOverride))
            {

                return false;
            }

            return true;
        }



        private bool import登録済商品(cProductGet productRow, bool isOverride)
        {
            // 商品毎のセット情報を取得
            ApiCommandParam[] prmSetGet = { new ApiCommandParam("limit", "100"), new ApiCommandParam("product_id", productRow.id.ToString()) };
            cProductSetNewResponse retProductSet = api.GetListCommand<cProductSetNewResponse>(commandUrlProductSets, prmSetGet);
            if (retProductSet == null || retProductSet.product_sets == null)
            {

                return false;
            }

            if (retProductSet.product_sets.Count == 0)
            {
                // セット情報の無い商品はスキップ
                return true;
            }
            using (SqlTnbToBCart sql = new SqlTnbToBCart())
            using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter taBc = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
            //using (AppData.dsTnbToBCartTableAdapters.M_商品TableAdapter taMp = new AppData.dsTnbToBCartTableAdapters.M_商品TableAdapter())
            //using (dsTnbToBCart.M_商品DataTable dtMp = new dsTnbToBCart.M_商品DataTable())
            {
                bool existProduct = false;
                if (sql.GetProductsCount(productRow.id) > 0)
                {
                    existProduct = true;
                }

                foreach (var setRow in retProductSet.product_sets)
                {
                    // 商品基本とセット情報をｂｃ登録済商品に保存


                    string barcode = "";
                    if (setRow.customs != null)
                    {
                        foreach (var custom in setRow.customs)
                        {
                            if (custom.field_id == ProductSetCustom1_ID)
                            {
                                barcode = custom.value;
                                break;
                            }
                        }
                    }

                    // =====================================================================
                    // 登録データの編集

                    // バーコードから基幹の商品マスタを取得
                    //taMp.FillByBarcode(dtMp, barcode);

                    string tnbProductID = sql.GetTnbProductIDByBarcode(barcode);

                    bool existProductSet = false;
                    if (sql.GetProductSetCount(setRow.id) > 0)
                    {
                        existProductSet = true;
                    }

                    using (dsTnbToBCart.bc登録済商品DataTable dtBc = new dsTnbToBCart.bc登録済商品DataTable())
                    {

                        dsTnbToBCart.bc登録済商品Row importRow = dtBc.Newbc登録済商品Row();
                        importRow.tnb商品管理番号 = tnbProductID;   // dtMp.Count > 0 ? dtMp[0].商品管理番号 : "";
                        importRow.Set削除フラグNull();
                        importRow.基本_Bカート商品ID = productRow.id;
                        importRow.基本_商品名 = productRow.name == null? "" : productRow.name;
                        importRow.基本_商品特徴 = productRow.tag == null ? "" : productRow.tag;
                        importRow.基本_画像 = productRow.image == null ? "" : productRow.image;
                        importRow.基本_状態 = productRow.flag == null ? "" : productRow.flag;
                        importRow.基本_商品非表示グループ = productRow.view_group_filter == null? "" : productRow.view_group_filter.Length > 20? productRow.view_group_filter.Substring(0, 20) : productRow.view_group_filter;
                        importRow.Set基本_カスタム項目5Null();      // EC-CubeIDはもう不要

                        importRow.Setサブ画像1Null();
                        importRow.Setサブ画像2Null();
                        importRow.Setサブ画像3Null();
                        importRow.Setサブ画像4Null();
                        importRow.Setサブ画像5Null();
                        importRow.Setサブ画像6Null();

                        if (productRow.sub_images != null && productRow.sub_images.image1 != null && productRow.sub_images.image1.image != null)
                            importRow.サブ画像1 = productRow.sub_images.image1.image;
                        if (productRow.sub_images != null && productRow.sub_images.image2 != null && productRow.sub_images.image2.image != null)
                            importRow.サブ画像2 = productRow.sub_images.image2.image;
                        if (productRow.sub_images != null && productRow.sub_images.image3 != null && productRow.sub_images.image3.image != null)
                            importRow.サブ画像3 = productRow.sub_images.image3.image;
                        if (productRow.sub_images != null && productRow.sub_images.image4 != null && productRow.sub_images.image4.image != null)
                            importRow.サブ画像4 = productRow.sub_images.image4.image;
                        if (productRow.sub_images != null && productRow.sub_images.image5 != null && productRow.sub_images.image5.image != null)
                            importRow.サブ画像5 = productRow.sub_images.image5.image;
                        if (productRow.sub_images != null && productRow.sub_images.image6 != null && productRow.sub_images.image6.image != null)
                            importRow.サブ画像6 = productRow.sub_images.image6.image;

                        importRow.セット_BカートセットID = setRow.id;
                        importRow.セット_カスタム項目1 = barcode;
                        importRow.Setセット_カスタム項目2Null();


                        // 在庫と価格はゼロとする
                        // 同期処理で行う

                        importRow.セット_上代 = setRow.jodai == null ? 0 : setRow.jodai;
                        importRow.セット_単価 = setRow.unit_price == null ? 0: setRow.unit_price;
                        importRow.セット_在庫 = setRow.stock == null ? 0 : (int)setRow.stock;
                        importRow.セット_在庫制限 = setRow.stock_flag == null ? 0 : setRow.stock_flag;
                        importRow.セット_グループ価格1 = setRow.group_price.gp1 == null ? 0 : setRow.group_price.gp1.unit_price == null ? 0 : setRow.group_price.gp1.unit_price;
                        importRow.セット_グループ価格2 = setRow.group_price.gp2 == null ? 0 : setRow.group_price.gp2.unit_price == null ? 0 : setRow.group_price.gp2.unit_price;
                        importRow.セット_グループ価格3 = setRow.group_price.gp3 == null ? 0 : setRow.group_price.gp3.unit_price == null ? 0 : setRow.group_price.gp3.unit_price;
                        importRow.セット_グループ価格4 = setRow.group_price.gp4 == null ? 0 : setRow.group_price.gp4.unit_price == null ? 0 : setRow.group_price.gp4.unit_price;
                        importRow.セット_グループ価格5 = setRow.group_price.gp5 == null ? 0 : setRow.group_price.gp5.unit_price == null ? 0 : setRow.group_price.gp5.unit_price;
                        importRow.セット_グループ価格6 = setRow.group_price.gp6 == null ? 0 : setRow.group_price.gp6.unit_price == null ? 0 : setRow.group_price.gp6.unit_price;
                        importRow.セット_グループ価格7 = setRow.group_price.gp7 == null ? 0 : setRow.group_price.gp7.unit_price == null ? 0 : setRow.group_price.gp7.unit_price;
                        importRow.セット_グループ価格8 = setRow.group_price.gp8 == null ? 0 : setRow.group_price.gp8.unit_price == null ? 0 : setRow.group_price.gp8.unit_price;
                        importRow.Setセット_グループ価格9Null();
                        importRow.Setセット_グループ価格10Null();
                        importRow.EC移行フラグ = false;
                        importRow.セット_セット名 = setRow.name == null? "" : setRow.name;
                        // =====================================================================
                        dtBc.Addbc登録済商品Row(importRow);

                        // 商品基本もセットも無い場合
                        // 商品基本とセットをInsert
                        if (!existProduct && !existProductSet)
                        {
                            // InsetはDataSetの機能で行う
                            taBc.Update(dtBc);
                            RegistCount++;  // 登録件数をカウントアップ
                        }
                        // 商品基本はあるがセットが無い場合
                        // 商品基本部分は一律でUpdate（念のため）
                        // 商品セットをInsert
                        else if (existProduct && !existProductSet)
                        {
                            sql.updateBC登録済商品_基本情報(importRow);

                            // InsetはDataSetの機能で行う
                            taBc.Update(dtBc);
                            RegistCount++;  // 登録件数をカウントアップ
                        }
                        // 商品基本もセットもある場合
                        // 商品基本とセットをUpdate(上書き指定の場合)
                        else if (isOverride)
                        {
                            sql.updateBC登録済商品(importRow);
                            RegistCount++;  // 登録件数をカウントアップ
                        }

                    }
                }
            }
            return true;
        }





        

    }
}
