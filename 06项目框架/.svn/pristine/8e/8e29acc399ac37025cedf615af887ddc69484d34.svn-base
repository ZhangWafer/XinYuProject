using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Cache.Cache
{
    /// <summary> 缓存服务提供者接口，定义了缓存服务的基本操作
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary> 根据key值获取相应的数据
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <returns>缓存值</returns>
        T Get<T>(string key);

        /// <summary> 根据key值获取相应的的数据，若缓存中无数据，则调用委托
        /// </summary>
        /// <typeparam name="T">缓存至的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="func">获取缓存值的委托</param>
        /// <returns>缓存值</returns>
        T Get<T>(string key, Func<T> func);

        /// <summary> 根据key值获取相应的的数据，若缓存中无数据，则调用委托
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="func">获取缓存值的委托</param>
        /// <param name="policy">缓存策略</param>
        /// <returns>缓存值</returns>
        T Get<T>(string key, Func<T> func, CacheItemPolicy policy);

        /// <summary> 插入数据到缓存
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        /// <returns>缓存值</returns>
        void Insert<T>(string key, T value);

        /// <summary> 插入数据到缓存，并设置过期策略
        /// </summary>
        /// <typeparam name="T">缓存值的类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        /// <param name="policy">缓存策略</param>
        void Insert<T>(string key, T value, CacheItemPolicy policy);

        /// <summary> 移除缓存中的某一项
        /// </summary>
        /// <param name="key">关键字</param>
        void Remove(string key);

        /// <summary> 清空缓存
        /// </summary>
        void Clear();
    }
}
