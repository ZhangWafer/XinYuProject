using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing;
using ByteMatrix = ZXing.QrCode.Internal.ByteMatrix;

namespace QrCodeClass
{
    
    public class Zxing
    {
        public static Bitmap GenByZxingNet(string InputString,int WeightHeight)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET,"UTF-8");
            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION,ZXing.QrCode.Internal.ErrorCorrectionLevel.H);      
            writer.Options.Height = writer.Options.Width = WeightHeight;
            writer.Options.Margin = 1;
            ZXing.Common.BitMatrix bm = writer.Encode(InputString);
            Bitmap img = writer.Write(bm);

            return img;
        }

    }


    
}
