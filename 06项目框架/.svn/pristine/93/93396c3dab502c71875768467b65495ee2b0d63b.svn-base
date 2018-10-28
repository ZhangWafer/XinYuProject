using System;
using System.Web;
using System.Web.Caching;

namespace XinYu.Framework.Library.Implement.CacheManager
{
    /// <summary>
    /// Http runtime cache manager.
    /// </summary>
    public sealed class HttpRuntimeCacheManager : AbstractCacheManager
    {
        string keyPrefix = string.Empty;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HttpRuntimeCacheManager()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="keyPrefix"></param>
        public HttpRuntimeCacheManager(string keyPrefix)
        {
            this.keyPrefix = keyPrefix;
        }

        public override int Count
        {
            get { return HttpRuntime.Cache.Count; }
        }

        public override bool Contains(string key)
        {
            return HttpRuntime.Cache.Get(this.makeKey(key)) == null;
        }

        public override object GetData(string key)
        {
            return HttpRuntime.Cache.Get(this.makeKey(key));
        }

        public override void Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, 
            TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");
            if (absoluteExpiration != Cache.NoAbsoluteExpiration && slidingExpiration == Cache.NoSlidingExpiration)
                throw new ArgumentException(Properties.Resources.CacheHasAbsoluteAndSlidingExpirationAtSameTime, "absoluteExpiration & slidingExpiration");

            HttpRuntime.Cache.Insert(this.makeKey(key), value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        public override void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            HttpRuntime.Cache.Remove(this.makeKey(key));
        }

        public override void Flush()
        {
            // 从缓存中移除所有项
            HttpRuntime.Close();
        }

        private string makeKey(string key)
        {
            return this.keyPrefix + key;
        }
    }
}
