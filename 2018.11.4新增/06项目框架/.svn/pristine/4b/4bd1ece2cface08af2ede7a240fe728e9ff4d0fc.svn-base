using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace XinYu.Utility.FileCommon
{
    /// <summary> 路径工具类
    /// </summary>
    public static class PathUtility
    {
        /// <summary> 操作系统的特殊设备名称集合
        /// </summary>
        private static readonly string[] SpecialWinDeviceNames =
        {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
        };

        /// <summary> 判断是否为操作系统的特殊设备名称
        /// <remarks> 操作系统的特殊设备名称不能作为目录和文件名称 </remarks>
        /// </summary>
        /// <param name="name">目录名称或文件名称</param>
        /// <returns>如果为特殊设备名称，返回 true；否则返回 false</returns>
        public static bool IsSpecialWinDeviceName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (SpecialWinDeviceNames.Any(v => string.Equals(v, name, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            return false;
        }

        /// <summary> 路径分隔符
        /// </summary>
        private static char[] separators =
        {
            Path.DirectorySeparatorChar, 
            Path.AltDirectorySeparatorChar,
            Path.VolumeSeparatorChar
        };

        /// <summary> 获取绝对路径
        /// </summary>
        /// <param name="baseDirPath">基础目录路径</param>
        /// <param name="relativePath">相对路径</param>
        /// <returns>返回绝对路径</returns>
        public static string GetAbsolutePath(string baseDirPath, string relativePath)
        {
            if (string.IsNullOrWhiteSpace(baseDirPath) || string.IsNullOrWhiteSpace(relativePath))
                return string.Empty;

            var path = Path.Combine(baseDirPath.Trim(), relativePath.Trim());
            return Path.GetFullPath(path);
        }

        /// <summary> 获取相对路径
        /// </summary>
        /// <param name="baseDirPath">基础目录路径</param>
        /// <param name="absolutePath">绝对路径</param>
        /// <returns>返回相对路径</returns>
        public static string GetRelativePath(string baseDirPath, string absolutePath)
        {
            if (string.IsNullOrWhiteSpace(baseDirPath) || string.IsNullOrWhiteSpace(absolutePath))
                return string.Empty;

            baseDirPath = baseDirPath.Trim();
            absolutePath = absolutePath.Trim();

            string[] bPath = baseDirPath.Split(separators);
            string[] aPath = absolutePath.Split(separators);
            int indx = 0;
            for (; indx < Math.Min(bPath.Length, aPath.Length); ++indx)
            {
                if (!bPath[indx].Equals(aPath[indx], StringComparison.OrdinalIgnoreCase))
                    break;
            }

            if (indx == 0)
            {
                return absolutePath;
            }
            StringBuilder erg = new StringBuilder();
            if (indx != bPath.Length)
            {
                for (int i = indx; i < bPath.Length; ++i)
                {
                    erg.Append("..");
                    erg.Append(Path.DirectorySeparatorChar);
                }
            }
            erg.Append(String.Join(Path.DirectorySeparatorChar.ToString(), aPath, indx, aPath.Length - indx));
            return erg.ToString();
        }

        /// <summary> 判断路径是否存在
        /// </summary>
        /// <param name="path">路径（文件夹或文件路径）</param>
        /// <returns>路径存在，返回true；否则返回false</returns>
        public static bool IsPathExists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            var isExists = false;
            isExists = File.Exists(path);
            if (false == isExists)
            {
                isExists = Directory.Exists(path);
            }
            return isExists;
        }

        /// <summary> 在资源管理器中打开目录以及文件
        /// </summary>
        /// <param name="path">目录或者文件路径</param>
        public static void OpenExplorer(string path)
        {
            //是文件路径
            if (File.Exists(path))
            {
                Process.Start("explorer.exe", @"/select," + '"' + path + '"');
                return;
            }
            //其余都调用这个方法，路径不存在的话打开默认得资源管理器
            Process.Start("explorer.exe", '"' + path + '"');
        }

        /// <summary> 获取操作系统的临时目录路径
        /// </summary>
        /// <returns>返回操作系统的临时目录路径</returns>
        public static string GetTempDirPath()
        {
            return Path.GetTempPath();
        }

        /// <summary> 获取操作系统创建一个零字节临时文件路径
        /// </summary>
        /// <returns>返回操作系统创建一个零字节临时文件路径</returns>
        public static string GetTempFilePath()
        {
            return Path.GetTempFileName();
        }

    }
}
