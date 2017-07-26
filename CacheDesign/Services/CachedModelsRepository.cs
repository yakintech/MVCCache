using CacheDesign.Models;
using CacheDesing.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheDesign.Services
{
    public class CachedModelsRepository
    {
        protected NorthwindEntities db { get; private set; }
        public ICacheProvider Cache { get; set; }
        public CachedModelsRepository()
            :this(new DataCacheProvider())
        {

        }

        public CachedModelsRepository(ICacheProvider cacheProvider)
        {
            this.db = new NorthwindEntities(); 
            this.Cache = cacheProvider;
        }


        public List<Product> GetProducts()
        {
            List<Product> products = Cache.Get("Products") as List<Product>;

            if (products == null)
            {
                products = db.Products.ToList();

                if (products.Any())
                {
                    Cache.Set("Products", products, 30);
                }
            }

            return products;

        }

    }
}