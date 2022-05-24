using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public static class WFwRedisCacheGeoExtensions
    {
        /// <summary>
        /// 用于存储指定的地理空间位置
        /// </summary>
        /// <param name="cache">redis对象</param>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="member">位置名称</param>
        /// <returns></returns>
        public static bool GeoAdd(this IRedisCache cache, string key, decimal longitude, decimal latitude, object member)
        {
            return cache.GeoAdd(key, (longitude, latitude, member)) > 0;
        }
    }
}
