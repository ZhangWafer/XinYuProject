using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Gma.QrCodeNet.Encoding.Common;
using System.Drawing;

using ZXing;
using ByteMatrix = ZXing.QrCode.Internal.ByteMatrix;

namespace QrCodeClass
{
    
    public class Zxing
    {
        //二维码生成
        public static Bitmap GenByZxingNet(string InputString, int codeSizeInPixels)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET,"UTF-8");
            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION,ZXing.QrCode.Internal.ErrorCorrectionLevel.H);
           
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 1;
            ZXing.Common.BitMatrix bm = writer.Encode(InputString);
            Bitmap img = writer.Write(bm);

            return img;
        }
        //保存到本地
        public static void BitmapSave(Bitmap bitmap,string path)
        {
            Bitmap bm = bitmap;
            bm.Save(path, ImageFormat.Jpeg);
        }

        //从路径得到图片
        public static Bitmap GetiImage(string imagePath)
        {
            Image img = Image.FromFile(imagePath);
            Bitmap map = new Bitmap(img);
            return map;

        }

        //二维码解码
        public static string DecodeQrCode(Bitmap barcodeBitmap)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            var result = reader.Decode(barcodeBitmap);
            return (result == null) ? null : result.Text;
        }
    }


    
}
