using System.Configuration;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using BCartApi;
using BCart顧客ランク差分登録;
using BCart顧客ランク差分登録.AppData;
using BCart顧客ランク差分登録.Jobs;


class Program
{
    static void Main(string[] args)
    {
        Log.Write("*** バッチ処理開始 ***");

        // 月初 １日のAM6時に動かす
        // Azureのメンテ収量が6時だから


        // メンテナンス等の対応
        if (!sqlTnbToBCart.CheckConnect())
        {
            Log.ErrWrite("*** DB接続不可のため バッチ終了 ***");
            return;
        }

        // 基幹システムとBCartの価格差分をBCartに登録する
        Log.Write("顧客ランクの差分登録 Start");
        using (bcRankUpdate bcsu = new bcRankUpdate())
        {
            if (!bcsu.Do())
            {
                Log.ErrWrite("*** 顧客ランクの差分登録でエラー終了");
                return;
            }
        }
        Log.Write("顧客ランクの差分登録 End");

        Log.Write("*** バッチ処理終了 ***");
    }
}


