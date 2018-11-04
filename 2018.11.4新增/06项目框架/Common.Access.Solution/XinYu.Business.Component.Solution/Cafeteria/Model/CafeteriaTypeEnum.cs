using System.ComponentModel;

namespace XinYu.Framework.Cafeteria.Model
{
    /// <summary>
    /// 枚举：食堂供餐类型
    /// </summary>
    public enum CafeteriaTypeEnum
    {
        [Description("自助餐")]
        Buffet = 1,

        [Description("普通餐")]
        Common = 2 //
    }
}
