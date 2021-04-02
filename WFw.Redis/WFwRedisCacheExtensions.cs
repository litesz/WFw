using System;
using System.Collections.Generic;
using System.Text;
using WFw.Cache;
using WFw.Redis;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public static class WFwRedisCacheExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static (string output, bool IsOk) HGet(this IRedisCache cache, string key, string field)
        {
            return cache.HGet<string>(key, field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string HGetValue(this IRedisCache cache, string key, string field)
        {
            return cache.HGetValue<string>(key, field);
        }

        /// <summary>
        /// 绝对过期设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static bool HSet<T>(this IRedisCache cache, string key, string field, T value, DateTimeOffset absoluteExpiration)
        {
            return cache.HSet(key, field, value, new CacheItemOptions
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
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpirationRelativeToNow"></param>
        /// <returns></returns>
        public static bool HSet<T>(this IRedisCache cache, string key, string field, T value, TimeSpan absoluteExpirationRelativeToNow)
        {
            return cache.HSet(key, field, value, new CacheItemOptions
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
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpirationSec"></param>
        /// <returns></returns>
        public static bool HSet<T>(this IRedisCache cache, string key, string field, T value, int slidingExpirationSec)
        {
            return cache.HSet(key, field, value, new CacheItemOptions
            {
                SlidingExpiration = new TimeSpan(0, 0, slidingExpirationSec)
            }); ;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static string[] HmGet(this IRedisCache cache, string key, params string[] fields)
        {
            return cache.HmGet<string>(key, fields);
        }


        //public static IList<T> GetOrCreateList<T>(this ICache cache, string key, Func<IList<T>> func, int? slidingExpirationSec = null)
        //{
        //    var (value, isOk) = cache.Get<T>(key);
        //    if (isOk)
        //    {
        //        return value;
        //    }
        //    var output = func();

        //    cache.Set(key, output, new CacheItemOptions
        //    {
        //        SlidingExpiration = slidingExpirationSec.HasValue ? new TimeSpan(0, 0, slidingExpirationSec.Value) : new TimeSpan(1, 0, 0)
        //    });
        //    return output;
        //}

    }
}
