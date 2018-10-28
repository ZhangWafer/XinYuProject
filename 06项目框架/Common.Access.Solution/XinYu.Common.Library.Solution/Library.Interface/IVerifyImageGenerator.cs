// ============================================================================
// Author:         �Ԅ�
// Create Date:    2018-05-08
// Description:    ��ҵ����֤��ͼƬ�ӿ�
// Modify History: 
// ============================================================================

using System.Drawing;
using System.Drawing.Imaging;

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// ��֤��ͼƬ�ӿ�
    /// </summary>
    public interface IVerifyImageGenerator
    {
        /// <summary>
        /// ������֤��(��ȱʡ����������֤��)
        /// </summary>
        /// <returns>��֤��</returns>
        string GenerateCode();

        /// <summary>
        /// ������֤��(��ָ������������֤��)
        /// </summary>
        /// <param name="length">Ҫ���ɵ���֤��ĳ���</param>
        /// <returns>��֤��</returns>
        string GenerateCode(int length);

        /// <summary>
        /// ������֤��ͼƬ
        /// </summary>
        VerifyImageInfo GenerateImage();

  
        /// <summary>
        /// ������֤��ͼƬ
        /// </summary>
        /// <param name="codeLength">Ҫ��ʾ����֤��ĳ���</param>
        /// <returns></returns>
        VerifyImageInfo GenerateImage(int codeLength);

        /// <summary>
        /// ������֤��ͼƬ
        /// </summary>
        /// <param name="code">Ҫ��ʾ����֤��</param>
        VerifyImageInfo GenerateImage(string code);

        /// <summary>
        /// ������֤��ͼƬ
        /// </summary>
        /// <param name="code">Ҫ��ʾ����֤��</param>
        /// <param name="width">���</param>
        /// <param name="height">�߶�</param>
        VerifyImageInfo GenerateImage(string code, int width, int height);

        /// <summary>
        /// ������֤��ͼƬ
        /// </summary>
        /// <param name="code">Ҫ��ʾ����֤��</param>
        /// <param name="width">���</param>
        /// <param name="height">�߶�</param>
        /// <param name="bgcolor">����ɫ</param>
        VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor);

        /// <summary>
        /// ������֤��ͼƬ
        /// </summary>
        /// <param name="code">Ҫ��ʾ����֤��</param>
        /// <param name="width">���</param>
        /// <param name="height">�߶�</param>
        /// <param name="bgcolor">����ɫ</param>
        /// <param name="textcolor">������ɫ���(0 ~ 60)</param>
        VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor);

    }

    /// <summary>
    /// ��֤��ͼƬ��Ϣ
    /// </summary>
    public class VerifyImageInfo
    {
        private string verifyCode;
        private Bitmap image;
        private string contentType = "image/pjpeg";
        private ImageFormat imageFormat = ImageFormat.Jpeg;

        /// <summary>
        /// Constructor.
        /// </summary>
        public VerifyImageInfo()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="verifyCode">��֤��</param>
        /// <param name="image">���ɳ���ͼƬ</param>
        /// <param name="contentType">�����ͼƬ���ͣ��� image/pjpeg</param>
        /// <param name="imageFormat">ͼƬ�ĸ�ʽ</param>
        public VerifyImageInfo(string verifyCode, Bitmap image, string contentType, ImageFormat imageFormat)
        {
            this.verifyCode = verifyCode;
            this.image = image;
            this.contentType = contentType;
            this.ImageFormat = ImageFormat;
        }

        /// <summary>
        /// ��֤��
        /// </summary>
        public string VerifyCode
        {
            get { return this.verifyCode; }
            set { this.verifyCode = value; }
        }

        /// <summary>
        /// ���ɳ���ͼƬ
        /// </summary>
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// �����ͼƬ���ͣ��� image/pjpeg
        /// </summary>
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        /// <summary>
        /// ͼƬ�ĸ�ʽ
        /// </summary>
        public ImageFormat ImageFormat
        {
            get { return imageFormat; }
            set { imageFormat = value; }
        }
    }
}
