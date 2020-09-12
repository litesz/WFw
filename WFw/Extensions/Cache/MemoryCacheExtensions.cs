using System;
using System.Threading.Tasks;

namespace WFw.ICache
{
    /// <summary>
    /// 缓存扩展
    /// </summary>
    public static class MemoryCacheExtensions
    {
        /// <summary>
        /// 获得或创建缓存
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="cacheKey"></param>
        /// <param name="create"></param>
        /// <param name="cacheDurationInSeconds"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 异步获得或创建缓存
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="cacheKey"></param>
        /// <param name="create"></param>
        /// <param name="cacheDurationInSeconds"></param>
        /// <returns></returns>
        public async static Task<Entity> GetOrCreateAsync<Entity>(this ICacheManager cacheManager, string cacheKey, Func<Task<Entity>> create, int cacheDurationInSeconds = int.MaxValue)
        {
            if (cacheManager.ContainsKey(cacheKey))
            {
                return cacheManager.Get<Entity>(cacheKey);
            }
            var result = await create();
            cacheManager.Set(cacheKey, result, cacheDurationInSeconds);
            return result;
        }
    }
}
