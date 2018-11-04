using System;

namespace XinYu.Framework.Cookbook.Model
{
    /// <summary>
    /// 菜品警衔优惠实体
    /// </summary>
    public class CookbookPreferentialInRankInfo
    {
        public CookbookPreferentialInRankInfo() { }

        /// <summary>
        /// 优惠ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 优惠名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 警衔ID
        /// </summary>
        public int RankId { get; set; }

        /// <summary>
        /// 警衔
        /// </summary>
        public string RandName { get; set; }

        /// <summary>
        /// 菜品ID
        /// </summary>
        public int CookbookId { get; set; }

        /// <summary>
        /// 菜品名称
        /// </summary>
        public string CookbookName { get; set; }

        /// <summary>
        /// 可优惠价格
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 实际支付价格
        /// </summary>
        public decimal RealPrice { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int? OrganizationId { get; set; }

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
