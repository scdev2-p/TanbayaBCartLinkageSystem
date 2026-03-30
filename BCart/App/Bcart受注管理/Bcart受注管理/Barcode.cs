using Bcart受注管理.AppData;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Bcart受注管理
{
    internal class Barcode
    {

        public static string ToJAN13(string barcode)
        {
            Program.ScLogger.Info($"start {nameof(barcode)}={barcode}");

            if (barcode.Length > 13)
            {
                Program.ScLogger.Info($"end {nameof(barcode)}={barcode}");
                return barcode;     // 13桁はそのまま返す
            }   

            string ret = "";

            // ゼロを埋めて１２桁にする
            if (barcode.Length < 12)
                ret = barcode.PadLeft(13, '0');
            else
                ret = barcode.Substring(0, 12);

            // チェックディジットを付ける
            int x = 0;
            for (int i = 0; i < ret.Length; i++)
            {
                x += int.Parse(ret[ret.Length - 1 - i].ToString()) * (i % 2 == 0 ? 3 : 1);
            }
            x = (10 - x % 10) % 10;
            ret = ret + x.ToString();

            Program.ScLogger.Info($"end {nameof(ret)}={ret}");
            return ret;
        }

        public static Bitmap MakeBarcodeImage(string bcode, float width, float height)
        {
            Program.ScLogger.Info($"start {nameof(bcode)}={bcode}, {nameof(width)}={width}, {nameof(height)}={height}");

            int barcodeImageWidth = (int)(width * PublicData.DpiX / 100);
            int barcodeImageHeight = (int)(height * PublicData.DpiY / 100);

            // Imageファイルの作成（8.0では使えなかったので）
            string outFile = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".bmp");
            Process p = Process.Start("BarcodeImageWriter.exe", bcode + " " + outFile + " " + barcodeImageWidth.ToString() + " " + barcodeImageHeight.ToString());
            p.WaitForExit();

            Image img = Image.FromFile(outFile);
            try
            {
                // 一時ファイルの削除
                File.Delete(outFile);
            }
            catch { }
            return new Bitmap(img);
        }
        //    // JAN 13桁(EAN) UPS 12桁は頭に０を付加して１３桁のＥＡＮコード１３桁としています。
        //    // code = code.PadLeft(13, "0")

        //    BarcodeWriter bw = new BarcodeWriter();
        //    bw.Format = BarcodeFormat.EAN_13;
        //    bw.Options = new EncodingOptions();
        //    bw.Options.Width = 160 * dpiX / 100;
        //    bw.Options.Height = 52 * dpiY / 100;
        //    bw.Options.Margin = 0;
        //    bw.Options.PureBarcode = false;

        //    Bitmap bm = bw.Write(code);
        //    try
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            bm.Save(ms, ImageFormat.Bmp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("バーコードにできません。" + code + ex.Message);
        //        return null;
        //    }
        //    return bm;
        //}


        /// <summary>
        /// レジ用バーコード作成
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string CreateRegBarcode(string item)
        {
            Program.ScLogger.Info($"start {nameof(item)}={item}");

            int answer1;
            int answer2;
            int answer3;

            answer1 = Convert.ToInt32(item.Substring(0, 1)) + Convert.ToInt32(item.Substring(2, 1)) +
                Convert.ToInt32(item.Substring(4, 1)) + Convert.ToInt32(item.Substring(6, 1)) +
                Convert.ToInt32(item.Substring(8, 1)) + Convert.ToInt32(item.Substring(10, 1)) +
                ((Convert.ToInt32(item.Substring(1, 1)) + Convert.ToInt32(item.Substring(3, 1)) +
                Convert.ToInt32(item.Substring(5, 1)) + Convert.ToInt32(item.Substring(7, 1)) +
                Convert.ToInt32(item.Substring(9, 1)) + Convert.ToInt32(item.Substring(11, 1))) * 3);

            answer2 = Convert.ToInt32(Math.Floor((decimal)answer1 / 10) * 10);

            if (answer1 != answer2)
            {
                answer2 = Convert.ToInt32((Math.Floor((decimal)answer1 / 10) + 1) * 10);
            }

            answer3 = answer2 - answer1;

            var ret = item + Convert.ToString(answer3);
            Program.ScLogger.Info($"end {nameof(ret)}={ret}");
            return ret;
        }

        /// <summary>
        /// 顧客コードからバーコード生成用のコードを作成する
        /// </summary>
        /// <param name="kokyakuCD">顧客コード</param>
        /// <returns>バーコード用文字列</returns>
        public static string GetCreateBarcodeFromKokyakuCD(string kokyakuCD)
        {
            Program.ScLogger.Info($"start {nameof(kokyakuCD)}={kokyakuCD}");

            var ret = string.Empty;
            if (kokyakuCD.Length == 6)
            {
                ret = Barcode.CreateRegBarcode(Strings.Asc(kokyakuCD.Substring(0, 1)).ToString().PadLeft(4, '0') +
                    kokyakuCD.Substring(1, 5).PadRight(8, '0'));
            }
            else if (kokyakuCD.Length == 7)
            {
                ret = Barcode.CreateRegBarcode(Strings.Asc(kokyakuCD.Substring(0, 1)).ToString().PadLeft(4, '0') +
                    kokyakuCD.Substring(1, 5) +
                    Strings.Asc(kokyakuCD.Substring(6, 1)).ToString().PadLeft(3, '0'));
            }
            else if (kokyakuCD.Length == 9)
            {
                ret = Barcode.CreateRegBarcode(Strings.Asc(kokyakuCD.Substring(0, 1)).ToString().PadLeft(4, '0') +
                    kokyakuCD.Substring(1, 8));
            }
            else
            {
                ret = kokyakuCD;
            }

            Program.ScLogger.Info($"end {nameof(ret)}={ret}");
            return ret;
        }
    }
}
