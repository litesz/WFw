using System;
using System.Collections.Generic;

namespace WFw.Cache
{
    public static class MemoryCacheExtensions
    {
        public static Entity GetOrCreate<Entity>(this ICacheManager cacheManager, string cacheKey, Func<Entity> create, int cacheDurationInSeconds = int.MaxValue)
        {
            if (cacheManager.ContainsKey(cacheKey))
            {
                return cacheManager.Get<Entity>(cacheKey);
            }
            var result = create();
            cacheManager.Set(cacheKey, result, cacheDurationInSeconds);
            return result;
        }


        //public static Entity GetOrCreateHash<Entity>(ICacheManager cacheManager, 
        //    string cacheKey, 
        //    string field,
        //    Func<IEnumerable<Entity>> create, 
        //    int cacheDurationInSeconds = int.MaxValue)
        //{
        //    if (cacheManager.ContainsKey(cacheKey))
        //    {

        //    }


        //}
    }
}
