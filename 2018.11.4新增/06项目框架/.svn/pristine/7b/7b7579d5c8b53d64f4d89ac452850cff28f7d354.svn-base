using System;
using System.Collections.Generic;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.BLL
{
    public class AccountBLL : MembershipBLLBase
    {
        
        public UserInfo Login(string userName, string plaintPwd)
        {
            string hashedPwd = Static_Hash_Cryptorgrapher.CreateHash(plaintPwd);

            return Static_User_DAL.SelectByNamePwd(userName, hashedPwd);
        }

        public bool CheckPassword(UserInfo user, string plainPwd)
        {
            string hashedPwd = Static_Hash_Cryptorgrapher.CreateHash(plainPwd);

            return user.EncryptedPassword == hashedPwd;
        }

        public void ModifyPassword(UserInfo user, string plainOldPassword, string plainNewPassword)
        {
            var hashedOldPwd = Static_Hash_Cryptorgrapher.CreateHash(plainOldPassword);
            var hashedNewPwd = Static_Hash_Cryptorgrapher.CreateHash(plainNewPassword);

            Static_User_DAL.Update(user.UserName, hashedOldPwd, hashedNewPwd);

            user.EncryptedPassword = hashedNewPwd;
            user.LastPwdChangedDate = DateTime.Now;
        }


        /// <summary>
        /// 返回所有模块构成的树对象
        /// </summary>
        /// <returns></returns>
        public Tree<ModuleInfo> GetModulesTree()
        {
            var ret = Static_Cache_Manager.GetData<Tree<ModuleInfo>>(CONST_CACHE_KEY_MODULE);
            if (ret == null)
            {
                ret = initializeModuleTree(null);

                Static_Cache_Manager.Add(CONST_CACHE_KEY_MODULE, ret);
            }

            return ret;
        }

        /// <summary>
        /// 获取当前用户具有权限的那些模块列表，这些模块构成了一颗树的形式予以返回
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Tree<ModuleInfo> GetAccessableModules(UserInfo user)
        {
            Tree<ModuleInfo> moduleTree = GetModulesTree();

            // 系统管理员直接返回所有菜单项
            if (user.IsSystem) return moduleTree;

            IDictionary<int, Tree<ModuleInfo>> topAccessableModuleList = new Dictionary<int, Tree<ModuleInfo>>();

            CheckPopedomModules(user, moduleTree, topAccessableModuleList);

            return new Tree<ModuleInfo>(null, topAccessableModuleList);
        }


        /// <summary>
        /// 根据URL的特征，返回相应的模块对象
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <returns></returns>
        public ModuleInfo GetModule(Uri rawUrl)
        {
            // 取出最后的“\”或“/”符号的位置
            int lastSpetorIndex1 = rawUrl.AbsolutePath.LastIndexOf(@"/");
            int lastSpetorIndex2 = rawUrl.AbsolutePath.LastIndexOf(@"\");
            int lastSpetorIndex = (lastSpetorIndex1 > lastSpetorIndex2) ? lastSpetorIndex1 : lastSpetorIndex2;

            // 根据文件名，获取相关的模块对象数组
            string urlFileName = rawUrl.AbsolutePath.Substring(lastSpetorIndex + 1);
            IList<ModuleInfo> modules = Static_Module_DAL.SelectList(null, null, urlFileName, null, null, null);

            if (modules.Count == 0)  return null;

            //if (modules.Count == 1)
            //    return modules[0];

            // 检查当前模块的参数
            // 如果模块对象所要求的参数键与值，均包含在访问的URL中，则该次请求的对象即为该模块
            ModuleInfo ret = null;
            foreach (ModuleInfo m in modules)
            {
                // 过滤掉文件名不相等的模块（以防止某些文件后缀名等于当前文件名的情况出现）
                int prevCharIndex = m.Url.ToLower().IndexOf(urlFileName.ToLower()) - 1;
                if (prevCharIndex >= 0 && (m.Url[prevCharIndex] != '\\' && m.Url[prevCharIndex] != '/'))
                    continue;

                // 获取当前模块的URL的参数字符串
                int moduleURLQueryStartIndex = m.Url.IndexOf('?');
                string moduleURLQueryString = (moduleURLQueryStartIndex < 0) ? string.Empty : m.Url.Substring(moduleURLQueryStartIndex + 1).Trim();

                // 该模块对象URL没有指定参数，但为了保证获得最佳匹配的模块对象，将继续进行查找
                if (moduleURLQueryStartIndex < 0 || string.IsNullOrEmpty(moduleURLQueryString))
                {
                    ret = m;
                    continue;
                }

                // 检查参数
                bool isRequestThisModule = true;
                string[] moduleURLQueryList = moduleURLQueryString.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                string urlQueryString = rawUrl.Query.Replace("?", "&") + "&";
                foreach (string query in moduleURLQueryList)
                {
                    int equalIndex = query.IndexOf("=");
                    string queryKey = string.Empty;
                    string queryValue = string.Empty;
                    if (equalIndex >= 0)
                    {
                        queryKey = query.Substring(0, equalIndex);
                        queryValue = query.Substring(equalIndex + 1).Trim();
                    }


                    // 在原始的请求URL中未找到所要求的参数，表明当次请求的不是该模块
                    //if (rawUrl.Query.IndexOf("?" + query) < 0 && rawUrl.Query.IndexOf("&" + query) < 0)
                    //if (urlQueryString.IndexOf("&" + query + "&") < 0)
                    if (urlQueryString.IndexOf("&" + queryKey) < 0 ||
                       (!string.IsNullOrEmpty(queryValue) && urlQueryString.IndexOf("=" + queryValue + "&") < 0))
                    {
                        isRequestThisModule = false;
                        break;
                    }
                }

                if (isRequestThisModule)
                    return m;
            }

            return ret;
        }

        #region 权限控制管理Private方法

        /// <summary>
        /// 初始化所有模块构成的树
        /// </summary>
        /// <returns></returns>
        private Tree<ModuleInfo> initializeModuleTree(ModuleInfo parentModule)
        {
            int parentID = ModuleInfo.CONST_EMPTY_ID;
            if (parentModule != null)
                parentID = parentModule.ID;

            var subModuleList = new Dictionary<int, Tree<ModuleInfo>>();
            var subModules = Static_Module_DAL.SelectList(null, parentID, string.Empty, null, null, null);

            // 如果没有查询到子模块，直接返回一个无子树的树节点对象
            if (subModules.Count == 0) return new Tree<ModuleInfo>(parentModule, subModuleList);

            foreach (ModuleInfo m in subModules)
            {
                subModuleList.Add(m.ID, initializeModuleTree(m));
            }

            return new Tree<ModuleInfo>(parentModule, subModuleList);
        }

        private bool CheckPopedomModules(UserInfo user, Tree<ModuleInfo> checkingModuleTree, IDictionary<int, Tree<ModuleInfo>> accessableModuleList)
        {
            // 当前模块没有子模块，直接检查用户是否对它有访问权限
            if (checkingModuleTree.SubList.Count == 0)
            {
                IList<RoleInfo> allRoleList = GetCachingRoleList();

                return user.HasPopedom(checkingModuleTree.Item, allRoleList);
            }

            // 当前模块还有子模块，检查它的所有子模块的权限
            // 如果它的所有子模块都没有权限，则该模块也没有权限
            int accessableCount = 0;
            foreach (KeyValuePair<int, Tree<ModuleInfo>> subTreeKeyValuePair in checkingModuleTree.SubList)
            {
                // 检查子模块的权限
                IDictionary<int, Tree<ModuleInfo>> subAccessableModuleList = new Dictionary<int, Tree<ModuleInfo>>();
                if (CheckPopedomModules(user, subTreeKeyValuePair.Value, subAccessableModuleList))
                {
                    // 有权限，则将当前模块加入到返回子树中
                    accessableCount++;
                    accessableModuleList.Add(subTreeKeyValuePair.Key, new Tree<ModuleInfo>(subTreeKeyValuePair.Value.Item, subAccessableModuleList));
                }
                else
                {
                    // 如果没有权限，则什么也不做
                }
            }

            // 只要一个子模块有权限，就代表当前模块也有权限
            return accessableCount > 0;
        }

        #endregion

    }
}
