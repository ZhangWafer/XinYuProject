using System;
using System.Collections.Generic;
using XinYu.Framework.Cookbook.DAL.SQLServer;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Staff;

namespace XinYu.Framework.Cookbook.BLL
{
    /// <summary>
    /// 菜品管理、菜品优惠和排餐管理业务访问类
    /// </summary>
    public class CookbookBLL
    {
        #region 菜品业务访问类   StaticCookbookDAL
        protected static CookbookDAL StaticCookbookDAL = new CookbookDAL();

        /// <summary>
        /// 添加菜品
        /// </summary>
        public void AddCookbook(CookbookInfo cbInfo)
        {
            StaticCookbookDAL.Insert(cbInfo);
        }

        /// <summary>
        /// 删除菜品
        /// </summary>
        public void RemoveCookbook(int csId)
        {
            StaticCookbookDAL.Delete(csId);
        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        public void ModifyCookbook(CookbookInfo cbInfo)
        {
            StaticCookbookDAL.Update(cbInfo);
        }

        /// <summary>
        /// 获取菜品
        /// </summary>
        public CookbookInfo GetCookbook(int cbId)
        {
            return StaticCookbookDAL.Select(cbId);
        }

        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="organizationId">机构ID</param>
        public IList<CookbookInfo> GetCookbookList(string name, int? organizationId, string orderString)
        {
            return StaticCookbookDAL.SelectList(name, organizationId, orderString);
        }

        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="organizationId">机构ID</param>
        public IList<CookbookInfo> GetCookbookList(string name, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            return StaticCookbookDAL.SelectList(name, organizationId, orderString, pageIndex, pageSize, out total);
        }

        #endregion

        #region 警员菜品优惠业务访问类（根据警衔设置优惠方案）  CookbookPreferentialInRankDAL
        protected static CookbookPreferentialInRankDAL StaticCookbookPreferentialInRankDAL = new CookbookPreferentialInRankDAL();

        /// <summary>
        /// 添加菜品优惠
        /// </summary>
        public void AddCookbookPreferentialInRank(CookbookPreferentialInRankInfo cprInfo)
        {
            StaticCookbookPreferentialInRankDAL.Insert(cprInfo);
        }

        /// <summary>
        /// 删除菜品优惠
        /// </summary>
        public void RemoveCookbookPreferentialInRank(int csId)
        {
            StaticCookbookPreferentialInRankDAL.Delete(csId);
        }

        /// <summary>
        /// 修改菜品优惠
        /// </summary>
        public void ModifyCookbookPreferentialInRank(CookbookPreferentialInRankInfo cbInfo)
        {
            StaticCookbookPreferentialInRankDAL.Update(cbInfo);
        }

        /// <summary>
        /// 获取菜品优惠
        /// </summary>
        public CookbookPreferentialInRankInfo GetCookbookPreferentialInRank(int cbId)
        {
            return StaticCookbookPreferentialInRankDAL.Select(cbId);
        }

        /// <summary>
        /// 获取菜品优惠
        /// </summary>
        /// <param name="rankId">警衔ID</param>
        /// <param name="cookbookId">菜品ID</param>
        /// <param name="organizationId">机构ID</param>
        public CookbookPreferentialInRankInfo GetCookbookPreferentialInRank(int rankId, int cookbookId, int organizationId)
        {
            return StaticCookbookPreferentialInRankDAL.Select(rankId, cookbookId, organizationId);
        }

        /// <summary>
        ///  获取菜品优列表
        /// </summary>
        /// <param name="name">优惠名称</param>
        /// <param name="rankId">警衔ID</param>
        /// <param name="cookbookId">菜品ID</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="orderString">排序SQL</param>
        /// <returns></returns>
        public IList<CookbookPreferentialInRankInfo> GetCookbookPreferentialInRankList(string name, int? rankId, int? cookbookId, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            return StaticCookbookPreferentialInRankDAL.SelectList(name, rankId, cookbookId, organizationId, orderString, pageIndex, pageSize, out total);
        }

        #endregion

        #region 职工菜品优惠业务访问类（根据职工类别设置优惠方案）  CookbookPreferentialWorkerDAL
        protected static CookbookPreferentialWorkerDAL StaticCookbookPreferentialWorkerDAL = new CookbookPreferentialWorkerDAL();

        public void AddCookbookPreferentialWorker(CookbookPreferentialWorkerInfo cprInfo)
        {
            StaticCookbookPreferentialWorkerDAL.Insert(cprInfo);
        }

        /// <summary>
        /// 删除菜品优惠
        /// </summary>
        public void RemoveCookbookPreferentialWorker(int csId)
        {
            StaticCookbookPreferentialWorkerDAL.Delete(csId);
        }

        /// <summary>
        /// 修改菜品优惠
        /// </summary>
        public void ModifyCookbookPreferentialWorker(CookbookPreferentialWorkerInfo cbInfo)
        {
            StaticCookbookPreferentialWorkerDAL.Update(cbInfo);
        }

        /// <summary>
        /// 获取菜品优惠
        /// </summary>
        public CookbookPreferentialWorkerInfo GetCookbookPreferentialWorker(int cbId)
        {
            return StaticCookbookPreferentialWorkerDAL.Select(cbId);
        }

        /// <summary>
        /// 获取菜品优惠
        /// </summary>
        public CookbookPreferentialWorkerInfo GetCookbookPreferentialWorker(WorkerStaffEnum workerStaffEnum, int cookbookId, int organizationId)
        {
            return StaticCookbookPreferentialWorkerDAL.Select(workerStaffEnum, cookbookId, organizationId);
        }

        /// <summary>
        ///  获取菜品优列表
        /// </summary>
        public IList<CookbookPreferentialWorkerInfo> GetCookbookPreferentialWorkerList(string name, WorkerStaffEnum? workerStaffEnum, int? cookbookId, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            return StaticCookbookPreferentialWorkerDAL.SelectList(name, workerStaffEnum, cookbookId, organizationId, orderString, pageIndex, pageSize, out total);
        }

        #endregion

        #region 排餐业务访问类 CookbookSetInDateDAL
        protected static CookbookSetInDateDAL StaticCookbookSetInDateDAL = new CookbookSetInDateDAL();

        /// <summary>
        /// 添加排餐
        /// </summary>
        public void AddCookbookSetInDate(CookbookSetInDateInfo info)
        {
            StaticCookbookSetInDateDAL.Insert(info);
        }

        /// <summary>
        /// 移除排餐
        /// </summary>
        public void RemoveCookbookSetInDate(int id)
        {
            StaticCookbookSetInDateDAL.Delete(id);
        }

        /// <summary>
        /// 修改排餐
        /// </summary>
        public void ModifyCookbookSetInDate(CookbookSetInDateInfo info)
        {
            StaticCookbookSetInDateDAL.Update(info);
        }

        /// <summary>
        /// 获取排餐
        /// </summary>
        public CookbookSetInDateInfo GetCookbookSetInDate(int id)
        {
            return StaticCookbookSetInDateDAL.Select(id);
        }

        /// <summary>
        /// 获取排餐列表
        /// </summary>
        /// <param name="ce">用餐时段（早/中/晚）</param>
        /// <param name="chooseDate">排餐日期</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂ID</param>
        public IList<CookbookSetInDateInfo> GetCookbookSetInDateList(CookbookEnum? ce, DateTime? chooseDate, int? organizationId, int? cafeteriaId)
        {
            return StaticCookbookSetInDateDAL.SelectList(ce, chooseDate, organizationId, cafeteriaId);
        }

        /// <summary>
        /// 获取排餐列表
        /// </summary>
        /// <param name="ce">用餐时段（早/中/晚）</param>
        /// <param name="chooseDate">排餐日期</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂ID</param>
        public IList<CookbookSetInDateInfo> GetCookbookSetInDateList(CookbookEnum? ce, DateTime? chooseDate, int? organizationId, int? cafeteriaId, int pageIndex, int pageSize, out int total)
        {
            return StaticCookbookSetInDateDAL.SelectList(ce, chooseDate, organizationId, cafeteriaId, pageIndex, pageSize, out total);
        }

        #endregion

        #region 排餐详情业务访问类 CookbookSetInDateDetailDAL

        protected static CookbookSetInDateDetailDAL StaticCookbookSetInDateDetailDAL = new CookbookSetInDateDetailDAL();

        /// <summary>
        /// 添加排餐详情
        /// </summary>
        public void AddCookbookSetInDateDetail(CookbookSetInDateDetailInfo info)
        {
            StaticCookbookSetInDateDetailDAL.Insert(info);
        }

        /// <summary>
        /// 删除指定的排餐详情记录
        /// </summary>
        public void RemoveCookbookSetInDateDetail(int id)
        {
            StaticCookbookSetInDateDetailDAL.Delete(id);
        }

        /// <summary>
        /// 删除排餐的所有详情记录
        /// </summary>
        /// <param name="cookbookDateId">排餐ID</param>
        public void RemoveCookbookSetInDateDetailByCookbookDateId(int cookbookDateId)
        {
            StaticCookbookSetInDateDetailDAL.DeleteByCookbookDateId(cookbookDateId);
        }

        /// <summary>
        /// 修改排餐详情
        /// </summary>
        public void ModifyCookbookSetInDateDetail(CookbookSetInDateDetailInfo info)
        {
            StaticCookbookSetInDateDetailDAL.Update(info);
        }

        /// <summary>
        /// 获取排餐详情
        /// </summary>
        public CookbookSetInDateDetailInfo GetCookbookSetInDateDetail(int cookbookDateId)
        {
            return StaticCookbookSetInDateDetailDAL.Select(cookbookDateId);
        }

        /// <summary>
        /// 获取排餐的所有详情记录
        /// </summary>
        /// <param name="cookbookDateId">排餐ID</param>
        public IList<CookbookSetInDateDetailInfo> GetCookbookSetInDateDetailList(int cookbookDateId)
        {
            return StaticCookbookSetInDateDetailDAL.SelectList(cookbookDateId);
        }
        #endregion
    }
}
