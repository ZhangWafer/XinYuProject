using System.Collections.Generic;
using XinYu.Framework.Library.Factory;
using XinYu.Framework.Library.Interface;
using XinYu.Framework.Staff.DAL.SQLServer;
using XinYu.Framework.Staff.Model;

namespace XinYu.Framework.Staff.BLL
{
    /// <summary>
    /// 人员管理访问类（警员、食管、警衔）
    /// </summary>
    public class StaffBLL
    {
        #region 警衔管理访问类 RankDAL
        protected const string ConstCacheKeyRank = "__rank";

        protected static ICacheManager StaticCacheManager = CommonLibraryFactory.CreateInstance<ICacheManager>();
        protected static RankDAL StaticRankDAL = new RankDAL();

        /// <summary>
        /// 获取警衔列表
        /// </summary>
        /// <param name="name">警衔名称</param>
        /// <param name="orderString">sql排序</param>
        public IList<RankInfo> GetRankList(string name, string orderString)
        {
            var rankList = StaticCacheManager.GetData<IList<RankInfo>>(ConstCacheKeyRank);
            if (rankList == null || rankList.Count == 0)
            {
                rankList = StaticRankDAL.SelectList(name, orderString);
                StaticCacheManager.Add(ConstCacheKeyRank, rankList);  //添加缓存
            }

            return StaticRankDAL.SelectList(name, orderString);
        }
        #endregion

        #region 警员管理访问类s PCStaffInfoDAL
        protected static PCStaffDAL StaticPCStaffDAL = new PCStaffDAL();

        /// <summary>
        /// 添加警员
        /// </summary>
        public void AddPCStaff(PCStaffInfo pcInfo)
        {
            StaticPCStaffDAL.Insert(pcInfo);
        }

        /// <summary>
        /// 移除警员
        /// </summary>
        public void RemovePCStaff(int pcId)
        {
            StaticPCStaffDAL.Delete(pcId);
        }

        /// <summary>
        /// 修改警员
        /// </summary>
        public void ModifyPCStaff(PCStaffInfo pcInfo)
        {
            StaticPCStaffDAL.Update(pcInfo);
        }

        /// <summary>
        /// 获取警员
        /// </summary>
        public PCStaffInfo GetPCStaff(int pcId)
        {
            return StaticPCStaffDAL.Select(pcId);
        }

        /// <summary>
        /// 警员登录验证
        /// </summary>
        public PCStaffInfo PCStaffLogin(string pcNum, string password)
        {
            return StaticPCStaffDAL.Select(pcNum, password);
        }

        /// <summary>
        /// 获取警员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="pcNum">警号</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="orderString">sql排序</param>
        public IList<PCStaffInfo> GetPCStaffList(string name, string pcNum, int? organizationId, string orderString)
        {
            return StaticPCStaffDAL.SelectList(name, pcNum, organizationId, orderString);
        }

        /// <summary>
        /// 获取警员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="pcNum">警号</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="orderString">sql排序</param>
        public IList<PCStaffInfo> GetPCStaffList(string name, string pcNum, int? organizationId, string orderString,
            int pageIndex, int pageSize, out int total)
        {
            return StaticPCStaffDAL.SelectList(name, pcNum, organizationId, orderString, pageIndex, pageSize, out total);
        }

        #endregion

        #region 食管人员访问类  StaticCafeteriaStaffDAL
        protected static CafeteriaStaffDAL StaticCafeteriaStaffDAL = new CafeteriaStaffDAL();

        /// <summary>
        /// 添加食管人员
        /// </summary>
        public void AddCafeteriaStaff(CafeteriaStaffInfo csInfo)
        {
            StaticCafeteriaStaffDAL.Insert(csInfo);
        }

        /// <summary>
        /// 移除食管人员
        /// </summary>
        public void RemoveCafeteriaStaff(int csId)
        {
            StaticCafeteriaStaffDAL.Delete(csId);
        }

        /// <summary>
        /// 修改食管人员
        /// </summary>
        public void ModifyCafeteriaStaff(CafeteriaStaffInfo csInfo)
        {
            StaticCafeteriaStaffDAL.Update(csInfo);
        }

        /// <summary>
        /// 获取食管人员
        /// </summary>
        public CafeteriaStaffInfo GetCafeteriaStaff(int csId)
        {
            return StaticCafeteriaStaffDAL.Select(csId);
        }

        /// <summary>
        /// 获取食管人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<CafeteriaStaffInfo> GetCafeteriaStaffList(string name, int? organizationId, int? cafeteriaId, string orderString)
        {
            return StaticCafeteriaStaffDAL.SelectList(name, organizationId, cafeteriaId, orderString);
        }

        /// <summary>
        /// 获取食管人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<CafeteriaStaffInfo> GetCafeteriaStaffList(string name, int? organizationId, int? cafeteriaId, string orderString,
    int pageIndex, int pageSize, out int total)
        {
            return StaticCafeteriaStaffDAL.SelectList(name, organizationId, cafeteriaId, orderString, pageIndex, pageSize, out total);
        }

        #endregion

        #region 职工人员访问类  StaticCafeteriaStaffDAL
        protected static WorkersStaffDAL StaticWorkerStaffDAL = new WorkersStaffDAL();

        /// <summary>
        /// 添加职工人员
        /// </summary>
        public void AddWorkerStaff(WorkersStaffInfo csInfo)
        {
            StaticWorkerStaffDAL.Insert(csInfo);
        }

        /// <summary>
        /// 移除职工人员
        /// </summary>
        public void RemoveWorkerStaff(int csId)
        {
            StaticWorkerStaffDAL.Delete(csId);
        }

        /// <summary>
        /// 修改职工人员
        /// </summary>
        public void ModifyWorkerStaff(WorkersStaffInfo csInfo)
        {
            StaticWorkerStaffDAL.Update(csInfo);
        }

        /// <summary>
        /// 获取职工人员
        /// </summary>
        public WorkersStaffInfo GetWorkerStaff(int csId)
        {
            return StaticWorkerStaffDAL.Select(csId);
        }

        /// <summary>
        /// 职工人员登录验证
        /// </summary>
        public WorkersStaffInfo WorkerStaffLogin(string informationNum, string password)
        {
            return StaticWorkerStaffDAL.Select(informationNum, password);
        }

        /// <summary>
        /// 获取职工人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<WorkersStaffInfo> GetWorkerStaffList(string name, int? organizationId, int? cafeteriaId, string orderString)
        {
            return StaticWorkerStaffDAL.SelectList(name, organizationId, cafeteriaId, orderString);
        }

        /// <summary>
        /// 获取职工人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<WorkersStaffInfo> GetWorkerStaffList(string name, int? organizationId, int? cafeteriaId, string orderString, int pageIndex, int pageSize, out int total)
        {
            return StaticWorkerStaffDAL.SelectList(name, organizationId, cafeteriaId, orderString, pageIndex, pageSize, out total);
        }

        #endregion
    }
}
