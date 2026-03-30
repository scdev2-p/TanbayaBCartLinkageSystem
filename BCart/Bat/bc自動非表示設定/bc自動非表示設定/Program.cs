using System.Configuration;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using bc自動非表示設定;
using bc自動非表示設定.AppData;
using BCartApi;

class Program
{
    static void Main(string[] args)
    {
        Log.Write("*** バッチ処理開始 ***");

        // メンテナンス等の対応
        if (!sqlTnbToBCart.CheckConnect())
        {
            Log.ErrWrite("*** DB接続不可のため バッチ終了 ***");
            return;
        }

        // 非表示にする
        // ゼロ在庫が2週間たったもの
        Log.Write("ゼロ在庫自動非表示設定 Start");
        using (bc自動非表示設定.Jobs.cZeroTeamOver bcZero = new bc自動非表示設定.Jobs.cZeroTeamOver())
        {
            if (!bcZero.Do())
            {
                Log.ErrWrite("*** 商品在庫の登録でエラー終了");
                return;
            }
        }
        Log.Write("ゼロ在庫自動非表示設定 End");



        // 表示に戻す
        // 在庫が復活したもの
        Log.Write("在庫復活自動表示設定 Start");
        using (bc自動非表示設定.Jobs.cBackInStock bcZero = new bc自動非表示設定.Jobs.cBackInStock())
        {
            if (!bcZero.Do())
            {
                Log.ErrWrite("*** 商品在庫の登録でエラー終了");
                return;
            }
        }
        Log.Write("在庫復活自動表示設定 End");







        Log.Write("*** バッチ処理終了 ***");
    }


}

