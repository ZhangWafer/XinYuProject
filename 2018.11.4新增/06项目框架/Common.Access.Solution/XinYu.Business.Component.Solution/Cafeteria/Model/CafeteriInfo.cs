using System;

namespace XinYu.Framework.Cafeteria.Model
{

    /// <summary>
    /// 食堂信息类
    /// </summary>
    public class CafeteriInfo
    {
        public CafeteriInfo() { }

        /// <summary>
        /// 食堂ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 供餐类型
        /// </summary>
        public CafeteriaTypeEnum CafeteriaTypeEnum { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public int DisplayOrder { get; set; }

        public int CreatedByID { get; set; }

        public string CreatedByName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastUpdByID { get; set; }

        public string LastUpdByName { get; set; }

        public DateTime LastUpdDate { get; set; }
    }
}
