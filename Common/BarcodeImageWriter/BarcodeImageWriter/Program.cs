using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace BarcodeImageWriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
                return;

            string code = args[0];
            string outPath = args[1];
            int imgwidth = int.Parse(args[2]);
            int imgHeight = int.Parse(args[3]);

            // JAN 13桁(EAN) UPS 12桁は頭に０を付加して１３桁のＥＡＮコード１３桁としています。
            // code = code.PadLeft(13, "0")

            BarcodeWriter bw = new BarcodeWriter();
            bw.Format = BarcodeFormat.EAN_13;
            bw.Options = new EncodingOptions();
            bw.Options.Width = imgwidth;
            bw.Options.Height = imgHeight;
            bw.Options.Margin = 0;
            bw.Options.PureBarcode = false;

            Bitmap bm = bw.Write(code);
            bm.Save(outPath);
            bm.Dispose();
              
        }
    }
}
