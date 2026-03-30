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
    internal class bcDeleteBarcodeProducts : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        public bcDeleteBarcodeProducts()
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


        public bool Do(List<dsTnbToBCart.S_バーコード重複商品抽出Row> lstProductSets)
        {

            if (!Settings.Default.BcApiRegist)
            {
                // Debug用  Api連携OFF
                return true;
            }

            //int cnt = 0;        // 更新データのカウンタ
            //int apiCnt = 0;     // api実行数のカウンタ（上限まで実行）
            string tnb商品管理番号 = "";
            long bcProductsId = 0;
            long bcSetID = 0;

            try
            {
                // 新規商品差分の抽出
                //Log.Write(string.Format("削除（バーコード解除）商品対象件数[{0}]", lstProductSets.Count));

                using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
                using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
                using(SqlTnbToBCart sql = new SqlTnbToBCart())
                {
                    foreach (dsTnbToBCart.S_バーコード重複商品抽出Row row in lstProductSets)
                    {
                        // debug情報
                        tnb商品管理番号 = row.tnb商品管理番号;
                        bcProductsId = row.基本_Bカート商品ID;
                        bcSetID = row.セット_BカートセットID;

                        // =====================================================
                        // BCartのセット商品のバーコード（カスタム項目）を消す
                        // =====================================================
                        cProductSetCustomByID psRequest = new cProductSetCustomByID();

                        // カスタム項目1(内部IDは7)にバーコードをセット
                        cProductSetCustom cu = new cProductSetCustom();
                        cu.field_id = ProductSetCustom1_ID;  //  セット情報カスタム項目１のID
                        cu.value = "";
                        psRequest.customs.Add(cu);

                        cProductSetNewResponse productSetResult = this.api.PatchCommandId<cProductSetCustomByID, cProductSetNewResponse>(commandUrlProductSets, row.セット_BカートセットID.ToString(), psRequest);
                        if (productSetResult == null || productSetResult.product_sets == null)
                        {
                            //Log.ErrWrite("Api登録エラー");
                            return false;
                        }

                        // =====================================================
                        // BCart商品を非表示にする
                        // =====================================================
                        cSetProductsFlagRequest prRequest = new cSetProductsFlagRequest();
                        prRequest.flag = "非表示";

                        cProduct productResult = this.api.PatchCommandId<cSetProductsFlagRequest, cProduct>(commandUrlProducts, row.基本_Bカート商品ID.ToString(), prRequest);
                        if (productResult == null || productResult.product == null)
                        {
                            //Log.ErrWrite("Api登録エラー");
                            return false;
                        }

                        // =====================================================
                        // 取込済商品の削除フラグをセット、バーコードをリセット）
                        // =====================================================
                        if (sql.UpdateBarcodeByProducts(row.基本_Bカート商品ID, row.セット_BカートセットID, true, "") <= 0)
                        {
                            //Log.ErrWrite("DB更新エラー：" + row.ToString());
                            return false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("エラー tnb[{0}] bcProduct[{1}] bcSet[{2}]", tnb商品管理番号, bcProductsId, bcSetID), ex);
                return false;
            }
            return true;
        }
    }
}
