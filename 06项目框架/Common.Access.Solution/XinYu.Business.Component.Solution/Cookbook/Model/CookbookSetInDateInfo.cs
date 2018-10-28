using System;

namespace XinYu.Framework.Cookbook.Model
{
    /// <summary>
    /// 排餐实体类
    /// </summary>
    public class CookbookSetInDateInfo
    {
        public CookbookSetInDateInfo() { }

        /// <summary>
        /// 排餐ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 食堂ID
        /// </summary>
        public int CafeteriaId { get; set; }

        /// <summary>
        /// 食堂名称
        /// </summary>
        public string CafeteriaName { get; set; }

        /// <summary>
        /// 排餐时段
        /// </summary>
        public CookbookEnum CookbookEnum { get; set; }

        /// <summary>
        /// 排餐日期
        /// </summary>
        public DateTime ChooseDate { get; set; }

        /// <summary>
        /// 如果食堂是自助餐，则需要为订餐订价
        /// </summary>
        public Decimal? Price { get; set; }

        /// <summary>
        /// 机构id
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName { get; set; }

        public int DisplayOrder { get; set; }

        public int CreatedByID { get; set; }

        public string CreatedByName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastUpdByID { get; set; }

        public string LastUpdByName { get; set; }

        public DateTime LastUpdDate { get; set; }
    }
}
