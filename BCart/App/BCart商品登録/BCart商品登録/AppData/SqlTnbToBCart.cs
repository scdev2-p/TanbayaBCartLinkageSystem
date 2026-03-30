using BCartApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCart商品登録.AppData
{
    internal class SqlTnbToBCart:IDisposable
    {
        private SqlConnection _con;

        public void Dispose()
        {
            if(this._con.State == System.Data.ConnectionState.Open)
            { this._con.Close(); }
            this._con.Dispose();
        }

        public SqlTnbToBCart()
        {
            _con = new SqlConnection(Settings.Default.TnbToBCart);
        }

        /// <summary>
        /// 
        /// PKが無いためUPDATEコマンドは自作する
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public int updateBC登録済商品(dsTnbToBCart.bc登録済商品Row row)
        {
            try
            {

                using (SqlCommand cmd = this._con.CreateCommand())
                {
                    if(_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"UPDATE [dbo].[bc登録済商品]
SET [tnb商品管理番号] = @tnb商品管理番号
    ,[削除フラグ] = @削除フラグ

    ,[基本_商品名] = @基本_商品名
    ,[基本_商品特徴] = @基本_商品特徴
    ,[基本_画像] = @基本_画像
    ,[基本_状態] = @基本_状態
    ,[基本_商品非表示グループ] = @基本_商品非表示グループ
    ,[基本_カスタム項目5] = @基本_カスタム項目5
    ,[サブ画像1] = @サブ画像1
    ,[サブ画像2] = @サブ画像2
    ,[サブ画像3] = @サブ画像3
    ,[サブ画像4] = @サブ画像4
    ,[サブ画像5] = @サブ画像5
    ,[サブ画像6] = @サブ画像6

    ,[セット_カスタム項目1] = @セット_カスタム項目1
    ,[セット_カスタム項目2] = @セット_カスタム項目2
    ,[セット_上代] = @セット_上代
    ,[セット_単価] = @セット_単価
    ,[セット_在庫] = @セット_在庫
    ,[セット_在庫制限] = @セット_在庫制限 
    ,[セット_グループ価格1] = @セット_グループ価格1
    ,[セット_グループ価格2] = @セット_グループ価格2
    ,[セット_グループ価格3] = @セット_グループ価格3
    ,[セット_グループ価格4] = @セット_グループ価格4
    ,[セット_グループ価格5] = @セット_グループ価格5
    ,[セット_グループ価格6] = @セット_グループ価格6
    ,[セット_グループ価格7] = @セット_グループ価格7
    ,[セット_グループ価格8] = @セット_グループ価格8
    ,[セット_グループ価格9] = @セット_グループ価格9
    ,[セット_グループ価格10] = @セット_グループ価格10
    ,[EC移行フラグ] = @EC移行フラグ
    ,[セット_セット名] = @セット_セット名
 WHERE [基本_Bカート商品ID] = @基本_Bカート商品ID AND [セット_BカートセットID] = @セット_BカートセットID";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@tnb商品管理番号", row.tnb商品管理番号));
                    cmd.Parameters.Add(new SqlParameter("@削除フラグ", row.Is削除フラグNull()? DBNull.Value : row.削除フラグ));
                    cmd.Parameters.Add(new SqlParameter("@基本_商品名", row.Is基本_商品名Null()? DBNull.Value : row.基本_商品名));
                    cmd.Parameters.Add(new SqlParameter("@基本_商品特徴", row.Is基本_商品特徴Null()? DBNull.Value : row.基本_商品特徴));
                    cmd.Parameters.Add(new SqlParameter("@基本_画像", row.Is基本_画像Null()? DBNull.Value : row.基本_画像));
                    cmd.Parameters.Add(new SqlParameter("@基本_状態", row.Is基本_状態Null()? DBNull.Value : row.基本_状態));
                    cmd.Parameters.Add(new SqlParameter("@基本_商品非表示グループ", row.Is基本_商品非表示グループNull()? DBNull.Value : row.基本_商品非表示グループ));
                    cmd.Parameters.Add(new SqlParameter("@基本_カスタム項目5", row.Is基本_カスタム項目5Null()? DBNull.Value : row.基本_カスタム項目5));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像1", row.Isサブ画像1Null()? DBNull.Value : row.サブ画像1));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像2", row.Isサブ画像2Null()? DBNull.Value : row.サブ画像2));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像3", row.Isサブ画像3Null()? DBNull.Value : row.サブ画像3));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像4", row.Isサブ画像4Null()? DBNull.Value : row.サブ画像4));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像5", row.Isサブ画像5Null()? DBNull.Value : row.サブ画像5));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像6", row.Isサブ画像6Null()? DBNull.Value : row.サブ画像6));
                    cmd.Parameters.Add(new SqlParameter("@セット_カスタム項目1", row.Isセット_カスタム項目1Null()? DBNull.Value : row.セット_カスタム項目1));
                    cmd.Parameters.Add(new SqlParameter("@セット_カスタム項目2", row.Isセット_カスタム項目2Null()? DBNull.Value : row.セット_カスタム項目2));
                    cmd.Parameters.Add(new SqlParameter("@セット_上代", row.Isセット_上代Null()? DBNull.Value : row.セット_上代));
                    cmd.Parameters.Add(new SqlParameter("@セット_単価", row.Isセット_単価Null()? DBNull.Value : row.セット_単価));
                    cmd.Parameters.Add(new SqlParameter("@セット_在庫", row.Isセット_在庫Null()? DBNull.Value : row.セット_在庫));
                    cmd.Parameters.Add(new SqlParameter("@セット_在庫制限 ", row.セット_在庫制限));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格1", row.Isセット_グループ価格1Null()? DBNull.Value : row.セット_グループ価格1));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格2", row.Isセット_グループ価格2Null() ? DBNull.Value : row.セット_グループ価格2));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格3", row.Isセット_グループ価格3Null() ? DBNull.Value : row.セット_グループ価格3));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格4", row.Isセット_グループ価格4Null() ? DBNull.Value : row.セット_グループ価格4));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格5", row.Isセット_グループ価格5Null() ? DBNull.Value : row.セット_グループ価格5));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格6", row.Isセット_グループ価格6Null() ? DBNull.Value : row.セット_グループ価格6));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格7", row.Isセット_グループ価格7Null() ? DBNull.Value : row.セット_グループ価格7));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格8", row.Isセット_グループ価格8Null() ? DBNull.Value : row.セット_グループ価格8));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格9", row.Isセット_グループ価格9Null() ? DBNull.Value : row.セット_グループ価格9));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格10", row.Isセット_グループ価格10Null() ? DBNull.Value : row.セット_グループ価格10));
                    cmd.Parameters.Add(new SqlParameter("@EC移行フラグ", row.EC移行フラグ));
                    cmd.Parameters.Add(new SqlParameter("@基本_Bカート商品ID", row.基本_Bカート商品ID));
                    cmd.Parameters.Add(new SqlParameter("@セット_BカートセットID", row.セット_BカートセットID));
                    cmd.Parameters.Add(new SqlParameter("@セット_セット名", row.Isセット_セット名Null()? DBNull.Value : row.セット_セット名));

                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }
        }

        /// <summary>
        /// PKが無いためUPDATEコマンドは自作する
        /// 商品基本情報のみ更
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public int updateBC登録済商品_基本情報(dsTnbToBCart.bc登録済商品Row row)
        {
            try
            {

                using (SqlCommand cmd = this._con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"UPDATE [dbo].[bc登録済商品]
SET [基本_商品名] = @基本_商品名
    ,[基本_商品特徴] = @基本_商品特徴
    ,[基本_画像] = @基本_画像
    ,[基本_状態] = @基本_状態
    ,[基本_商品非表示グループ] = @基本_商品非表示グループ
    ,[基本_カスタム項目5] = @基本_カスタム項目5
    ,[サブ画像1] = @サブ画像1
    ,[サブ画像2] = @サブ画像2
    ,[サブ画像3] = @サブ画像3
    ,[サブ画像4] = @サブ画像4
    ,[サブ画像5] = @サブ画像5
    ,[サブ画像6] = @サブ画像6
 WHERE [基本_Bカート商品ID] = @基本_Bカート商品ID";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@基本_商品名", row.Is基本_商品名Null()? DBNull.Value : row.基本_商品名));
                    cmd.Parameters.Add(new SqlParameter("@基本_商品特徴", row.Is基本_商品特徴Null()? DBNull.Value : row.基本_商品特徴));
                    cmd.Parameters.Add(new SqlParameter("@基本_画像", row.Is基本_画像Null()? DBNull.Value : row.基本_画像));
                    cmd.Parameters.Add(new SqlParameter("@基本_状態", row.Is基本_状態Null()? DBNull.Value : row.基本_状態));
                    cmd.Parameters.Add(new SqlParameter("@基本_商品非表示グループ", row.Is基本_商品非表示グループNull()? DBNull.Value : row.基本_商品非表示グループ));
                    cmd.Parameters.Add(new SqlParameter("@基本_カスタム項目5", row.Is基本_カスタム項目5Null()? DBNull.Value : row.基本_カスタム項目5));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像1", row.Isサブ画像1Null() ? DBNull.Value : row.サブ画像1));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像2", row.Isサブ画像2Null() ? DBNull.Value : row.サブ画像2));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像3", row.Isサブ画像3Null() ? DBNull.Value : row.サブ画像3));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像4", row.Isサブ画像4Null() ? DBNull.Value : row.サブ画像4));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像5", row.Isサブ画像5Null() ? DBNull.Value : row.サブ画像5));
                    cmd.Parameters.Add(new SqlParameter("@サブ画像6", row.Isサブ画像6Null() ? DBNull.Value : row.サブ画像6));
                    cmd.Parameters.Add(new SqlParameter("@基本_Bカート商品ID", row.基本_Bカート商品ID));

                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// PKが無いためUPDATEコマンドは自作する
        /// セット情報のみ更新
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public int updateBC登録済商品_セット情報(dsTnbToBCart.bc登録済商品Row row)
        {
            try
            {

                using (SqlCommand cmd = this._con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"UPDATE [dbo].[bc登録済商品]
SET [tnb商品管理番号] = @tnb商品管理番号
    ,[セット_カスタム項目1] = @セット_カスタム項目1
    ,[セット_カスタム項目2] = @セット_カスタム項目2
    ,[セット_上代] = @セット_上代
    ,[セット_単価] = @セット_単価
    ,[セット_在庫] = @セット_在庫
    ,[セット_在庫制限] = @セット_在庫制限 
    ,[セット_グループ価格1] = @セット_グループ価格1
    ,[セット_グループ価格2] = @セット_グループ価格2
    ,[セット_グループ価格3] = @セット_グループ価格3
    ,[セット_グループ価格4] = @セット_グループ価格4
    ,[セット_グループ価格5] = @セット_グループ価格5
    ,[セット_グループ価格6] = @セット_グループ価格6
    ,[セット_グループ価格7] = @セット_グループ価格7
    ,[セット_グループ価格8] = @セット_グループ価格8
    ,[セット_グループ価格9] = @セット_グループ価格9
    ,[セット_グループ価格10] = @セット_グループ価格10
    ,[セット_セット名] = @セット_セット名
 WHERE [基本_Bカート商品ID] = @基本_Bカート商品ID AND [セット_BカートセットID] = @セット_BカートセットID";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@tnb商品管理番号", row.tnb商品管理番号));
                    cmd.Parameters.Add(new SqlParameter("@セット_カスタム項目1", row.Isセット_カスタム項目1Null() ? DBNull.Value : row.セット_カスタム項目1));
                    cmd.Parameters.Add(new SqlParameter("@セット_カスタム項目2", row.Isセット_カスタム項目2Null() ? DBNull.Value : row.セット_カスタム項目2));
                    cmd.Parameters.Add(new SqlParameter("@セット_上代", row.Isセット_上代Null() ? DBNull.Value : row.セット_上代));
                    cmd.Parameters.Add(new SqlParameter("@セット_単価", row.Isセット_単価Null() ? DBNull.Value : row.セット_単価));
                    cmd.Parameters.Add(new SqlParameter("@セット_在庫", row.Isセット_在庫Null() ? DBNull.Value : row.セット_在庫));
                    cmd.Parameters.Add(new SqlParameter("@セット_在庫制限 ", row.セット_在庫制限));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格1", row.Isセット_グループ価格1Null() ? DBNull.Value : row.セット_グループ価格1));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格2", row.Isセット_グループ価格2Null() ? DBNull.Value : row.セット_グループ価格2));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格3", row.Isセット_グループ価格3Null() ? DBNull.Value : row.セット_グループ価格3));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格4", row.Isセット_グループ価格4Null() ? DBNull.Value : row.セット_グループ価格4));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格5", row.Isセット_グループ価格5Null() ? DBNull.Value : row.セット_グループ価格5));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格6", row.Isセット_グループ価格6Null() ? DBNull.Value : row.セット_グループ価格6));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格7", row.Isセット_グループ価格7Null() ? DBNull.Value : row.セット_グループ価格7));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格8", row.Isセット_グループ価格8Null() ? DBNull.Value : row.セット_グループ価格8));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格9", row.Isセット_グループ価格9Null() ? DBNull.Value : row.セット_グループ価格9));
                    cmd.Parameters.Add(new SqlParameter("@セット_グループ価格10", row.Isセット_グループ価格10Null() ? DBNull.Value : row.セット_グループ価格10));
                    cmd.Parameters.Add(new SqlParameter("@セット_セット名", row.Isセット_セット名Null() ? DBNull.Value : row.セット_セット名));
                    cmd.Parameters.Add(new SqlParameter("@基本_Bカート商品ID", row.基本_Bカート商品ID));
                    cmd.Parameters.Add(new SqlParameter("@セット_BカートセットID", row.セット_BカートセットID));

                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }
        }


        /// <summary>
        /// 商品のバーコードを変更する
        /// </summary>
        /// <param name="bcProductsID"></param>
        /// <param name="bcSetID"></param>
        /// <returns></returns>
        public int UpdateBarcodeByProducts(long bcProductsID, long bcSetID, bool delFlg, string barcode)
        {
            try
            { 
                using(SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"UPDATE [dbo].[bc登録済商品]
SET [削除フラグ] = @delFlg,
,[セット_カスタム項目1] = @barcpde
WHERE [基本_Bカート商品ID] = @基本_Bカート商品ID AND [セット_BカートセットID] = @セット_BカートセットID";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@delFlg", delFlg? 1 : DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@barcpde", !string.IsNullOrEmpty(barcode)? barcode : DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@基本_Bカート商品ID", bcProductsID));
                    cmd.Parameters.Add(new SqlParameter("@セット_BカートセットID", bcSetID));

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }
        }

        /// <summary>
        /// BC登録済商品に商品単位で削除フラグをセット（在庫・価格の連携から除外される）
        /// </summary>
        /// <param name="bcProductsID"></param>
        /// <returns></returns>
        public bool updateDeleteFlagByProducts(long bcProductsID)
        {
            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"UPDATE [dbo].[bc登録済商品]
SET [削除フラグ] = 1
WHERE [基本_Bカート商品ID] = @基本_Bカート商品ID ";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@基本_Bカート商品ID", bcProductsID));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// BC登録済商品にセット単位で削除フラグをセット（在庫・価格の連携から除外される）
        /// </summary>
        /// <param name="bcProductsID"></param>
        /// <param name="bcSetID"></param>
        /// <returns></returns>
        public bool updateDeleteFlagBySets(long bcSetID)
        {
            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"UPDATE [dbo].[bc登録済商品]
SET [削除フラグ] = 1
WHERE [セット_BカートセットID] = @セット_BカートセットID";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@セット_BカートセットID", bcSetID));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// セットIDから商品IDを取得
        /// </summary>
        /// <param name="bcSetID"></param>
        /// <returns></returns>
        public long GetProductsIDBySetID(long bcSetID)
        {
            long ret = 0;

            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"SELECT [基本_Bカート商品ID] FROM [dbo].[bc登録済商品] WHERE [セット_BカートセットID] = @setID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@setID", bcSetID));

                    object obj = cmd.ExecuteScalar();
                    if(obj != null)
                        ret = (long)obj;
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }

            return ret;
        }

        /// <summary>
        /// 登録済商品の最後の商品管理番号尾の取得
        /// </summary>
        /// <returns></returns>
        public string GetMaxTnbProductID()
        {
            string ret = "";

            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"SELECT MAX(tnb商品管理番号) FROM [dbo].[bc登録済商品]";
                    cmd.Parameters.Clear();

                    ret = (string)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }

            return ret;
        }

        /// <summary>
        /// バーコードから基幹の商品管理番号取得
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public string GetTnbProductIDByBarcode(string barcode)
        {
            string ret = "";
            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"SELECT 商品管理番号 FROM [tnb].[dbo].[M_商品] WHERE [バーコード] = @barcode  and [M_商品].削除フラグ <> 1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@barcode", barcode));

                    ret = (string)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }

            return ret;
        }

        //件数の取得

        public int GetProductsCount(long productId)
        {
            int ret = 0;

            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"SELECT COUNT(*) FROM [dbo].[bc登録済商品] WHERE [基本_Bカート商品ID] = @productId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@productId", productId));

                    ret = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }

            return ret;
        }

        public int GetProductSetCount(long SetId)
        {
            int ret = 0;

            try
            {
                using (SqlCommand cmd = _con.CreateCommand())
                {
                    if (_con.State != System.Data.ConnectionState.Open)
                        _con.Open();

                    cmd.CommandText = @"SELECT COUNT(*) FROM [dbo].[bc登録済商品] WHERE [セット_BカートセットID] = @SetId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SetId", SetId));

                    ret = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Log.ErrWrite("SQL実行エラー", ex);
                throw ex;
            }

            return ret;
        }

    }


}
