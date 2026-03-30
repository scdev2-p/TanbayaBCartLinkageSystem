using BCartApi;
using BCart商品差分登録;
using BCart商品差分登録.AppData;
using BCart商品差分登録.Jobs;

class Program
{
    static void Main(string[] args)
    {
        Log.Write("*** バッチ処理開始 ***");

        // メンテナンス等の対応
        if(!sqlTnbToBCart.CheckConnect())
        {
            Log.ErrWrite("*** DB接続不可のため バッチ終了 ***");
            return;
        }

        // 処理中にメンテナンス等で落ちても、次回起動でBCart在庫も登録済商品の在庫も同期されるが
        // DB書込みエラーが発生するとその後、差分の誤判定により不整合が発生する可能性がある。
        // 


        // 基幹システムとBCartの在庫差分をBCartに登録する
        Log.Write("商品在庫の差分登録 Start");
        using (bcStockUpdate bcsu = new bcStockUpdate())
        {
            if(!bcsu.Do())
            {
                Log.ErrWrite("*** 商品在庫の登録でエラー終了");
                return;
            }
        }
        Log.Write("商品在庫の差分登録 End");

        // 基幹システムとBCartの価格差分をBCartに登録する
        Log.Write("商品価格の差分登録 Start");
        using (bcPriceUpdate bcsu = new bcPriceUpdate())
        {
            if(!bcsu.Do())
            {
                Log.ErrWrite("*** 商品価格の登録でエラー終了");
                return;
            }
        }
        Log.Write("商品価格の差分登録 End");

        Log.Write("*** バッチ処理終了 ***");
    }
}


