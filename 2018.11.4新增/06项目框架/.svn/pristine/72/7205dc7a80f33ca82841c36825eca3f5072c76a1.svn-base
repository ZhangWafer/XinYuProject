// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库缓存管理接口
// Modify History: 
// ============================================================================

using System;
using System.Web.Caching;

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// Represents a cache manager.
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Returns the number of items currently in the cache.
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Returns true if key refers to item current stored in cache.
        /// </summary>
        /// <param name="key">Key of item to check for</param>
        /// <returns>True if item referenced by key is in the cache</returns>
        bool Contains(string key);

        /// <summary>
        /// Returns the item identified by the provided key.
        /// </summary>
        /// <param name="key">Key to retrieve from cache.</param>
        /// <exception cref="ArgumentNullException">Provided key is null.</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string.</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        object this[string key]
        {
            get;
        }

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">Key of item to return from cache.</param>
        /// <returns>Value stored in cache.</returns>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        object GetData(string key);

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <typeparam name="TItem">Type of return value.</typeparam>
        /// <param name="key">Key of item to return from cache.</param>
        /// <returns>Strong Type Value stored in cache.</returns>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        TItem GetData<TItem>(string key);

        /// <summary>
        /// Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added.
        /// Items added with this method will be not expire, and will have a Normal <see cref="CacheItemPriority" /> priority.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem.</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Add(string key, object value);

        /// <summary>
        /// Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added.
        /// Items added with this method will have a Normal <see cref="CacheItemPriority" /> priority.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem.</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="dependencies">The file or cache key dependencies for the item. May be null. See <see cref="CacheDependency" /> for more information. </param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Add(string key, object value, CacheDependency dependencies);

        /// <summary>
        /// Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added.
        /// Items added with this method will have a Normal <see cref="CacheItemPriority" /> priority.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem.</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="absoluteExpiration">The time at which the added object expires and is removed from the cache. If you are using 
        /// sliding expiration, the absoluteExpiration parameter must be <see cref="NoAbsoluteExpiration" />.</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Add(string key, object value, DateTime absoluteExpiration);

        /// <summary>
        /// Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added.
        /// Items added with this method will have a Normal <see cref="CacheItemPriority" /> priority.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem.</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="slidingExpiration">The interval between the time the added object was last accessed and the time at which that 
        /// object expires. If you are using absolute expiration, the slidingExpiration parameter must be <see cref="NoSlidingExpiration" /> .</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Add(string key, object value, TimeSpan slidingExpiration);

        /// <summary>
        /// Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem.</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="priority">Specifies the new item's scavenging priority. See <see cref="CacheItemPriority" /> for more information.</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Add(string key, object value, CacheItemPriority priority);
        
        /// <summary>
        /// Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem.</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="dependencies">The file or cache key dependencies for the item. May be null. See <see cref="CacheDependency" /> for more information. </param>
        /// <param name="absoluteExpiration">The time at which the added object expires and is removed from the cache. If you are using 
        /// sliding expiration, the absoluteExpiration parameter must be <see cref="NoAbsoluteExpiration" />.</param>
        /// <param name="slidingExpiration">The interval between the time the added object was last accessed and the time at which that 
        /// object expires. If you are using absolute expiration, the slidingExpiration parameter must be <see cref="NoSlidingExpiration" /> .</param>
        /// <param name="priority">Specifies the new item's scavenging priority. See <see cref="CacheItemPriority" /> for more information.</param>
        /// <param name="onRemoveCallback">A delegate that, if provided, is called when an object is removed from the cache.</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);

        /// <summary>
        /// Removes the given item from the cache. If no item exists with that key, this method does nothing.
        /// </summary>
        /// <param name="key">Key of item to remove from cache.</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Remove(string key);

        /// <summary>
        /// Removes all items from the cache. If an error occurs during the removal, the cache is left unchanged.
        /// </summary>
        /// <remarks>A Cache Manager Instance can use different storage mechanisms in which to store the cache items.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        void Flush();
    }
}
