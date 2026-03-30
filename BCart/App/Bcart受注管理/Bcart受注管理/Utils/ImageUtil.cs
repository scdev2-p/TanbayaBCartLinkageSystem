using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bcart受注管理.Utils
{
    internal class ImageUtil
    {

        /// <summary>
        /// 指定した画像のコントラストを変更して新しい画像を作成する
        /// </summary>
        /// <param name="img">基になる画像</param>
        /// <param name="contrast">コントラストの値（-100～100）</param>
        /// <returns>作成された画像</returns>
        public static Image AdjustContrast(Image img, float contrast)
        {
            //コントラストを変更した画像の描画先となるImageオブジェクトを作成
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            //newImgのGraphicsオブジェクトを取得
            Graphics g = Graphics.FromImage(newImg);

            //ColorMatrixオブジェクトの作成
            float scale = (100f + contrast) / 100f;
            scale *= scale;
            float append = 0.5f * (1f - scale);
            System.Drawing.Imaging.ColorMatrix cm =
                new System.Drawing.Imaging.ColorMatrix(
                    new float[][] {
        new float[] {scale, 0, 0, 0, 0},
        new float[] {0, scale, 0, 0, 0},
        new float[] {0, 0, scale, 0, 0},
        new float[] {0, 0, 0, 1, 0},
        new float[] {append, append, append, 0, 1}
            });

            //ImageAttributesオブジェクトの作成
            System.Drawing.Imaging.ImageAttributes ia =
                new System.Drawing.Imaging.ImageAttributes();
            //ColorMatrixを設定する
            ia.SetColorMatrix(cm);

            //ImageAttributesを使用して描画
            g.DrawImage(img,
                new Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

            //リソースを解放する
            g.Dispose();

            return newImg;
        }


        /// <summary>
        /// 指定した画像の彩度を変更した画像を作成する
        /// </summary>
        /// <param name="img">基になる画像</param>
        /// <param name="saturation">彩度</param>
        /// <returns>作成された画像</returns>
        public static Image ChangeSaturation(Image img, float saturation)
        {
            //彩度を変更した画像の描画先となるImageオブジェクトを作成
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            //newImgのGraphicsオブジェクトを取得
            Graphics g = Graphics.FromImage(newImg);

            //ColorMatrixオブジェクトの作成
            System.Drawing.Imaging.ColorMatrix cm =
                new System.Drawing.Imaging.ColorMatrix();
            const float rwgt = 0.3086f;
            const float gwgt = 0.6094f;
            const float bwgt = 0.0820f;
            cm.Matrix01 = cm.Matrix02 = (1f - saturation) * rwgt;
            cm.Matrix00 = cm.Matrix01 + saturation;
            cm.Matrix10 = cm.Matrix12 = (1f - saturation) * gwgt;
            cm.Matrix11 = cm.Matrix10 + saturation;
            cm.Matrix20 = cm.Matrix21 = (1f - saturation) * bwgt;
            cm.Matrix22 = cm.Matrix20 + saturation;
            cm.Matrix33 = cm.Matrix44 = 1;

            //ImageAttributesオブジェクトの作成
            System.Drawing.Imaging.ImageAttributes ia =
                new System.Drawing.Imaging.ImageAttributes();
            //ColorMatrixを設定する
            ia.SetColorMatrix(cm);

            //ImageAttributesを使用して描画
            g.DrawImage(img,
                new Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

            //リソースを解放する
            g.Dispose();

            return newImg;
        }
    }
}
