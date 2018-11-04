using System.Collections.Generic;
using XinYu.Framework.Library.Factory;
using XinYu.Framework.Library.Interface;
using XinYu.Framework.Organization.DAL.SQLServer;
using XinYu.Framework.Organization.Model;

namespace XinYu.Framework.Organization.BLL
{
    /// <summary>
    /// 机构管理业务类
    /// </summary>
    public class OrganizationBLL
    {
        protected const string ConstCacheKeyOrganization = "__organization";

        protected static ICacheManager StaticCacheManager = CommonLibraryFactory.CreateInstance<ICacheManager>();

        protected static OrganizationDAL StaticOrganizationDAL = new OrganizationDAL();

        /// <summary>
        /// 添加机构
        /// </summary>
        public void AddOrganization(OrganizationInfo orgInfo)
        {
            StaticOrganizationDAL.Insert(orgInfo);
            StaticCacheManager.Remove(ConstCacheKeyOrganization);
        }

        /// <summary>
        /// 移除机构
        /// </summary>
        public void RemoveOrganization(int orgId)
        {
            StaticOrganizationDAL.Delete(orgId);
            StaticCacheManager.Remove(ConstCacheKeyOrganization);
        }

        /// <summary>
        /// 修改机构
        /// </summary>
        public void ModifyOrganization(OrganizationInfo orgInfo)
        {
            StaticOrganizationDAL.Update(orgInfo);
            StaticCacheManager.Remove(ConstCacheKeyOrganization);
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="name">机构名称</param>
        /// <param name="orderString">SQL排序</param>
        public IList<OrganizationInfo> GetOrganizationList(string name, string orderString)
        {
            var orgList = StaticCacheManager.GetData<IList<OrganizationInfo>>(ConstCacheKeyOrganization);
            if (orgList == null || orgList.Count == 0)
            {
                orgList = StaticOrganizationDAL.SelectList(name, orderString);

                StaticCacheManager.Add(ConstCacheKeyOrganization, orgList);  //添加缓存
            }

            return StaticOrganizationDAL.SelectList(name, orderString);
        }
    }
}
