// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库验证码图片接口
// Modify History: 
// ============================================================================

using System.Drawing;
using System.Drawing.Imaging;

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// 验证码图片接口
    /// </summary>
    public interface IVerifyImageGenerator
    {
        /// <summary>
        /// 生成验证码(按缺省长度生成验证码)
        /// </summary>
        /// <returns>验证码</returns>
        string GenerateCode();

        /// <summary>
        /// 生成验证码(按指定长度生成验证码)
        /// </summary>
        /// <param name="length">要生成的验证码的长度</param>
        /// <returns>验证码</returns>
        string GenerateCode(int length);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        VerifyImageInfo GenerateImage();

  
        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="codeLength">要显示的验证码的长度</param>
        /// <returns></returns>
        VerifyImageInfo GenerateImage(int codeLength);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="code">要显示的验证码</param>
        VerifyImageInfo GenerateImage(string code);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="code">要显示的验证码</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        VerifyImageInfo GenerateImage(string code, int width, int height);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="code">要显示的验证码</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="bgcolor">背景色</param>
        VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="code">要显示的验证码</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="bgcolor">背景色</param>
        /// <param name="textcolor">文字颜色深度(0 ~ 60)</param>
        VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor);

    }

    /// <summary>
    /// 验证码图片信息
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
        /// <param name="verifyCode">验证码</param>
        /// <param name="image">生成出的图片</param>
        /// <param name="contentType">输出的图片类型，如 image/pjpeg</param>
        /// <param name="imageFormat">图片的格式</param>
        public VerifyImageInfo(string verifyCode, Bitmap image, string contentType, ImageFormat imageFormat)
        {
            this.verifyCode = verifyCode;
            this.image = image;
            this.contentType = contentType;
            this.ImageFormat = ImageFormat;
        }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode
        {
            get { return this.verifyCode; }
            set { this.verifyCode = value; }
        }

        /// <summary>
        /// 生成出的图片
        /// </summary>
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// 输出的图片类型，如 image/pjpeg
        /// </summary>
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        /// <summary>
        /// 图片的格式
        /// </summary>
        public ImageFormat ImageFormat
        {
            get { return imageFormat; }
            set { imageFormat = value; }
        }
    }
}
