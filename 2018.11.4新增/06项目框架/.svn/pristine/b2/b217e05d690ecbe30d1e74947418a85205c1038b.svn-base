using System;
using System.ComponentModel;

/// <summary>
/// EnumUtility 的摘要说明
/// </summary>
public class EnumUtility
{
    public static string GetDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        var result = attributes.Length > 0 ? attributes[0].Description : null;
        return result;
    }
}