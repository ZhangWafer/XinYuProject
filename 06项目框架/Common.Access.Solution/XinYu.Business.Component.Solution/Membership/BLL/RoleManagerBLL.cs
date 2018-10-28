using System.Collections.Generic;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.BLL
{
    public class RoleManagerBLL : MembershipBLLBase
    {

        public void AddRole(RoleInfo role)
        {
            Static_Role_DAL.Insert(role);

            Static_Cache_Manager.Remove(CONST_CACHE_KEY_ROLE);
        }

        public void RemoveRole(int roleID)
        {
            Static_Role_DAL.Delete(roleID);

            Static_Cache_Manager.Remove(CONST_CACHE_KEY_ROLE);
        }

        public void ModifyRole(RoleInfo role)
        {
            Static_Role_DAL.Update(role);

            Static_Cache_Manager.Remove(CONST_CACHE_KEY_ROLE);
        }


        public IList<RoleInfo> GetRoleList()
        {
            return Static_Role_DAL.SelectList(string.Empty, string.Empty);
        }

        public IList<RoleInfo> GetRoleList(int pageIndex, int pageSize, out int total)
        {
            return Static_Role_DAL.SelectList(string.Empty, string.Empty, pageIndex, pageSize, out total);
        }

    }
}
