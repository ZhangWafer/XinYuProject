using System;
using System.Drawing;
using System.Security.Cryptography;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.VerifyImageGenerator
{
    /// <summary>
    /// Abstract Verify Image
    /// </summary>
    public abstract class AbstractVerifyImageGenerator : IVerifyImageGenerator
    {
        #region Static element.

        protected static byte[] randb = new byte[4];
        protected static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

        /// <summary>
        /// �����һ�������
        /// </summary>
        /// <param name="max">���ֵ</param>
        /// <returns></returns>
        protected static int Next(int max)
        {
            rand.GetBytes(randb);
            int value = BitConverter.ToInt32(randb, 0);
            value = value % (max + 1);
            if (value < 0)
                value = -value;
            return value;
        }

        /// <summary>
        /// �����һ�������
        /// </summary>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>��һ�������</returns>
        protected static int Next(int min, int max)
        {
            int value = Next(max - min) + min;
            return value;
        }

        #endregion

        protected int defaultCodeLength = 6;
        protected int defaultImageWidth = 120;
        protected int defaultImageHeight = 60;
        protected Color defaultImageBgColor = Color.White;
        protected int defaultTextColor = 0;
      
        /// <summary>
        /// ��ʼ��ʵ��.
        /// </summary>
        /// <param name="defaultCodeLength"></param>
        /// <param name="defaultImageWidth"></param>
        /// <param name="defaultImageHeight"></param>
        /// <param name="defaultImageBgColor"></param>
        /// <param name="defaultTextColor"></param>
        protected void initialize(int defaultCodeLength, int defaultImageWidth, int defaultImageHeight, Color defaultImageBgColor, int defaultTextColor)
        {
            this.defaultCodeLength = defaultCodeLength;

            this.defaultImageWidth = defaultImageWidth;
            this.defaultImageHeight = defaultImageHeight;
            this.defaultImageBgColor = defaultImageBgColor;
            this.defaultTextColor = defaultTextColor;
        }

        #region IVerifyImageGenerator Element.

        /// <summary>
        /// ������֤��(��ȱʡ����������֤��)
        /// </summary>
        /// <returns>��֤��</returns>
        public string GenerateCode()
        {
            return this.GenerateCode(this.defaultCodeLength);
        }

        /// <summary>
        /// ������֤��(��ָ������������֤��)
        /// </summary>
        /// <param name="length">Ҫ���ɵ���֤��ĳ���</param>
        /// <returns>��֤��</returns>
        public virtual string GenerateCode(int length)
        {
            if (length > 10) length = 10;
            if (length < 1) length = 1;

            return Guid.NewGuid().ToString().Substring(0, length);
        }

        public VerifyImageInfo GenerateImage()
        {
            return this.GenerateImage(this.defaultCodeLength);
        }

        public VerifyImageInfo GenerateImage(int codeLength)
        {
            string code = this.GenerateCode(codeLength);
            return this.GenerateImage(code);
        }

        public VerifyImageInfo GenerateImage(string code)
        {
            return this.GenerateImage(code, this.defaultImageWidth, this.defaultImageHeight);
        }

        public VerifyImageInfo GenerateImage(string code, int width, int height)
        {
            return this.GenerateImage(code, width, height, this.defaultImageBgColor);
        }

        public VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor)
        {
            return this.GenerateImage(code, width, height, bgcolor, this.defaultTextColor);
        }

        public abstract VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor);


        #endregion
    }
}
