using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Cache.Cache
{
    public abstract class CacheServiceBase
    {
        protected ICacheProvider provider = null;

        protected CacheServiceBase()
        {
            provider = CreateProvider();
        }

        /// <summary> 创建缓存提供者
        /// </summary>
        /// <returns></returns>
        protected abstract ICacheProvider CreateProvider();

        /// <summary> 根据关键字获取缓存
        /// </summary>
        /// <typeparam name="T">缓存对象的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <returns>缓存值</returns>
        public T Get<T>(string key)
        {
            return provider.Get<T>(key);
        }

        /// <summary> 插入数据到缓存
        /// </summary>
        /// <typeparam name="T">缓存对象的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        /// <returns>缓存值</returns>
        public void Set<T>(string key, T value)
        {
            provider.Insert<T>(key, value);
        }

        /// <summary> 插入数据到缓存，并设置过期策略
        /// </summary>
        /// <typeparam name="T">缓存对象的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="policy">缓存策略</param>
        public void Set<T>(string key, T value, CacheItemPolicy policy)
        {
            provider.Insert<T>(key, value, policy);
        }

        /// <summary> 移除缓存中的某一项
        /// </summary>
        /// <param name="key">关键字</param>
        public void Remove(string key)
        {
            provider.Remove(key);
        }

        /// <summary> 清空缓存
        /// </summary>
        public void Clear()
        {
            provider.Clear();
        }
    }
}
