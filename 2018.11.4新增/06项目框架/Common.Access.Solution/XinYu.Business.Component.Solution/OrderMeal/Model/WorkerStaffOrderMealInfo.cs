using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Framework.OrderMeal.Model
{
   public  class WorkerStaffOrderMealInfo
    {

            public WorkerStaffOrderMealInfo() { }

            /// <summary>
            /// id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 报餐记录id
            /// 
            /// </summary>
            public int CookbookSetInDateId { get; set; }

            /// <summary>
            ///  职员id
            /// </summary>
            public int WorkerStaffId { get; set; }

            /// <summary>
            ///  创建用户名
            /// </summary>
            public string CreatedByName { get; set; }

            /// <summary>
            /// 创建id
            /// </summary>
            public int CreatedByID { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreatedDate { get; set; }

            /// <summary>
            /// 更新用户id
            /// </summary>
            public int LastUpdByID { get; set; }

            /// <summary>
            /// 更新用户名
            /// </summary>
            public string LastUpdByName { get; set; }

            /// <summary>
            /// 更新日期
            /// </summary>
            public DateTime LastUpdDate { get; set; }


        }
    }
