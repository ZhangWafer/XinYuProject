using System.Collections.Generic;
using XinYu.Framework.Library.Factory;
using XinYu.Framework.Library.Interface;
using XinYu.Framework.OrderMeal.DAL.SQLServer;
using XinYu.Framework.OrderMeal.Model;


namespace XinYu.Framework.OrderMeal.BLL
{
    public class OrderMealBLL
    {
        #region 警员订单访问类  PCStaffOrderMealDAL
        protected static PCStaffOrderMealDAL StaticOrdermealDAL = new PCStaffOrderMealDAL();

        /// <summary>
        /// 添加订单
        /// </summary>
        public void AddOrderMeal(PCStaffOrderMealInfo csInfo)
        {
            StaticOrdermealDAL.Insert(csInfo);
        }

        /// <summary>
        /// 移除订单
        /// </summary>
        public void RemoveOrderMeal(int csId)
        {
            StaticOrdermealDAL.Delete(csId);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        public void ModifyOrderMeal(PCStaffOrderMealInfo csInfo)
        {
            StaticOrdermealDAL.Update(csInfo);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public PCStaffOrderMealInfo GetOrderMeal(int csId)
        {
            return StaticOrdermealDAL.Select(csId);
        }

        /// <summary>
        /// 条件筛选订单
        /// </summary>
        public PCStaffOrderMealInfo GetConditionOrderMeal(int pcid, int orderid)
        {
            return StaticOrdermealDAL.SelectCondition(pcid, orderid);
        }


        #endregion

        #region 警员订单详细访问类 PCStaffOrderMealDetailDAL

        protected static PCStaffOrderMealDetailDAL StaticOrdermealDetailDAL = new PCStaffOrderMealDetailDAL();
        /// <summary>
        /// 添加订单
        /// </summary>
        public void AddOrderMealDetail(PCStaffOrderMealDetailInfo csInfo)
        {
            StaticOrdermealDetailDAL.Insert(csInfo);
        }

        /// <summary>
        /// 移除订单
        /// </summary>
        public void RemoveOrderMealDetail(int csId)
        {
            StaticOrdermealDetailDAL.Delete(csId);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        public void ModifyOrderMealDetail(PCStaffOrderMealDetailInfo csInfo)
        {
            StaticOrdermealDetailDAL.Update(csInfo);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public PCStaffOrderMealDetailInfo GetOrderMeal(int pcId)
        {
            return StaticOrdermealDetailDAL.Select(pcId);
        }

        #endregion


        #region 职工订单访问类  WorkerStaffOrderMealDAL
        protected static WorkerStaffOrderMealDAL StaticWorkerOrdermealDAL = new WorkerStaffOrderMealDAL();

        /// <summary>
        /// 添加订单
        /// </summary>
        public void AddWorkerOrderMeal(WorkerStaffOrderMealInfo csInfo)
        {
            StaticWorkerOrdermealDAL.Insert(csInfo);
        }

        /// <summary>
        /// 移除订单
        /// </summary>
        public void RemoveWorkerOrderMeal(int csId)
        {
            StaticWorkerOrdermealDAL.Delete(csId);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        public void ModifyWorkerOrderMeal(WorkerStaffOrderMealInfo csInfo)
        {
            StaticWorkerOrdermealDAL.Update(csInfo);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public WorkerStaffOrderMealInfo GetWorkerOrderMeal(int csId)
        {
            return StaticWorkerOrdermealDAL.Select(csId);
        }

        /// <summary>
        /// 条件筛选订单
        /// </summary>
        public WorkerStaffOrderMealInfo GetConditionWorkerOrderMeal(int workerid, int orderid)
        {
            return StaticWorkerOrdermealDAL.SelectCondition(workerid, orderid);
        }


        #endregion

        #region 职员订单详细访问类 PCStaffOrderMealDetailDAL

        protected static WorkerStaffOrderMealDetailDAL WorkerOrdermealDetailDAL = new WorkerStaffOrderMealDetailDAL();
        /// <summary>
        /// 添加订单
        /// </summary>
        public void AddOrderMealDetail(WorkerStaffOrderMealDetailInfo csInfo)
        {
            WorkerOrdermealDetailDAL.Insert(csInfo);
        }

        /// <summary>
        /// 移除订单
        /// </summary>
        public void RemoveOrderMealDetail(int csId)
        {
            WorkerOrdermealDetailDAL.Delete(csId);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        public void ModifyOrderMealDetail(WorkerStaffOrderMealDetailInfo csInfo)
        {
            WorkerOrdermealDetailDAL.Update(csInfo);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public WorkerStaffOrderMealDetailInfo GetOrderMeal(int pcId)
        {
            return WorkerOrdermealDetailDAL.Select(pcId);
        }

        #endregion

    }
}

