using System;
using System.Web.Caching;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.CacheManager
{
    /// <summary>
    /// Abstract cache manager.
    /// </summary>
    public abstract class AbstractCacheManager : ICacheManager
    {
        #region ICacheManager members.

        public abstract int Count
        {
            get;
        }

        public abstract bool Contains(string key);

        public object this[string key]
        {
            get { return this.GetData(key); }
        }

        public TItem GetData<TItem>(string key)
        {
            return (TItem)this.GetData(key);
        }

        public abstract object GetData(string key);

        public void Add(string key, object value)
        {
            this.Add(key, value, null);
        }

        public void Add(string key, object value, CacheDependency dependencies)
        {
            this.Add(key, value, dependencies, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Add(string key, object value, DateTime absoluteExpiration)
        {
            this.Add(key, value, null, absoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Add(string key, object value, TimeSpan slidingExpiration)
        {
            this.Add(key, value, null, Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Add(string key, object value, CacheItemPriority priority)
        {
            this.Add(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, priority, null);
        }

        public abstract void Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, 
            CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);

        public abstract void Remove(string key);

        public abstract void Flush();

        #endregion
    }
}
