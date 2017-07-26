using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesing.Cache
{
    public class DataCacheProvider : ICacheProvider
    {
        private ObjectCache Cache { get { return MemoryCache.Default; } }
        ///
        /// Önbelleğe aldığımız veri okumak için gereken metod.
        ///
        ///Veri çekmek için kullanacağımız anahtar
        /// Önbelleğe alınmış veri

        public object Get(string key)
        {
            return Cache[key];
        }

        ///
        /// Önbelleğe veri yazmak için kullanacağımız metod
        ///
        ///Daha sonra önbellekten veriyi okumak kullanılacak anahtar.

        ///Önbelleğe yazılacak veri
        ///Dakika cinsinden bellekte veriyi ne kadar tutuyoruz

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        ///
        /// Belirtilen anahtarda önbelleğe alınmış veri var mı?
        ///
        ///Anahtar değerimiz
        ///

        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        ///
        /// Önbelleğe alınmış veriyi silmek için kullanılan metod.
        ///
        ///Anahtar değerimiz
        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }
    }
}
