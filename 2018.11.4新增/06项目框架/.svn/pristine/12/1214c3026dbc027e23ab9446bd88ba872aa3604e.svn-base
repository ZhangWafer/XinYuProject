using System;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

/// <summary>
///FileUtility 的摘要说明
/// </summary>
public class FileUtility
{

    #region 基本文件操作相关方法。
    /// <summary>
    /// 获取文件后缀名
    /// </summary>
    public static string GetExtension(string fileName)
    {
        return Path.GetExtension(fileName).ToLower();
    }

    /// <summary>
    ///获取新文件名
    /// </summary>
    public static string GetNewFileName(string oldFileName)
    {
        return Guid.NewGuid() + GetExtension(oldFileName);
    }

    /// <summary>
    /// 得到文件物理绝对路径
    /// </summary>
    public static string GetPhysicAbsoluteFullFileName(string relaDirectoryName, string fileName)
    {
        relaDirectoryName = Path.Combine(relaDirectoryName, fileName);
        return HttpContext.Current.Server.MapPath(relaDirectoryName);
    }

    /// <summary>
    /// 得到文件相对路径
    /// </summary>
    public static string GetWebRelativeFullFileName(string relaDirectoryName, string fileName)
    {
        return Path.Combine(relaDirectoryName, fileName);
    }

    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    #endregion



    const string ConstRelaDirectoryMenuIcon = "upload/menuicon/";

    public const string ConstPCStaffIcon = "~/Files/Icon/PC/";
    public const string ConstCafeteriaStaffIcon = "~/Files/Icon/Cafeteria/";

    public const string ConstCookbookImg = "~/Files/Cookbook/";

    /// <summary>
    /// 保存上传的菜单图标
    /// </summary>
    public static string SaveUploadingMenuIcon(FileUpload upload)
    {
        if (!upload.HasFile) return string.Empty;

        string newIconName = GetNewFileName(upload.FileName);
        string iconFilePath = GetWebRelativeFullFileName(ConstRelaDirectoryMenuIcon, newIconName);

        upload.SaveAs(iconFilePath);

        return iconFilePath;
    }

    /// <summary>
    /// 保存上传的普通文件
    /// </summary>
    public static void SaveUploadingFile(FileUpload upload, string fileName)
    {
        upload.SaveAs(fileName);
    }

    /// <summary>
    /// 上传文件
    /// </summary>
    public static void FileSave(string fileName, HttpPostedFile postFile, double width, double height, string thumbnailName)
    {
        postFile.SaveAs(fileName);  //保存原图

        var image = System.Drawing.Image.FromFile(fileName);  //封装图像
        UploadImgThumbnail(image, width, height, thumbnailName);  //上传缩约图

        image.Dispose();
    }

   
    public static void FileCopy(string sourceFileName, string desFileName, double width, double height, string name)
    {
        File.Copy(sourceFileName, desFileName);

        //封装图像
        System.Drawing.Image image = System.Drawing.Image.FromFile(desFileName);

        //上传缩约图
        UploadImgThumbnail(image, width, height, name);

        image.Dispose();
    }


    /// <summary>
    /// 上传缩略图
    /// </summary>
    public static void UploadImgThumbnail(System.Drawing.Image fileName, double width, double height, string thumbnailName)
    {

        if (fileName != null)
        {
            //判断指定的图片的大小
            Double newWidth, newHeight;
            if (fileName.Width > fileName.Height)
            {
                newWidth = width;
                newHeight = fileName.Height * (newWidth / fileName.Width);
            }
            else
            {
                newHeight = height;
                newWidth = fileName.Width * (newHeight / fileName.Height);
            }
            if (newWidth > width)
            {
                newWidth = width;
            }
            if (newHeight > height)
            {
                newHeight = height;
            }

            if (width == 64 || width == 32)
            {
                newWidth = width;
            }

            if (height == 64 || height == 32)
            {
                newHeight = height;
            }

            //取得图片大小
            var size = new Size((int)newWidth, (int)newHeight);
            //新建一个BMP图片
            System.Drawing.Image bitmap = new Bitmap(size.Width, size.Height);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            //高质量低速度呈现平滑
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            //清空画布，背影色
            g.Clear(Color.White);
            //在指定位置画图
            g.DrawImage(fileName, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, fileName.Width, fileName.Height), GraphicsUnit.Pixel);

            //保存高清度缩略图
            bitmap.Save(thumbnailName);
            g.Dispose();
            bitmap.Dispose();
            fileName.Dispose();
        }
    }

    /// <summary>
    /// 创建存放文件的目录
    /// </summary>
    public static void CreateIconFolder()
    {
        var pcFolcer = HttpContext.Current.Server.MapPath(ConstPCStaffIcon);
        var cafeteriaFolder = HttpContext.Current.Server.MapPath(ConstCafeteriaStaffIcon);
        var cookbookFoloder = HttpContext.Current.Server.MapPath(ConstCookbookImg);

        if (!Directory.Exists(pcFolcer))
            Directory.CreateDirectory(pcFolcer);

        if (!Directory.Exists(cafeteriaFolder))
            Directory.CreateDirectory(cafeteriaFolder);

        if (!Directory.Exists(cookbookFoloder))
            Directory.CreateDirectory(cookbookFoloder);
    }
}