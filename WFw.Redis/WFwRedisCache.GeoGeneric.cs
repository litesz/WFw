using CSRedis;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public T[] GeoRadius<T>(string key, decimal longitude, decimal latitude, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
          => RedisHelper.GeoRadius<T>(key, longitude, latitude, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (T member, decimal dist)[] GeoRadiusWithDist<T>(string key, decimal longitude, decimal latitude, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
          => RedisHelper.GeoRadiusWithDist<T>(key, longitude, latitude, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (T member, decimal dist, decimal longitude, decimal latitude)[] GeoRadiusWithDistAndCoord<T>(string key, decimal longitude, decimal latitude, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
            => RedisHelper.GeoRadiusWithDistAndCoord<T>(key, longitude, latitude, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public T[] GeoRadiusByMember<T>(string key, object member, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
          => RedisHelper.GeoRadiusByMember<T>(key, member, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (T member, decimal dist)[] GeoRadiusByMemberWithDist<T>(string key, object member, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
        => RedisHelper.GeoRadiusByMemberWithDist<T>(key, member, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (T member, decimal dist, decimal longitude, decimal latitude)[] GeoRadiusByMemberWithDistAndCoord<T>(string key, object member, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
         => RedisHelper.GeoRadiusByMemberWithDistAndCoord<T>(key, member, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

    }
}
