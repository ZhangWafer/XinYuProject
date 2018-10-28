using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYu.Cache.Cache
{
    public class InMemoryCacheService : CacheServiceBase
    {
        private InMemoryCacheService()
        {
        }

        private static CacheServiceBase instance = new InMemoryCacheService();

        public static CacheServiceBase Instance
        {
            get { return instance; }
        }

        /// <summary> 创建缓存提供者
        /// </summary>
        /// <returns></returns>
        protected override ICacheProvider CreateProvider()
        {
            return new InMemoryCacheProvider();
        }
    }
}
