using BCartApi.Entity;
using BCartApi;
using BCart商品登録.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BCart商品登録.Task
{
    internal class bcNewProductsDetailRegist : IDisposable
    {
        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom2_ID = 5;    // 基本カスタム項目２のID  メーカー
        private const int ProductCustom4_ID = 11;    // 基本カスタム項目4のID  備考
        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        public bcNewProductsDetailRegist()
        {
            this._con = new SqlConnection(Settings.Default.TnbToBCart);
        }

        public void Dispose()
        {
            if (this._con.State == System.Data.ConnectionState.Open)
                this._con.Close();

            this._con.Dispose();
            api.Dispose();
        }

        public long RegistNew(dsTnbToBCart.tnb商品情報Row row, cProductsNewDetail ps, string setName, string productNo )
        {
            if (!Settings.Default.BcApiRegist)
            {
                // Debug用  Api連携OFF
                return 0;
            }

            long bcProductsID;

            //int cnt = 0;        // 更新データのカウンタ
            //int apiCnt = 0;     // api実行数のカウンタ（上限まで実行）
            string tnb商品管理番号 = "";
            try
            {
                using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
                using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
                {

                    // DB登録用レコード
                    dsTnbToBCart.bc登録済商品Row NewRow = dt.Newbc登録済商品Row();

                    // ================================
                    // 商品基本情報の登録
                    // ================================
                    {
                        tnb商品管理番号 = row.商品管理番号;

                        cInsertProductsDetailRequest request = new cInsertProductsDetailRequest();
                        request.products.Add(ps);

                        cInsertProductsResponse productResult = api.PostCommand<cInsertProductsDetailRequest, cInsertProductsResponse>("products", request);
                        if (productResult == null || productResult.products == null || request.products.Count != productResult.products.Count)
                        {
                            //Log.ErrWrite("Api登録エラー");
                            return -1;
                        }

                        bcProductsID = productResult.products[0].id;   // 登録されたBCartの商品基本情報IDを取得（セット登録用）

                        NewRow.tnb商品管理番号 = row.商品管理番号;
                        NewRow.Set削除フラグNull();
                        NewRow.基本_Bカート商品ID = productResult.products[0].id;
                        NewRow.基本_商品名 = productResult.products[0].name;
                        NewRow.基本_商品特徴 = productResult.products[0].tag;
                        NewRow.基本_状態 = productResult.products[0].flag;
                        NewRow.基本_商品非表示グループ = productResult.products[0].view_group_filter;
                        NewRow.EC移行フラグ = false;

                    }

                    // ================================
                    // 商品セット情報の登録
                    // ================================
                    {
                        cProductSetNew pss = new cProductSetNew();
                        pss.product_no = productNo;
                        pss.product_id = bcProductsID;
                        pss.name = setName;     // セット名
                        pss.jodai_type = "カスタム";
                        pss.quantity = 1;
                        pss.stock_flag = 0;
                        pss.stock_view_id = 1;
                        pss.stock_few = 5;
                        pss.shipping_group_id = 1;
                        pss.customs.Clear();

                        // カスタム項目1(内部IDは7)にバーコードをセット
                        cProductSetCustom cu = new cProductSetCustom();
                        cu.field_id = ProductSetCustom1_ID;  //  セット情報カスタム項目１のID
                        cu.value = row.バーコード;
                        pss.customs.Add(cu);

                        // 商品価格の取得
                        pss.tax_type_id = row.Is消費税区分Null() || string.IsNullOrEmpty(row.消費税区分) ? 1 : int.Parse(row.消費税区分);
                        pss.jodai = row.Is上代単価Null() ? 0 : row.上代単価;
                        pss.unit_price = row.Is価格0Null() ? 0 : row.価格0;
                        pss.group_price = new cGroupPrices();
                        pss.group_price.gp1.unit_price = row.Is価格1Null() ? 0 : row.価格1;
                        pss.group_price.gp1.fixed_price = row.Is価格1Null() ? 0 : row.価格1;
                        pss.group_price.gp2.unit_price = row.Is価格2Null() ? 0 : row.価格2;
                        pss.group_price.gp2.fixed_price = row.Is価格2Null() ? 0 : row.価格2;
                        pss.group_price.gp3.unit_price = row.Is価格3Null() ? 0 : row.価格3;
                        pss.group_price.gp3.fixed_price = row.Is価格3Null() ? 0 : row.価格3;
                        pss.group_price.gp4.unit_price = row.Is価格4Null() ? 0 : row.価格4;
                        pss.group_price.gp4.fixed_price = row.Is価格4Null() ? 0 : row.価格4;
                        pss.group_price.gp5.unit_price = row.Is価格5Null() ? 0 : row.価格5;
                        pss.group_price.gp5.fixed_price = row.Is価格5Null() ? 0 : row.価格5;
                        pss.group_price.gp6.unit_price = row.Is価格6Null() ? 0 : row.価格6;
                        pss.group_price.gp6.fixed_price = row.Is価格6Null() ? 0 : row.価格6;
                        pss.group_price.gp7.unit_price = row.Is価格7Null() ? 0 : row.価格7;
                        pss.group_price.gp7.fixed_price = row.Is価格7Null() ? 0 : row.価格7;
                        pss.group_price.gp8.unit_price = row.Is価格8Null() ? 0 : row.価格8;
                        pss.group_price.gp8.fixed_price = row.Is価格8Null() ? 0 : row.価格8;

                        pss.stock = row.Is数量Null() ? 0 : row.数量;

                        // Api用データに追加
                        cProductSetNewRequest setRequest = new cProductSetNewRequest();
                        setRequest.product_sets.Add(pss);

                        cProductSetNewResponse productSetResult = this.api.PostCommand<cProductSetNewRequest, cProductSetNewResponse>(commandUrlProductSets, setRequest);
                        if (productSetResult == null || productSetResult.product_sets == null || productSetResult.product_sets.Count != setRequest.product_sets.Count)
                        {
                            //Log.ErrWrite("Api登録エラー");
                            return -1;
                        }

                        NewRow.セット_BカートセットID = productSetResult.product_sets[0].id;
                        foreach (var tmp in productSetResult.product_sets[0].customs)
                        {
                            if (tmp.field_id == ProductSetCustom1_ID)
                            {
                                NewRow.セット_カスタム項目1 = tmp.value;
                                break;
                            }
                        }

                        NewRow.セット_セット名 = productSetResult.product_sets[0].name;

                        NewRow.Setセット_カスタム項目2Null();
                        NewRow.セット_上代 = productSetResult.product_sets[0].jodai;
                        NewRow.セット_単価 = productSetResult.product_sets[0].unit_price;
                        NewRow.セット_在庫 = (int)productSetResult.product_sets[0].stock;
                        NewRow.セット_在庫制限 = productSetResult.product_sets[0].stock_flag;
                        NewRow.セット_グループ価格1 = productSetResult.product_sets[0].group_price.gp1.unit_price;
                        NewRow.セット_グループ価格2 = productSetResult.product_sets[0].group_price.gp2.unit_price;
                        NewRow.セット_グループ価格3 = productSetResult.product_sets[0].group_price.gp3.unit_price;
                        NewRow.セット_グループ価格4 = productSetResult.product_sets[0].group_price.gp4.unit_price;
                        NewRow.セット_グループ価格5 = productSetResult.product_sets[0].group_price.gp5.unit_price;
                        NewRow.セット_グループ価格6 = productSetResult.product_sets[0].group_price.gp6.unit_price;
                        NewRow.セット_グループ価格7 = productSetResult.product_sets[0].group_price.gp7.unit_price;
                        NewRow.セット_グループ価格8 = productSetResult.product_sets[0].group_price.gp8.unit_price;
                        NewRow.Setセット_グループ価格9Null();
                        NewRow.Setセット_グループ価格10Null();

                    }

                    // 登録済商品の登録
                    dt.Addbc登録済商品Row(NewRow);
                    ta.Update(dt);

                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("エラー[{0}]", tnb商品管理番号), ex);
                return -1;
            }
            return bcProductsID;
        }


    }
}
