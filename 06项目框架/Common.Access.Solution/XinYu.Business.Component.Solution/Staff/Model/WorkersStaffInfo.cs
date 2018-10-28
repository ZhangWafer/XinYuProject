using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Framework.Staff.Model
{
    public class WorkersStaffInfo
    {
           public WorkersStaffInfo() { }

        /// <summary>
        /// 职工人员ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 职工人员身份证
        /// </summary>
        public int InformationNum { get; set; }

        /// <summary>
        ///  姓名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        ///  类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 相片
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 相片缩约图
        /// </summary>
        public string IconThum { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 食堂ID
        /// </summary>
        public int CafeteriaId { get; set; }

        /// <summary>
        /// 食堂名称
        /// </summary>
        public string CafeteriaName { get; set; }

        public int DisplayOrder { get; set; }

        public int CreatedByID { get; set; }

        public string CreatedByName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastUpdByID { get; set; }

        public string LastUpdByName { get; set; }

        public DateTime LastUpdDate { get; set; }
    }
}
