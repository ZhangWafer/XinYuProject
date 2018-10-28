using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.BLL
{
    public class PopedomManagerBLL : MembershipBLLBase
    {


        public void ModifyUserPopedom(UserInfo user)
        {
            Static_User_DAL.Update(user);
        }


        public void ModifyRolePopedom(RoleInfo role)
        {
            Static_Role_DAL.Update(role);

            Static_Cache_Manager.Remove(CONST_CACHE_KEY_ROLE);
        }

    }
}
