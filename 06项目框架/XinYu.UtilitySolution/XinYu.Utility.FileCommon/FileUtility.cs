using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace XinYu.Utility.FileCommon
{
    /// <summary> 文件工具类
    /// </summary>
    public class FileUtility
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        /// <summary> 文件是否被使用
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件被使用，返回 true；否则返回 false</returns>
        public static bool FileIsUsed(string filePath)
        {
            const int ofReadwrite = 2;
            const int ofShareDenyNone = 0x40;
            IntPtr hfileError = new IntPtr(-1);
            bool isUsed = false;
            if (File.Exists(filePath))
            {
                IntPtr vHandle = _lopen(filePath, ofReadwrite | ofShareDenyNone);
                if (vHandle == hfileError)
                    isUsed = true;

                CloseHandle(vHandle);
            }
            return isUsed;
        }

        /// <summary> 获取文件名称，如（test.xml）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回文件名称</returns>
        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        /// <summary> 获取文件扩展名，如（.xml）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回文件扩展名</returns>
        public static string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        /// <summary> 获取除去扩展名后文件名称，如（test）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回除去扩展名后文件名称</returns>
        public static string GetFileNameWithoutExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        /// <summary> 获取文件所在的目录路径
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回文件所在的目录路径</returns>
        public static string GetDirectoryPath(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

        /// <summary> 将现有文件复制到新文件
        /// </summary>
        /// <param name="sourceFilePath">要复制的文件路径</param>
        /// <param name="destFilePath">目标文件的路径。不能是目录</param>
        /// <param name="overwrite">覆盖目标文件，则为 true；否则为 false</param>
        public static void Copy(string sourceFilePath, string destFilePath, bool overwrite)
        {
            File.Copy(sourceFilePath, destFilePath, overwrite);
        }

        /// <summary> 替换文件扩展名
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="suffix">扩展名</param>
        /// <returns>返回替换文件扩展名后的文件名</returns>
        public static string ReplaceFileExtension(string fileName, string suffix)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            if (string.IsNullOrWhiteSpace(suffix))
                return fileName;

            var extension = GetFileExtension(fileName);
            if (string.IsNullOrWhiteSpace(extension))
                return fileName + suffix;

            if (string.Equals(extension, suffix, StringComparison.CurrentCultureIgnoreCase))
                return fileName;

            var index = fileName.LastIndexOf(extension, StringComparison.CurrentCultureIgnoreCase);
            var destFileName = fileName.Substring(0, index) + suffix;
            return destFileName;
        }

        /// <summary> 移除文件扩展名
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>去掉后缀的文件路径</returns>
        public static string RemoveFileExtension(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return filePath;

            var parentDirPath = Path.GetDirectoryName(filePath) ?? string.Empty;
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var newFilePath = Path.Combine(parentDirPath, fileName);
            return newFilePath;
        }

        /// <summary> 文件路径最大长度
        /// </summary>
        public static readonly int MaxFileLength = 260;

        /// <summary> 验证文件名称是否合法
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <returns>文件名称合法，返回 true；否则返回 false</returns>
        public static bool IsValidFileName(string fileName)
        {
            fileName = fileName.Trim();
            if (string.IsNullOrWhiteSpace(fileName) || fileName.Length > MaxFileLength)
            {
                return false;
            }
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return false;
            }
            if (PathUtility.IsSpecialWinDeviceName(fileName))
            {
                return false;
            }
            if (fileName.EndsWith("."))
            {
                return false;
            }
            return true;
        }

        /// <summary> 获取指定目录下不重名的文件名称
        /// </summary>
        /// <param name="dirInfo">目录信息</param>
        /// <param name="fileName">文件名称</param>
        /// <returns>如果文件不存在，则返回文件名称；否则返回“文件名称_n.文件后缀”，n=1，2，3...</returns>
        public static string GetNoRepeatFileName(DirectoryInfo dirInfo, string fileName)
        {
            var fileNameWithoutExtention = GetFileNameWithoutExtension(fileName);
            var extention = GetFileExtension(fileName);
            var resultName = GetNoRepeatFileName(dirInfo, fileNameWithoutExtention, extention);

            return resultName + extention;
        }

        /// <summary> 获取指定目录下不重名的文件名称（不带后缀）
        /// </summary>
        /// <param name="dirInfo">目录信息</param>
        /// <param name="fileNameWithoutExtention">没有后缀的文件名称</param>
        /// <param name="extention">文件后缀</param>
        /// <returns>如果文件不存在，则返回没有后缀的文件名称；否则返回“文件名称_n”，n=1，2，3...</returns>
        public static string GetNoRepeatFileName(DirectoryInfo dirInfo, string fileNameWithoutExtention, string extention)
        {
            var resultName = fileNameWithoutExtention + extention;
            var resultPath = Path.Combine(dirInfo.FullName, resultName);
            var count = 0;
            while (File.Exists(resultPath))
            {
                count = count + 1;
                resultName = fileNameWithoutExtention + "_" + count;
                resultPath = Path.Combine(dirInfo.FullName, resultName + extention);
            }
            return resultName;
        }

        /// <summary> 删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="toRecycleBin">是否删除到回收站</param>
        public static void Delete(string filePath, bool toRecycleBin = false)
        {
            if (false == File.Exists(filePath))
                return;

            if (toRecycleBin)
                RecybleBin.Send(filePath);
            else
                File.Delete(filePath);
        }

        /// <summary> 使用UTF-8编码，读取文件，并返回所有字符串
        /// </summary>
        /// <param name="filePath">文件内容</param>
        /// <returns>返回文件所有字符串</returns>
        public static string ReadFromFile(string filePath)
        {
            return ReadFromFile(filePath, Encoding.UTF8);
        }

        /// <summary> 读取文件，并返回所有字符串
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">文件字符编码</param>
        /// <returns>返回文件所有字符串</returns>
        public static string ReadFromFile(string filePath, Encoding encoding)
        {
            if (false == File.Exists(filePath))
                return string.Empty;

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                stream.Position = 0;
                using (var reader = new StreamReader(stream, encoding))
                {
                    var str = reader.ReadToEnd();
                    return str;
                }
            }
        }

        /// <summary> 使用UTF-8编码，将字符串写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="str">待写入的字符串</param>
        public static void WriteToFile(string filePath, string str)
        {
            WriteToFile(filePath, str, Encoding.UTF8);
        }

        /// <summary> 将字符串写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="str">待写入的字符串</param>
        /// <param name="encoding">文件字符编码</param>
        public static void WriteToFile(string filePath, string str, Encoding encoding)
        {
            var dirPath = Path.GetDirectoryName(filePath);
            if (false == Directory.Exists(dirPath))
            {
                if (dirPath != null)
                {
                    Directory.CreateDirectory(dirPath);
                }
            }

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var writer = new StreamWriter(stream, encoding))
                {
                    writer.Write(str);
                    writer.Flush();
                }
            }
        }
    }
}