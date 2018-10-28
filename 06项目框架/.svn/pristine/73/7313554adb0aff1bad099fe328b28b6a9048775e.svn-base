using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Cache.Cache
{
    /// <summary> 内存缓存提供者
    /// </summary>
    public class InMemoryCacheProvider : ICacheProvider
    {
        #region 变量

        private readonly ObjectCache cache = MemoryCache.Default;

        #endregion

        #region ICacheProvider成员

        /// <summary> 根据key值获取相应的数据
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <returns>缓存值</returns>
        public T Get<T>(string key)
        {
            if (cache.Contains(key))
            {
                T value = (T)cache.Get(key);
                return value;
            }
            return default(T);
        }

        /// <summary> 根据key值获取相应的的数据，若缓存中无数据，则调用委托
        /// </summary>
        /// <typeparam name="T">缓存至的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="func">获取缓存值的委托</param>
        /// <returns>缓存值</returns>
        public T Get<T>(string key, Func<T> func)
        {
            T value = default(T);

            if (cache.Contains(key))
            {
                value = (T)cache.Get(key);
            }
            else if (null != func)
            {
                value = func();
                Insert(key, value);
            }
            return value;
        }

        /// <summary> 根据key值获取相应的的数据，若缓存中无数据，则调用委托
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="func">获取缓存值的委托</param>
        /// <param name="policy">缓存策略</param>
        /// <returns>缓存值</returns>
        public T Get<T>(string key, Func<T> func, CacheItemPolicy policy)
        {
            T value = default(T);

            if (cache.Contains(key))
            {
                value = (T)cache.Get(key);
            }
            else if (null != func)
            {
                value = func();
                Insert(key, value, policy);
            }
            return value;
        }

        /// <summary> 插入数据到缓存
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        /// <returns>缓存值</returns>
        public void Insert<T>(string key, T value)
        {
            if (cache.Contains(key))
            {
                cache[key] = value;
            }
            else
            {
                cache.Add(key, value, null);
            }
        }

        /// <summary> 插入数据到缓存，并设置过期策略
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        /// <param name="policy">缓存策略</param>
        public void Insert<T>(string key, T value, CacheItemPolicy policy)
        {
            if (cache.Contains(key))
            {
                cache[key] = value;
            }
            else
            {
                cache.Add(key, value, policy);
            }
        }

        /// <summary> 移除缓存中的某一项
        /// </summary>
        /// <param name="key">关键字</param>
        public void Remove(string key)
        {
            if (cache.Contains(key))
                cache.Remove(key);
        }

        /// <summary> 清空缓存
        /// </summary>
        public void Clear()
        {
            if (cache != null)
            {
                var items = cache.AsEnumerable();
                if (items != null)
                {
                    var cacheEnum = (IDictionaryEnumerator)items.GetEnumerator();
                    while (cacheEnum.MoveNext())
                    {
                        cache.Remove(cacheEnum.Key.ToString());
                    }
                }
            }
        }

        #endregion
    }
}
