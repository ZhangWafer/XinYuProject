using System.Collections.Generic;
using XinYu.Framework.Library.Factory;
using XinYu.Framework.Library.Interface;
using XinYu.Framework.Membership.DAL.SQLServer;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.BLL
{
    public class MembershipBLLBase
    {
        protected const string CONST_CACHE_KEY_MODULE = "__modules";
        protected const string CONST_CACHE_KEY_ROLE = "__roles";
        protected const string CONST_CACHE_KEY_FIVECLASSTHREESTAGE_SETTING = "__5class3stagesetting";

        protected static UserDAL Static_User_DAL = new UserDAL();
        protected static RoleDAL Static_Role_DAL = new RoleDAL();
        protected static ModuleDAL Static_Module_DAL = new ModuleDAL();

        protected static ICacheManager Static_Cache_Manager = CommonLibraryFactory.CreateInstance<ICacheManager>();
        protected static IHashCryptographer Static_Hash_Cryptorgrapher = CommonLibraryFactory.CreateInstance<IHashCryptographer>();

        //////////////////////////////////////////////////////////////////////////////

        protected MembershipBLLBase()
        {

        }


        #region Get User Methods.


        /// <summary>
        /// �����û�Code��ȡ�û�
        /// </summary>
        public UserInfo GetUser(int userID)
        {
            if (userID <= 0) return null;

            return Static_User_DAL.Select(userID);
        }


        /// <summary>
        /// �����û�Code��ȡ��̨�����û������ֻ����ͨ��Ա���򷵻�NUL��
        /// </summary>
        public UserInfo GetAdminUser(int userID)
        {
            if (userID <= 0) return null;

            var ret = Static_User_DAL.Select(userID);

            if (ret.IsAdmin)
                return ret;
            return null;
        }


        /// <summary>
        /// ��ȡ�û�
        /// </summary>
        public UserInfo GetUserByCode(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return null;

            return Static_User_DAL.SelectByName(userName);
        }


        /// <summary>
        /// ��ȡ��̨�����û������ֻ����ͨ��Ա���򷵻�NUL��
        /// </summary>
        public UserInfo GetAdminUserByCode(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return null;

            var ret = Static_User_DAL.SelectByName(userName);

            if (ret.IsAdmin)
                return ret;
            return null;
        }

        /// <summary>
        /// ��ȡ��̨�����û��б���������ͨ��Ա��
        /// </summary>
        public IList<UserInfo> GetAdminUserList()
        {
            return Static_User_DAL.SelectList(string.Empty, false, true, null, null);
        }

        #endregion

        #region Get Role Methods.

        /// <summary>
        /// �ӻ����л�ȡ��ɫ�ֵ�
        /// </summary>
        /// <returns></returns>
        public IList<RoleInfo> GetCachingRoleList()
        {
            IList<RoleInfo> roleList = Static_Cache_Manager.GetData<IList<RoleInfo>>(CONST_CACHE_KEY_ROLE);
            if (roleList == null)
            {
                roleList = Static_Role_DAL.SelectList(string.Empty, string.Empty);

                Static_Cache_Manager.Add(CONST_CACHE_KEY_ROLE, roleList);
            }

            return roleList;
        }

        public RoleInfo GetRole(int roleID)
        {
            if (roleID <= 0) return null;

            return Static_Role_DAL.Select(roleID);
        }

        #endregion

        #region Get Module Methods.

        public ModuleInfo GetModule(int moduleID)
        {
            if (moduleID <= 0) return null;

            return Static_Module_DAL.Select(moduleID);
        }

        #endregion

    }
}
