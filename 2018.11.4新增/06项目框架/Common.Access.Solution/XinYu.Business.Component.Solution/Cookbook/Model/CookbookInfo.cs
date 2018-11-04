using System;

namespace XinYu.Framework.Cookbook.Model
{

    /// <summary>
    /// 菜品信息实体
    /// </summary>
    public class CookbookInfo
    {
        public CookbookInfo() { }

        /// <summary>
        /// 菜品ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal RealPrice { get; set; }

        /// <summary>
        /// 优惠价格
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 菜品图片
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 缤约图
        /// </summary>
        public string IconThum { get; set; }

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
