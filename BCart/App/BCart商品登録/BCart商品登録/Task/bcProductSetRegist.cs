using BCartApi;
using BCartApi.Entity;
using BCart商品登録.AppData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart商品登録.Task
{
    internal class bcProductSetRegist : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        public int RegistCount { get; set; }

        public bcProductSetRegist()
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

        /// <summary>
        /// セット情報の追加
        /// </summary>
        /// <returns></returns>
        public bool RegistNewSet(long productID, string setName, string setNo , string barcode, string tnb商品管理番号)
        {

            cProductSetNew ps = new cProductSetNew();
            ps.product_id = productID;
            ps.product_no = setNo;
            ps.name = setName;
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
            cu.value = barcode;
            ps.customs.Add(cu);

            // 商品価格の取得
            ps.tax_type_id = 1;
            ps.jodai = 0;
            ps.unit_price = 0;
            ps.group_price = new cGroupPrices();
            ps.group_price.gp1.unit_price = 0;
            ps.group_price.gp1.fixed_price = 0;
            ps.group_price.gp2.unit_price = 0;
            ps.group_price.gp2.fixed_price = 0;
            ps.group_price.gp3.unit_price = 0;
            ps.group_price.gp3.fixed_price = 0;
            ps.group_price.gp4.unit_price = 0;
            ps.group_price.gp4.fixed_price = 0;
            ps.group_price.gp5.unit_price = 0;
            ps.group_price.gp5.fixed_price = 0;
            ps.group_price.gp6.unit_price = 0;
            ps.group_price.gp6.fixed_price = 0;
            ps.group_price.gp7.unit_price = 0;
            ps.group_price.gp7.fixed_price = 0;
            ps.group_price.gp8.unit_price = 0;
            ps.group_price.gp8.fixed_price = 0;
            // 在庫
            ps.stock = 0;

            using (AppData.dsTnbToBCartTableAdapters.vwクラス別商品価格TableAdapter taPrice = new AppData.dsTnbToBCartTableAdapters.vwクラス別商品価格TableAdapter())
            using (dsTnbToBCart.vwクラス別商品価格DataTable dtPrice = new dsTnbToBCart.vwクラス別商品価格DataTable())
            using (AppData.dsTnbToBCartTableAdapters.vw商品在庫TableAdapter taStock = new AppData.dsTnbToBCartTableAdapters.vw商品在庫TableAdapter())
            using (dsTnbToBCart.vw商品在庫DataTable dtStock = new dsTnbToBCart.vw商品在庫DataTable())
            {
                taPrice.FillByBarcode(dtPrice, barcode);
                if(dtPrice.Count > 0)
                {
                    // 商品価格の取得
                    ps.jodai = dtPrice[0].Is上代単価Null() ? 0 : dtPrice[0].上代単価;
                    ps.unit_price = dtPrice[0].Is価格Null() ? 0 : dtPrice[0].価格;
                    ps.tax_type_id = string.IsNullOrEmpty(dtPrice[0].消費税区分)? 1 : int.Parse(dtPrice[0].消費税区分);
                    ps.group_price = new cGroupPrices();
                    ps.group_price.gp1.unit_price = dtPrice[0].Is価格1Null() ? 0 : dtPrice[0].価格1;
                    ps.group_price.gp1.fixed_price = dtPrice[0].Is価格1Null() ? 0 : dtPrice[0].価格1;
                    ps.group_price.gp2.unit_price = dtPrice[0].Is価格2Null() ? 0 : dtPrice[0].価格2;
                    ps.group_price.gp2.fixed_price = dtPrice[0].Is価格2Null() ? 0 : dtPrice[0].価格2;
                    ps.group_price.gp3.unit_price = dtPrice[0].Is価格3Null() ? 0 : dtPrice[0].価格3;
                    ps.group_price.gp3.fixed_price = dtPrice[0].Is価格3Null() ? 0 : dtPrice[0].価格3;
                    ps.group_price.gp4.unit_price = dtPrice[0].Is価格4Null() ? 0 : dtPrice[0].価格4;
                    ps.group_price.gp4.fixed_price = dtPrice[0].Is価格4Null() ? 0 : dtPrice[0].価格4;
                    ps.group_price.gp5.unit_price = dtPrice[0].Is価格5Null() ? 0 : dtPrice[0].価格5;
                    ps.group_price.gp5.fixed_price = dtPrice[0].Is価格5Null() ? 0 : dtPrice[0].価格5;
                    ps.group_price.gp6.unit_price = dtPrice[0].Is価格6Null() ? 0 : dtPrice[0].価格6;
                    ps.group_price.gp6.fixed_price = dtPrice[0].Is価格6Null() ? 0 : dtPrice[0].価格6;
                    ps.group_price.gp7.unit_price = dtPrice[0].Is価格7Null() ? 0 : dtPrice[0].価格7;
                    ps.group_price.gp7.fixed_price = dtPrice[0].Is価格7Null() ? 0 : dtPrice[0].価格7;
                    ps.group_price.gp8.unit_price = dtPrice[0].Is価格8Null() ? 0 : dtPrice[0].価格8;
                    ps.group_price.gp8.fixed_price = dtPrice[0].Is価格8Null() ? 0 : dtPrice[0].価格8;

                }

                taStock.FillByBarcode(dtStock, barcode);
                if(dtStock.Count > 0)
                {
                    // 在庫
                    ps.stock = dtStock[0].Is数量Null() ? 0 : dtStock[0].数量;
                }
            }


            // Api用データに追加
            cProductSetNewRequest setRequest = new cProductSetNewRequest();
            setRequest.product_sets.Add(ps);

            cProductSetNewResponse productSetResult = this.api.PostCommand<cProductSetNewRequest, cProductSetNewResponse>(commandUrlProductSets, setRequest);
            if (productSetResult == null || productSetResult.product_sets == null || productSetResult.product_sets.Count != setRequest.product_sets.Count)
            {
                Log.ErrWrite("Api登録エラー");
                return false;
            }

            long bcSetID = productSetResult.product_sets[0].id;

            using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
            using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
            using (dsTnbToBCart.bc登録済商品DataTable dtNew = new dsTnbToBCart.bc登録済商品DataTable())
            using (SqlTnbToBCart sql = new SqlTnbToBCart())
            {
                ta.FillByProductID(dt, productID);

                if (dt.Count == 0)
                {
                    Log.ErrWrite(string.Format("bc登録済商品取得エラー ProsuctID[{0}]", productID));
                    return false;
                }

                var newRow = dtNew.Newbc登録済商品Row();

                newRow.tnb商品管理番号 = tnb商品管理番号;
                newRow.Set削除フラグNull();
                newRow.基本_Bカート商品ID = dt[0].基本_Bカート商品ID;
                newRow.基本_商品名 = dt[0].基本_商品名;
                if (dt[0].Is基本_商品特徴Null()) { newRow.Set基本_商品特徴Null(); } else { newRow.基本_商品特徴 = dt[0].基本_商品特徴; }
                if (dt[0].Is基本_画像Null()) { newRow.Set基本_画像Null(); } else { newRow.基本_画像 = dt[0].基本_画像; }
                newRow.基本_状態 = dt[0].基本_状態;
                if (dt[0].Is基本_商品非表示グループNull()) { newRow.基本_商品非表示グループ = ""; } else { newRow.基本_商品非表示グループ = dt[0].基本_商品非表示グループ; }
                newRow.Set基本_カスタム項目5Null();
                if (dt[0].Isサブ画像1Null()) { newRow.Setサブ画像1Null(); } else { newRow.サブ画像1 = dt[0].サブ画像1; }
                if (dt[0].Isサブ画像2Null()) { newRow.Setサブ画像2Null(); } else { newRow.サブ画像1 = dt[0].サブ画像1; }
                if (dt[0].Isサブ画像3Null()) { newRow.Setサブ画像3Null(); } else { newRow.サブ画像2 = dt[0].サブ画像2; }
                if (dt[0].Isサブ画像4Null()) { newRow.Setサブ画像4Null(); } else { newRow.サブ画像3 = dt[0].サブ画像3; }
                if (dt[0].Isサブ画像5Null()) { newRow.Setサブ画像5Null(); } else { newRow.サブ画像4 = dt[0].サブ画像4; }
                if (dt[0].Isサブ画像6Null()) { newRow.Setサブ画像6Null(); } else { newRow.サブ画像5 = dt[0].サブ画像5; }

                newRow.セット_BカートセットID = bcSetID;
                newRow.セット_カスタム項目1 = barcode;
                newRow.Setセット_カスタム項目2Null();
                newRow.セット_上代 = (int)productSetResult.product_sets[0].jodai;
                newRow.セット_単価 = (int)productSetResult.product_sets[0].unit_price;
                newRow.セット_在庫 = (int)productSetResult.product_sets[0].stock;
                newRow.セット_在庫制限 = productSetResult.product_sets[0].stock_flag;
                newRow.セット_グループ価格1 = (int)productSetResult.product_sets[0].group_price.gp1.unit_price;
                newRow.セット_グループ価格2 = productSetResult.product_sets[0].group_price.gp2.unit_price;
                newRow.セット_グループ価格3 = productSetResult.product_sets[0].group_price.gp3.unit_price;
                newRow.セット_グループ価格4 = productSetResult.product_sets[0].group_price.gp4.unit_price;
                newRow.セット_グループ価格5 = productSetResult.product_sets[0].group_price.gp5.unit_price;
                newRow.セット_グループ価格6 = productSetResult.product_sets[0].group_price.gp6.unit_price;
                newRow.セット_グループ価格7 = productSetResult.product_sets[0].group_price.gp7.unit_price;
                newRow.セット_グループ価格8 = productSetResult.product_sets[0].group_price.gp8.unit_price;
                newRow.Setセット_グループ価格9Null();
                newRow.Setセット_グループ価格10Null();
                newRow.EC移行フラグ = false;
                newRow.セット_セット名 = setName;

                dtNew.Addbc登録済商品Row(newRow);
                ta.Update(dtNew);
            }

            return true;
        }


        /// <summary>
        /// セット情報の更新
        /// </summary>
        /// <returns></returns>
        public bool UpdateSet(long productID, long setID, string setName, string setNo, string barcode, string tnb商品管理番号)
        {
            cProductSetCustomByID ps = new cProductSetCustomByID();
            ps.name = setName;
            ps.product_cd = setNo;
            ps.customs.Add(new cProductSetCustom() { field_id = ProductSetCustom1_ID, value = barcode });

            // 商品価格の取得
            ps.jodai = 0;
            ps.unit_price = 0;
            ps.tax_type_id = 1;
            ps.group_price = new cGroupPrices();
            ps.group_price.gp1.unit_price = 0;
            ps.group_price.gp1.fixed_price = 0;
            ps.group_price.gp2.unit_price = 0;
            ps.group_price.gp2.fixed_price = 0;
            ps.group_price.gp3.unit_price = 0;
            ps.group_price.gp3.fixed_price = 0;
            ps.group_price.gp4.unit_price = 0;
            ps.group_price.gp4.fixed_price = 0;
            ps.group_price.gp5.unit_price = 0;
            ps.group_price.gp5.fixed_price = 0;
            ps.group_price.gp6.unit_price = 0;
            ps.group_price.gp6.fixed_price = 0;
            ps.group_price.gp7.unit_price = 0;
            ps.group_price.gp7.fixed_price = 0;
            ps.group_price.gp8.unit_price = 0;
            ps.group_price.gp8.fixed_price = 0;
            // 在庫
            ps.stock = 0;

            // バーコードが変わるので在庫・価格も変わる
            using (AppData.dsTnbToBCartTableAdapters.vwクラス別商品価格TableAdapter taPrice = new AppData.dsTnbToBCartTableAdapters.vwクラス別商品価格TableAdapter())
            using (dsTnbToBCart.vwクラス別商品価格DataTable dtPrice = new dsTnbToBCart.vwクラス別商品価格DataTable())
            using (AppData.dsTnbToBCartTableAdapters.vw商品在庫TableAdapter taStock = new AppData.dsTnbToBCartTableAdapters.vw商品在庫TableAdapter())
            using (dsTnbToBCart.vw商品在庫DataTable dtStock = new dsTnbToBCart.vw商品在庫DataTable())
            {
                taPrice.FillByBarcode(dtPrice, barcode);
                if (dtPrice.Count > 0)
                {
                    // 商品価格の取得
                    ps.jodai = dtPrice[0].Is上代単価Null() ? 0 : dtPrice[0].上代単価;
                    ps.unit_price = dtPrice[0].Is価格Null() ? 0 : dtPrice[0].価格;
                    ps.tax_type_id = string.IsNullOrEmpty(dtPrice[0].消費税区分) ? 1 : int.Parse(dtPrice[0].消費税区分);
                    ps.group_price = new cGroupPrices();
                    ps.group_price.gp1.unit_price = dtPrice[0].Is価格1Null() ? 0 : dtPrice[0].価格1;
                    ps.group_price.gp1.fixed_price = dtPrice[0].Is価格1Null() ? 0 : dtPrice[0].価格1;
                    ps.group_price.gp2.unit_price = dtPrice[0].Is価格2Null() ? 0 : dtPrice[0].価格2;
                    ps.group_price.gp2.fixed_price = dtPrice[0].Is価格2Null() ? 0 : dtPrice[0].価格2;
                    ps.group_price.gp3.unit_price = dtPrice[0].Is価格3Null() ? 0 : dtPrice[0].価格3;
                    ps.group_price.gp3.fixed_price = dtPrice[0].Is価格3Null() ? 0 : dtPrice[0].価格3;
                    ps.group_price.gp4.unit_price = dtPrice[0].Is価格4Null() ? 0 : dtPrice[0].価格4;
                    ps.group_price.gp4.fixed_price = dtPrice[0].Is価格4Null() ? 0 : dtPrice[0].価格4;
                    ps.group_price.gp5.unit_price = dtPrice[0].Is価格5Null() ? 0 : dtPrice[0].価格5;
                    ps.group_price.gp5.fixed_price = dtPrice[0].Is価格5Null() ? 0 : dtPrice[0].価格5;
                    ps.group_price.gp6.unit_price = dtPrice[0].Is価格6Null() ? 0 : dtPrice[0].価格6;
                    ps.group_price.gp6.fixed_price = dtPrice[0].Is価格6Null() ? 0 : dtPrice[0].価格6;
                    ps.group_price.gp7.unit_price = dtPrice[0].Is価格7Null() ? 0 : dtPrice[0].価格7;
                    ps.group_price.gp7.fixed_price = dtPrice[0].Is価格7Null() ? 0 : dtPrice[0].価格7;
                    ps.group_price.gp8.unit_price = dtPrice[0].Is価格8Null() ? 0 : dtPrice[0].価格8;
                    ps.group_price.gp8.fixed_price = dtPrice[0].Is価格8Null() ? 0 : dtPrice[0].価格8;

                }

                taStock.FillByBarcode(dtStock, barcode);
                if (dtStock.Count > 0)
                {
                    // 在庫
                    ps.stock = dtStock[0].Is数量Null() ? 0 : dtStock[0].数量;
                }
            }



            // api
            cProductSetResponse productSetResult = api.PatchCommandId<cProductSetCustomByID, cProductSetResponse>(commandUrlProductSets, setID.ToString(), ps);
            if (productSetResult == null || productSetResult.product_set == null)
            {
                Log.ErrWrite(string.Format("Apiエラー ProsuctID[{0}] SetID[{1}]", productID, setID));
                return false;
            }

            using(AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
            using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
            using(SqlTnbToBCart sql = new SqlTnbToBCart())
            {
                ta.FillByID(dt, productID, setID);

                if(dt.Count == 0)
                {
                    Log.ErrWrite(string.Format("bc登録済商品取得エラー ProsuctID[{0}] SetID[{1}]", productID, setID));
                    return false;
                }

                // 在庫変動のフラグを判定
                if (dt[0].セット_在庫 > 0 && (int)productSetResult.product_set.stock == 0)
                {
                    if (!setZeroStockDate(productID, setID))
                        return false;
                }

                else if (dt[0].セット_在庫 == 0 && (int)productSetResult.product_set.stock > 0)
                {
                    if (!setBackInStock(productID, setID))
                        return false;
                }


                dt[0].tnb商品管理番号 = tnb商品管理番号;        // 基幹の商品管理番号も変わる
                dt[0].セット_セット名 = setName;
                dt[0].セット_カスタム項目1 = barcode;

                dt[0].セット_上代 = (int)productSetResult.product_set.jodai;
                dt[0].セット_単価 = (int)productSetResult.product_set.unit_price;

                dt[0].セット_在庫 = (int)productSetResult.product_set.stock;
                dt[0].セット_在庫制限 = productSetResult.product_set.stock_flag;

                dt[0].セット_グループ価格1 = (int)productSetResult.product_set.group_price.gp1.unit_price;
                dt[0].セット_グループ価格2 = productSetResult.product_set.group_price.gp2.unit_price;
                dt[0].セット_グループ価格3 = productSetResult.product_set.group_price.gp3.unit_price;
                dt[0].セット_グループ価格4 = productSetResult.product_set.group_price.gp4.unit_price;
                dt[0].セット_グループ価格5 = productSetResult.product_set.group_price.gp5.unit_price;
                dt[0].セット_グループ価格6 = productSetResult.product_set.group_price.gp6.unit_price;
                dt[0].セット_グループ価格7 = productSetResult.product_set.group_price.gp7.unit_price;
                dt[0].セット_グループ価格8 = productSetResult.product_set.group_price.gp8.unit_price;
                dt[0].Setセット_グループ価格9Null();
                dt[0].Setセット_グループ価格10Null();

                sql.updateBC登録済商品_セット情報(dt[0]);
            }

            return true;
        }

        private bool setZeroStockDate(long productID, long setID)
        {
            try
            {
                using (AppData.dsTnbToBCartTableAdapters.bc商品ゼロ在庫TableAdapter taZeroStock = new AppData.dsTnbToBCartTableAdapters.bc商品ゼロ在庫TableAdapter())
                using (dsTnbToBCart.bc商品ゼロ在庫DataTable dtZeroStock = new dsTnbToBCart.bc商品ゼロ在庫DataTable())
                {
                    // 在庫がゼロになった場合
                    // ゼロになった日付をセット
                    // 既にセットされている場合は何もしない
                    taZeroStock.FillByID(dtZeroStock, productID, setID);
                    if (dtZeroStock.Count > 0 && dtZeroStock[0].Iszero_stock_dayNull())
                    {
                        // 更新
                        dtZeroStock[0].zero_stock_day = DateTime.Now;
                        taZeroStock.Update(dtZeroStock);
                    }
                    else
                    {
                        // 新規
                        var newRow = dtZeroStock.Newbc商品ゼロ在庫Row();
                        newRow.基本_Bカート商品ID = productID;
                        newRow.セット_BカートセットID = setID;
                        newRow.zero_stock_day = DateTime.Now;
                        newRow.Setdisabled_dayNull();
                        dtZeroStock.Addbc商品ゼロ在庫Row(newRow);
                        taZeroStock.Update(dtZeroStock);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                return false;
            }

            return true;
        }

        private bool setBackInStock(long productID, long setID)
        {
            try
            {
                using (AppData.dsTnbToBCartTableAdapters.bc商品ゼロ在庫TableAdapter taZeroStock = new AppData.dsTnbToBCartTableAdapters.bc商品ゼロ在庫TableAdapter())
                using (dsTnbToBCart.bc商品ゼロ在庫DataTable dtZeroStock = new dsTnbToBCart.bc商品ゼロ在庫DataTable())
                {
                    // 在庫がゼロから復活した場合(自動非表示にしたもののみ)
                    taZeroStock.FillByID(dtZeroStock, productID, setID);
                    if (dtZeroStock.Count > 0)
                    {
                        // 更新
                        dtZeroStock[0].Setzero_stock_dayNull();   // 非表示解除対象となる
                        taZeroStock.Update(dtZeroStock);
                    }
                    else
                    {
                        // ゼロ在庫自動非表示にしてない商品は無視
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                return false;
            }

            return true;
        }
    }
}
