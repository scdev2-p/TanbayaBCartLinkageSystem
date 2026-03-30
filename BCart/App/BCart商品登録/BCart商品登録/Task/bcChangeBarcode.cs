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
    internal class bcChangeBarcode : IDisposable
    {

        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlProducts = "products";
        private const string commandUrlProductSets = "product_sets";

        private SqlConnection _con;

        private const int ProductCustom5_ID = 12;    // 基本カスタム項目５のID
        private const int ProductSetCustom1_ID = 7;  // セット情報カスタム項目１のID

        public bcChangeBarcode()
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


        public bool Do(long productID, long productSetID, string barcode)
        {

            if (!Settings.Default.BcApiRegist)
            {
                // Debug用  Api連携OFF
                return true;
            }

            try
            {
                // 新規商品差分の抽出
                //Log.Write(string.Format("バーコード変更商品セット[{0}] バーコード[{1}]", productSetID,barcode));

                using (AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.bc登録済商品TableAdapter())
                using (dsTnbToBCart.bc登録済商品DataTable dt = new dsTnbToBCart.bc登録済商品DataTable())
                using (SqlTnbToBCart sql = new SqlTnbToBCart())
                {
                    // =====================================================
                    // BCartのセット商品のバーコード（カスタム項目
                    // =====================================================
                    cProductSetCustomByID psRequest = new cProductSetCustomByID();

                    // カスタム項目1(内部IDは7)にバーコードをセット
                    cProductSetCustom cu = new cProductSetCustom();
                    cu.field_id = ProductSetCustom1_ID;  //  セット情報カスタム項目１のID
                    cu.value = barcode;
                    psRequest.customs.Add(cu);

                    cProductSetNewResponse productSetResult = this.api.PatchCommandId<cProductSetCustomByID, cProductSetNewResponse>(commandUrlProductSets, productSetID.ToString(), psRequest);
                    if (productSetResult == null || productSetResult.product_sets == null)
                    {
                        //Log.ErrWrite("Api登録エラー");
                        return false;
                    }

                    // =====================================================
                    // 取込済商品のバーコードをセット
                    // =====================================================
                    if (sql.UpdateBarcodeByProducts(productID, productSetID, false, barcode) <= 0)
                    {
                        //Log.ErrWrite("DB更新エラー：");
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite(string.Format("エラー bcProduct[{0}] bcSet[{1}]", productID, productSetID), ex);
                return false;
            }
            return true;
        }
    }
}