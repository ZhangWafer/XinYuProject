using System;
using XinYu.Framework.Staff;

namespace XinYu.Framework.Cookbook.Model
{
    public class CookbookPreferentialWorkerInfo
    {
        public CookbookPreferentialWorkerInfo() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public WorkerStaffEnum WorkerStaffEnum { get; set; }

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
