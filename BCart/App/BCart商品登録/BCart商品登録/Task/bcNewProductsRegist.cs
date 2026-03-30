using BCartApi.Entity;
using BCartApi;
using BCart商品登録.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;

namespace BCart商品登録.Task
{
    /// <summary>
    /// 新規商品の登録処理
    /// </summary>
    internal class bcNewProductsRegist : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        public bcNewProductsRegist()
        {
            this._con = new SqlConnection(Settings.Default.TnbToBCart);
        }

        public void Dispose()
        {
            if(this._con.State == System.Data.ConnectionState.Open)
                this._con.Close();

            this._con.Dispose();
            api.Dispose();
        }


        public bool RegistNew(dsTnbToBCart.S_新規商品差分抽出2Row row)
        {
            if (!Settings.Default.BcApiRegist)
            {
                // Debug用  Api連携OFF
                return true;
            }

            //int cnt = 0;        // 更新データのカウンタ
            //int apiCnt = 0;     // api実行数のカウンタ（上限まで実行）
            string tnb商品管理番号 = "";
            try
            {
                using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
                using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
                {
                    long bcProductsID;

                    // DB登録用レコード
                    dsTnbToBCart.bc登録済商品Row NewRow = dt.Newbc登録済商品Row();

                    // ================================
                    // 商品基本情報の登録
                    // ================================
                    {
                        tnb商品管理番号 = row.商品管理番号;
                        cProductsNew ps = new cProductsNew();
                        ps.name = row.商品名;
                        ps.category_id = Settings.Default.CategoryID;
                        List<string> tmpProductStatus = new List<string>();
                        tmpProductStatus.Add("new");        // 新着
                        switch (row.フロアコード)
                        {
                            case "3":
                                tmpProductStatus.Add("1f");
                                break;
                            case "5":
                                tmpProductStatus.Add("2f");
                                break;
                            case "2":
                            case "7":
                            case "8":
                                tmpProductStatus.Add("3f");
                                break;
                            case "1":
                                tmpProductStatus.Add("4f");
                                break;
                        }
                        /*
                        フロアコード	フロア名	課コード	課	登録者番号	登録日	更新者番号	更新日
                        1	４階売場	4	卸売４課	IKOU	2011-08-07 14:31:19.163	016	2021-08-06 10:41:30.637
                        2	３階営推	7	卸売３課３	IKOU	2011-08-07 14:31:19.163	016	2021-08-06 10:41:30.637
                        3	１階売場	1	卸売１課	IKOU	2011-08-07 14:31:19.163	016	2020-08-08 11:12:17.983
                        4	５課売場	5	営業５課	IKOU	2011-08-07 14:31:19.163	NULL	NULL
                        5	２階売場	2	卸売２課	IKOU	2011-08-07 14:31:19.163	016	2020-08-08 11:12:17.983
                        7	３階売場	3	卸売３課１	IKOU	2011-08-07 14:31:19.163	016	2021-08-06 10:41:30.637
                        8	３階特販	6	卸売３課２	IKOU	2011-08-07 14:31:19.163	016	2021-08-06 10:41:30.637
                        9	営業支援	9	営業支援	IKOU	2011-08-07 14:31:19.163	NULL	NULL
                        */

                        ps.tag = string.Join(',', tmpProductStatus.ToArray());
                        // customは不要
                        ps.view_pattern = 0;
                        ps.priority = 0;
                        ps.flag = "非表示";

                        // 商品非表示グループ
                        List<string> tmpVf = new List<string>();
                        // 海外禁止
                        if (!row.Is海外禁止Null())
                            tmpVf.Add("2");
                        // NET販売NG
                        if (row.WEB販売拒否フラグ)
                            tmpVf.Add("6");
                        ps.view_group_filter = string.Join(',', tmpVf.ToArray());

                        //// カスタム項目5に一旦商品管理番号とバーコードを保存（セット商品登録に必要）
                        //ps.customs = new List<cCustom>();
                        //cCustom cu = new cCustom();
                        //cu.field_id = ProductCustom5_ID;
                        //cu.value = row.商品管理番号 + "," +  row.バーコード;
                        //ps.customs.Add(cu);

                        ps.updated_at = DateTime.Now;

                        cInsertProductsRequest request = new cInsertProductsRequest();
                        request.products.Add(ps);
                        //cnt++;

                        cInsertProductsResponse productResult = this.api.PostCommand<cInsertProductsRequest, cInsertProductsResponse>(commandUrlProducts, request);
                        if (productResult == null || productResult.products == null || request.products.Count != productResult.products.Count)
                        {
                            //Log.ErrWrite("Api登録エラー");
                            return false;
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
                        cProductSetNew ps = new cProductSetNew();
                        ps.product_id = bcProductsID;
                        ps.name = row.商品名;
                        ps.jodai_type = "カスタム";
                        ps.quantity = 1;
                        ps.stock_flag = 0;
                        ps.stock_view_id = 1;
                        ps.stock_few = 5;
                        ps.shipping_group_id = 1;
                        ps.customs.Clear();

                        // カスタム項目1(内部IDは7)にバーコードをセット
                        cProductSetCustom cu = new cProductSetCustom();
                        cu.field_id = ProductSetCustom1_ID;  //  セット情報カスタム項目１のID
                        cu.value = row.バーコード;
                        ps.customs.Add(cu);

                        // 商品価格の取得
                        ps.tax_type_id = row.Is消費税区分Null() || string.IsNullOrEmpty(row.消費税区分) ? 1 : int.Parse(row.消費税区分);
                        ps.jodai = row.Is上代単価Null()? 0 : row.上代単価;
                        ps.unit_price = row.Is価格0Null()? 0 : row.価格0;
                        ps.group_price = new cGroupPrices();
                        ps.group_price.gp1.unit_price = row.Is価格1Null()? 0 : row.価格1;
                        ps.group_price.gp1.fixed_price = row.Is価格1Null()? 0 : row.価格1;
                        ps.group_price.gp2.unit_price = row.Is価格2Null()? 0 : row.価格2;
                        ps.group_price.gp2.fixed_price = row.Is価格2Null()? 0 : row.価格2;
                        ps.group_price.gp3.unit_price = row.Is価格3Null()? 0 : row.価格3;
                        ps.group_price.gp3.fixed_price = row.Is価格3Null()? 0 : row.価格3;
                        ps.group_price.gp4.unit_price = row.Is価格4Null()? 0 : row.価格4;
                        ps.group_price.gp4.fixed_price = row.Is価格4Null()? 0 : row.価格4;
                        ps.group_price.gp5.unit_price = row.Is価格5Null()? 0 : row.価格5;
                        ps.group_price.gp5.fixed_price = row.Is価格5Null()? 0: row.価格5;
                        ps.group_price.gp6.unit_price = row.Is価格6Null()? 0 : row.価格6;
                        ps.group_price.gp6.fixed_price = row.Is価格6Null()? 0 : row.価格6;
                        ps.group_price.gp7.unit_price = row.Is価格7Null()? 0 : row.価格7;
                        ps.group_price.gp7.fixed_price = row.Is価格7Null()? 0 : row.価格7;
                        ps.group_price.gp8.unit_price = row.Is価格8Null()? 0 : row.価格8;
                        ps.group_price.gp8.fixed_price = row.Is価格8Null()? 0 : row.価格8;

                        ps.stock = row.Is数量Null()? 0 : row.数量;

                        // Api用データに追加
                        cProductSetNewRequest setRequest = new cProductSetNewRequest();
                        setRequest.product_sets.Add(ps);

                        cProductSetNewResponse productSetResult = this.api.PostCommand<cProductSetNewRequest, cProductSetNewResponse>(commandUrlProductSets, setRequest);
                        if (productSetResult == null || productSetResult.product_sets == null || productSetResult.product_sets.Count != setRequest.product_sets.Count)
                        {
                            //Log.ErrWrite("Api登録エラー");
                            return false;
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
                return false;
            }
            return true;
        }


        public bool Do(List<dsTnbToBCart.S_新規商品差分抽出2Row> lstProducts)
        {

            if (!Settings.Default.BcApiRegist)
            {
                // Debug用  Api連携OFF
                return true;
            }

            string tnb商品管理番号 = "";
            try
            {
                // 新規商品差分の抽出
                //Log.Write(string.Format("新規追加商品対象件数[{0}]", lstProducts.Count));

                foreach (dsTnbToBCart.S_新規商品差分抽出2Row row in lstProducts)
                {
                    if(!RegistNew(row))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("エラー[{0}]", tnb商品管理番号), ex);
                return false;
            }
            return true;
        }


 
    }
}
