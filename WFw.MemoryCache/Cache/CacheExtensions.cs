using System;
using System.Threading.Tasks;

namespace WFw.Cache
{
    /// <summary>
    /// 缓存扩展
    /// </summary>
    public static class CacheExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static (string output, bool IsOk) Get(this ICache cache, string key)
        {
            return cache.Get<string>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ContainsKey(this ICache cache, string key)
        {
            var (_, isOk) = cache.Get(key);
            return isOk;
        }


        /// <summary>
        /// 绝对过期设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static bool Set<T>(this ICache cache, string key, T value, DateTimeOffset absoluteExpiration)
        {
            return cache.Set(key, value, new CacheItemOptions
            {
                AbsoluteExpiration = absoluteExpiration
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpirationRelativeToNow"></param>
        /// <returns></returns>
        public static bool Set<T>(this ICache cache, string key, T value, TimeSpan absoluteExpirationRelativeToNow)
        {
            return cache.Set(key, value, new CacheItemOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow
            });
        }

        /// <summary>
        /// 滑动过期设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpirationSec"></param>
        /// <returns></returns>
        public static bool Set<T>(this ICache cache, string key, T value, int slidingExpirationSec)
        {
            return cache.Set(key, value, new CacheItemOptions
            {
                SlidingExpiration = new TimeSpan(0, 0, slidingExpirationSec)
            }); ;
        }



        /// <summary>
        /// 获得或创建缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="slidingExpirationSec"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ICache cache, string key, Func<T> func, int? slidingExpirationSec = null)
        {
            var (value, isOk) = cache.Get<T>(key);
            if (isOk)
            {
                return value;
            }
            var output = func();

            cache.Set(key, output, new CacheItemOptions
            {
                SlidingExpiration = slidingExpirationSec.HasValue ? new TimeSpan(0, 0, slidingExpirationSec.Value) : new TimeSpan(1, 0, 0)
            });
            return output;
        }


       
    }
}
