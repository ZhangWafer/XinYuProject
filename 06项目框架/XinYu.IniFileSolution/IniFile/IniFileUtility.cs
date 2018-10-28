using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace XinYu.IniFileService
{
    /// <summary> Ini文件工具类
    /// </summary>
    public class IniFileUtility
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary> 读取文件指定章节、指定键对应的值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="section">章节</param>
        /// <param name="key">键</param>
        /// <returns>返回对应的字符串</returns>
        public static string ReadFromFile(string filePath, string section, string key)
        {
            var fileInfo = new FileInfo(filePath);
            var size = (int) fileInfo.Length;
            var temp = new StringBuilder(size);
            GetPrivateProfileString(section, key, "", temp, size, filePath);

            return temp.ToString().Trim();
        }

        /// <summary> 写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="section">章节</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void WriteToFile(string filePath, string section, string key, string value)
        {
            var dirPath = Path.GetDirectoryName(filePath);
            if (false == Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary> 清除某个章节
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="section">章节</param>
        public static void EraseSection(string filePath, string section)
        {
            if (WritePrivateProfileString(section, null, null, filePath) == 0)
            {
                throw (new ApplicationException("无法清除Ini文件中的Section"));
            }
        }

        /// <summary> 删除某个章节下的键
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="section">章节</param>
        /// <param name="key">键</param>
        public static void DeleteKey(string filePath, string section, string key)
        {
            WritePrivateProfileString(section, key, null, filePath);
        }
    }
}