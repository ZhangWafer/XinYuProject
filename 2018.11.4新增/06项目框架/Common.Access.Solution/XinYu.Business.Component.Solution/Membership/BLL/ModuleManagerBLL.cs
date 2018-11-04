using System.Collections.Generic;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.BLL
{
    public class ModuleManagerBLL : MembershipBLLBase
    {

        public void AddModule(ModuleInfo module)
        {
            Static_Module_DAL.Insert(module);

            Static_Cache_Manager.Remove(AccountBLL.CONST_CACHE_KEY_MODULE);
        }

        public void RemoveModule(int moduleID)
        {
            Static_Module_DAL.Delete(moduleID);

            Static_Cache_Manager.Remove(AccountBLL.CONST_CACHE_KEY_MODULE);
        }

        public void ModifyModule(ModuleInfo module)
        {
            Static_Module_DAL.Update(module);

            Static_Cache_Manager.Remove(AccountBLL.CONST_CACHE_KEY_MODULE);
        }

        public IList<ModuleInfo> GetModuleList(int parentID)
        {
            return Static_Module_DAL.SelectList(null, parentID, string.Empty, null, null, null);
        }
    }
}
