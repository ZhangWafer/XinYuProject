using System;
using System.Text.RegularExpressions;

namespace XinYu.Framework.Library.Utility
{
    /// <summary>
    /// ��ʽ��֤�����ࡣ
    /// </summary>
    public static class ValidationUtility
    {

        /// <summary>
        /// ��֤�Ƿ�Ϊ��Ч�������ַ���
        /// </summary>
        /// <param name="email">��Ҫ��֤���ַ���</param>
        /// <returns>true �� false ��</returns>
        public static bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^\w+((-\w+)|(\.\w+))*\@\w+((\.|-)\w+)*\.\w+$");

            return emailRegex.IsMatch(email);
        }

        /// <summary>
        /// ��֤�Ƿ�ΪС������ֵ
        /// </summary>
        /// <param name="numberString">��Ҫ��֤���ַ���</param>
        /// <returns>true �� false ��</returns>
        public static bool IsDecimal(string numberString)
        {
            Regex regex = new Regex("^[+-]?\\d+(\\.\\d+)?$");

            return regex.IsMatch(numberString);
        }


        /// <summary>
        ///	��֤�Ƿ�Ϊ��������ֵ
        /// </summary>
        /// <param name="numberString">��Ӵ��֤���ַ���</param>
        /// <returns>true �� false ��</returns>
        public static bool IsInteger(string integerString)
        {
            Regex regex = new Regex("^[+-]?\\d+(\\d+)?$");

            return regex.IsMatch(integerString);
        }


        #region Validation methods on Date.

        /// <summary>
        /// ��֤�Ƿ�Ϊ��Ч����������ֵ
        /// </summary>
        /// <param name="dateString">��Ҫ��֤���ַ���</param>
        /// <returns>true �� false ��</returns>
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
        /// ��֤�Ƿ�ǰһ�����ڴ��ں�һ������
        /// </summary>
        /// <param name="dateString">ǰ����</param>
        /// <param name="dateString1">������</param>
        /// <returns>true �� false ��</returns>
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
        /// ��֤�Ƿ�ǰһ�����ڲ����ں�һ������
        /// </summary>
        /// <param name="dateString">ǰ����</param>
        /// <param name="dateString1">������</param>
        /// <returns>true �� false ��</returns>
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
