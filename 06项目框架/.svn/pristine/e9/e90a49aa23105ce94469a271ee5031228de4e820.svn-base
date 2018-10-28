using System.Collections.Generic;
using XinYu.Framework.Cafeteria.DAL.SQLServer;
using XinYu.Framework.Cafeteria.Model;
using XinYu.Framework.Library.Factory;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Cafeteria.BLL
{
    /// <summary>
    /// 机构食堂业务访问类
    /// </summary>
    public class CafeteriBLL
    {
        protected const string ConstCacheKeyCafeteri = "__cafeteri";

        protected static ICacheManager StaticCacheManager = CommonLibraryFactory.CreateInstance<ICacheManager>();

        protected static CafeteriDAL StaticCafeteriDAL = new CafeteriDAL();

        /// <summary>
        /// 添加新的机构食堂
        /// </summary>
        public void AddCafeteri(CafeteriInfo cafeteriInfo)
        {
            StaticCafeteriDAL.Insert(cafeteriInfo);
            StaticCacheManager.Remove(ConstCacheKeyCafeteri);
        }

        /// <summary>
        /// 移除机构食堂
        /// </summary>
        public void RemoveCafeteri(int orgId)
        {
            StaticCafeteriDAL.Delete(orgId);
            StaticCacheManager.Remove(ConstCacheKeyCafeteri);
        }

        /// <summary>
        /// 修改机构食堂
        /// </summary>
        public void ModifyCafeteri(CafeteriInfo cafeteriInfo)
        {
            StaticCafeteriDAL.Update(cafeteriInfo);
            StaticCacheManager.Remove(ConstCacheKeyCafeteri);
        }

        /// <summary>
        /// 查询机构食堂
        /// </summary>
        /// <param name="name">食堂名称</param>
        /// <param name="orderString">排序sql语句</param>
        public IList<CafeteriInfo> GetCafeteriList(string name, string orderString)
        {
            var cafList = StaticCacheManager.GetData<IList<CafeteriInfo>>(ConstCacheKeyCafeteri);
            if (cafList == null || cafList.Count == 0)
            {
                cafList = StaticCafeteriDAL.SelectList(name, orderString);

                StaticCacheManager.Add(ConstCacheKeyCafeteri, cafList);  //添加缓存
            }

            return StaticCafeteriDAL.SelectList(name, orderString);
        }
    }
}
