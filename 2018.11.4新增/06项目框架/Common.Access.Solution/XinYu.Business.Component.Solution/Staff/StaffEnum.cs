using System.ComponentModel;

namespace XinYu.Framework.Staff
{
    /// <summary>
    /// 人员类型枚举
    /// </summary>
    public enum StaffEnum
    {
        [Description("警员")]
        Police = 1,

        [Description("食管人员")]
        Cafeteria = 2,

        [Description("职工类人员")]
        WorkerStaff = 3,

        [Description("其他")]
        Other = 0
    }
    

    /// <summary>
    /// 非警员用餐人员类别
    /// </summary>
    public enum WorkerStaffEnum
    {
        [Description("职工")]
        Emploee = 1,

        [Description("驻场人员")]
        Stationed = 2,

        [Description("工作人员")]
        Worker = 3,

        [Description("其他")]
        Other = 0
    }

}
