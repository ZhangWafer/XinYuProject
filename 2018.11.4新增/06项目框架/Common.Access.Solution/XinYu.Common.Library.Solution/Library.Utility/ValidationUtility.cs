using System;
using System.Text.RegularExpressions;

namespace XinYu.Framework.Library.Utility
{
    /// <summary>
    /// 格式验证工具类。
    /// </summary>
    public static class ValidationUtility
    {

        /// <summary>
        /// 验证是否为有效的邮箱字符串
        /// </summary>
        /// <param name="email">需要验证的字符串</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^\w+((-\w+)|(\.\w+))*\@\w+((\.|-)\w+)*\.\w+$");

            return emailRegex.IsMatch(email);
        }

        /// <summary>
        /// 验证是否为小数点数值
        /// </summary>
        /// <param name="numberString">需要验证的字符串</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsDecimal(string numberString)
        {
            Regex regex = new Regex("^[+-]?\\d+(\\.\\d+)?$");

            return regex.IsMatch(numberString);
        }


        /// <summary>
        ///	验证是否为整数型数值
        /// </summary>
        /// <param name="numberString">需哟验证的字符串</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsInteger(string integerString)
        {
            Regex regex = new Regex("^[+-]?\\d+(\\d+)?$");

            return regex.IsMatch(integerString);
        }


        #region Validation methods on Date.

        /// <summary>
        /// 验证是否为有效的日期型数值
        /// </summary>
        /// <param name="dateString">需要验证的字符串</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsValidDate(string dateString)
        {
            try
            {
                DateTime.Parse(dateString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否前一个日期大于后一个日期
        /// </summary>
        /// <param name="dateString">前日期</param>
        /// <param name="dateString1">后日期</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsDateGA(string dateString, string dateString1)
        {
            try
            {
                if (DateTime.Parse(dateString) > DateTime.Parse(dateString1))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否前一个日期不大于后一个日期
        /// </summary>
        /// <param name="dateString">前日期</param>
        /// <param name="dateString1">后日期</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsDateLA(string dateString, string dateString1)
        {
            try
            {
                if (DateTime.Parse(dateString) <= DateTime.Parse(dateString1))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}
