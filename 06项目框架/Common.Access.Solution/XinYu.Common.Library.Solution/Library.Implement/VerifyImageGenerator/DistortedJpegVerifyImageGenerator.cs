using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.VerifyImageGenerator
{
    /// <summary>
    /// 扭曲的Jpeg验证码图片生成器.
    /// </summary>
    public class DistortedJpegVerifyImageGenerator : AbstractVerifyImageGenerator
    {
        const int ConstDefaultCodeLength = 6;
        const int ConstDefaultImageWidth = 120;
        const int ConstDefaultImageHeight = 60;
        const string ConstDefaultImageBgColorName = "White";
        const int ConstDefaultTextColor = 0;

        private bool isDistoryed = true;

        private static Font[] fonts = { new Font(new FontFamily("Times New Roman"), 20 + Next(4), FontStyle.Bold),
                                        new Font(new FontFamily("Georgia"), 20 + Next(4), FontStyle.Bold),
                                        new Font(new FontFamily("Arial"), 20 + Next(4), FontStyle.Bold),
                                        new Font(new FontFamily("Comic Sans MS"), 20 + Next(4), FontStyle.Bold)};

        #region Constructors.

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator()
        { }


        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(bool isDistoryed)
            : this(isDistoryed, ConstDefaultCodeLength, ConstDefaultImageWidth, ConstDefaultImageHeight, ConstDefaultImageBgColorName, ConstDefaultTextColor)
        { }


        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(int defaultCodeLength)
            : this(true, defaultCodeLength, ConstDefaultImageWidth, ConstDefaultImageHeight, ConstDefaultImageBgColorName, ConstDefaultTextColor)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(int defaultImageWidth, int defaultImageHeight)
            : this(true, ConstDefaultCodeLength, defaultImageWidth, defaultImageHeight, ConstDefaultImageBgColorName, ConstDefaultTextColor)
        { }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(string defaultImageBgColorName)
            : this(true, ConstDefaultCodeLength, ConstDefaultImageWidth, ConstDefaultImageHeight, defaultImageBgColorName, ConstDefaultTextColor)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(int defaultImageWidth, int defaultImageHeight, string defaultImageBgColorName)
            : this(true, ConstDefaultCodeLength, defaultImageWidth, defaultImageHeight, defaultImageBgColorName, ConstDefaultTextColor)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(int defaultCodeLength, int defaultImageWidth, int defaultImageHeight, string defaultImageBgColorName)
            : this(true, defaultCodeLength, defaultImageWidth, defaultImageHeight, defaultImageBgColorName, ConstDefaultTextColor)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistortedJpegVerifyImageGenerator(bool isDistoryed, int defaultCodeLength, int defaultImageWidth, int defaultImageHeight, string defaultImageBgColorName, int defaultTextColor)
        {
            Color bgColor;
            try
            {
                bgColor = Color.FromName(defaultImageBgColorName);
            }
            catch
            {
                bgColor = base.defaultImageBgColor;
            }

            this.isDistoryed = isDistoryed;
            base.initialize(defaultCodeLength, defaultImageWidth, defaultImageHeight, bgColor, defaultTextColor);
        }
        #endregion


        public override VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // 建立画布
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(bgcolor);

            //int fixedNumber = textcolor == 2 ? 60 : 0;
            int fixedNumber = (textcolor > 60) ? 60 : (textcolor < 0) ? 0 : textcolor;

            // 绘制四条随机直线
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(Next(100), Next(100), Next(100)));
            for (int x = 0; x < 3; x++)
            {
                Pen linePen = new Pen(Color.FromArgb(Next(150) + fixedNumber, Next(150) + fixedNumber, Next(150) + fixedNumber), 1);
                g.DrawLine(linePen, new PointF(0.0F + Next(20), 0.0F + Next(height)), new PointF(0.0F + Next(width), 0.0F + Next(height)));
            }

            // 采用二D手法绘制要验证码.
            Matrix m = new Matrix();
            for (int x = 0; x < code.Length; x++)
            {
                m.Reset();
                m.RotateAt(Next(30) - 15, new PointF(Convert.ToInt64(width * (0.10 * x)), Convert.ToInt64(height * 0.5)));
                g.Transform = m;
                drawBrush.Color = Color.FromArgb(Next(150) + fixedNumber + 20, Next(150) + fixedNumber + 20, Next(150) + fixedNumber + 20);
                PointF drawPoint = new PointF(0.0F + Next(4) + x * 20, 3.0F + Next(3));
                g.DrawString(Next(1) == 1 ? code[x].ToString() : code[x].ToString().ToUpper(), fonts[Next(fonts.Length - 1)], drawBrush, drawPoint);
                g.ResetTransform();
            }

            // 将图中的每一个点进行扭曲化处理, 以实现弯曲效果.
            if (this.isDistoryed)
                this.distortImage(bitmap);

            drawBrush.Dispose();
            g.Dispose();

            // 返回对象
            VerifyImageInfo verifyimage = new VerifyImageInfo();
            verifyimage.VerifyCode = code;
            verifyimage.ImageFormat = ImageFormat.Jpeg;
            verifyimage.ContentType = "image/pjpeg";
            verifyimage.Image = bitmap;
            return verifyimage;
        }

        /// <summary>
        /// 将图中的每一个点进行扭曲化处理, 以实现弯曲效果.
        /// </summary>
        /// <param name="bitmap">要处理的图片对象</param>
        private void distortImage(Bitmap bitmap)
        {
            double distort = Next(5, 10) * (Next(10) == 1 ? 1 : -1);
            using (Bitmap copy = (Bitmap)bitmap.Clone())
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        int newX = (int)(x + (distort * Math.Sin(Math.PI * y / 84.5)));
                        int newY = (int)(y + (distort * Math.Cos(Math.PI * x / 54.5)));
                        if (newX < 0 || newX >= bitmap.Width)
                            newX = 0;
                        if (newY < 0 || newY >= bitmap.Height)
                            newY = 0;
                        bitmap.SetPixel(x, y, copy.GetPixel(newX, newY));
                    }
                }
            } // end using.
        }

    }
}
