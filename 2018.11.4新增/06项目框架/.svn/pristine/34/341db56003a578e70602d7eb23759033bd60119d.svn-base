using System.Collections.Generic;
using XinYu.Framework.DepositAndConsumption.DAL.SQLServer;
using XinYu.Framework.DepositAndConsumption.Model;

namespace XinYu.Framework.DepositAndConsumption.BLL
{
    public class DepositConsumptionBLL
    {
        protected static PCStaffDepositDAL StaticPCStaffDepositDAL = new PCStaffDepositDAL();

        public void AddDeposit(PCStaffDepositInfo pcInfo)
        {
            StaticPCStaffDepositDAL.Insert(pcInfo);
        }

        public void RemoveDeposit(int id)
        {
            StaticPCStaffDepositDAL.Delete(id);
        }

        public void ModifyDeposit(PCStaffDepositInfo pcInfo)
        {
            StaticPCStaffDepositDAL.Update(pcInfo);
        }

        public PCStaffDepositInfo GetCookbook(int id)
        {
            return StaticPCStaffDepositDAL.Select(id);
        }

        public IList<PCStaffDepositInfo> SelectList(int? pcStaffId, string orderString, int pageIndex, int pageSize, out int total)
        {
            return StaticPCStaffDepositDAL.SelectList(pcStaffId, orderString, pageIndex, pageSize, out total);
        }
    }
}
