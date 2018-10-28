using System;
using System.Text.RegularExpressions;

/// <summary>
///ValidationUtility 的摘要说明
/// </summary>
public static class ValidationUtility
{
    #region IsDecimal

    /// <summary>
    /// 验证是否为小数点数值
    /// </summary>
    /// <param name="numberString">需要验证的字符串</param>
    /// <returns>true 是 false 否</returns>
    public static bool IsDecimal(string numberString)
    {
        var rCode = new Regex("^[+-]?\\d+(\\.\\d+)?$");
        if (!rCode.IsMatch(numberString))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region IsCurrency

    /// <summary>
    /// 验证是否为货币金额格式
    /// </summary>
    /// <param name="numberString">需要验证的字符串</param>
    /// <returns>true 是 false 否</returns>
    public static bool IsCurrency(string numberString)
    {

        // 可变，所以此方法暂时为空
        return true;
    }
    #endregion

    #region IsMiles

    /// <summary>
    /// 验证是否为货币金额格式
    /// </summary>
    /// <param name="numberString">需要验证的字符串</param>
    /// <returns>true 是 false 否</returns>
    public static bool IsMiles(string numberString)
    {

        //可变，所以此方法暂时为空
        return true;
    }
    #endregion

    #region IsIPAddress
    public static bool IsIPAddress(string ipString)
    {
        var rCode = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
        if (!rCode.IsMatch(ipString))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region IsNumric

    /// <summary>
    ///	验证是否为整数型数值
    /// </summary>
    /// <param name="numberString">需哟验证的字符串</param>
    /// <returns>true 是 false 否</returns>
    public static bool IsNumric(string numberString)
    {
        var rCode = new Regex("^[+-]?\\d+(\\d+)?$");
        if (!rCode.IsMatch(numberString))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region IsValidDate

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
    #endregion

    #region IsDateGA

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
            return false;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region IsValidEmail

    /// <summary>
    /// 验证是否为有效的邮箱字符串
    /// </summary>
    /// <param name="email">需要验证的字符串</param>
    /// <returns>true 是 false 否</returns>
    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^\w+((-\w+)|(\.\w+))*\@\w+((\.|-)\w+)*\.\w+$");
    }
    #endregion
}