using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Framework.OrderMeal.Model
{
    public class PCStaffOrderMealDetailInfo
    {
        public PCStaffOrderMealDetailInfo() { }

        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 报餐细节记录id
        /// 
        /// </summary>
        public int PCStaffOrderMealId { get; set; }

        /// <summary>
        ///  餐品id
        /// </summary>
        public int CookbookId { get; set; }

        /// <summary>
        ///  餐品名字
        /// </summary>
        public string CookbookName { get; set; }

        /// <summary>
        /// 创建用户名
        /// </summary>
        public string CreatedByName { get; set; }

        /// <summary>
        /// 创建用户id
        /// </summary>
        public int CreatedByID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 最后更新id
        /// </summary>
        public int LastUpdByID { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        public string LastUpdByName { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdDate { get; set; }

    }
}
