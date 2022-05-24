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
        /// <param name="key"></param>
        /// <param name="values"></param>
        public long GeoAdd(string key, params (decimal longitude, decimal latitude, object member)[] values) => RedisHelper.GeoAdd(key, values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member1"></param>
        /// <param name="member2"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public decimal? GeoDist(string key, object member1, object member2, GeoUnit unit = GeoUnit.m) =>
            RedisHelper.GeoDist(key, member1, member2, unit.ToGeoUnit());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public (decimal longitude, decimal latitude)?[] GeoPos(string key, object[] members) => RedisHelper.GeoPos(key, members);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public string[] GeoRadius(string key, decimal longitude, decimal latitude, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
            => RedisHelper.GeoRadius(key, longitude, latitude, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (string member, decimal dist)[] GeoRadiusWithDist(string key, decimal longitude, decimal latitude, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
            => RedisHelper.GeoRadiusWithDist(key, longitude, latitude, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (string member, decimal dist, decimal longitude, decimal latitude)[] GeoRadiusWithDistAndCoord(string key, decimal longitude, decimal latitude, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
          => RedisHelper.GeoRadiusWithDistAndCoord(key, longitude, latitude, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public string[] GeoRadiusByMember(string key, object member, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
            => RedisHelper.GeoRadiusByMember(key, member, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (string member, decimal dist)[] GeoRadiusByMemberWithDist(string key, object member, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
          => RedisHelper.GeoRadiusByMemberWithDist(key, member, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="radius"></param>
        /// <param name="unit"></param>
        /// <param name="count"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public (string member, decimal dist, decimal longitude, decimal latitude)[] GeoRadiusByMemberWithDistAndCoord(string key, object member, decimal radius, GeoUnit unit = GeoUnit.m, long? count = null, GeoOrderBy? sorting = null)
          => RedisHelper.GeoRadiusByMemberWithDistAndCoord(key, member, radius, unit.ToGeoUnit(), count, sorting.ToGeoOrderBy());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public string[] GeoHash(string key, params object[] members) => RedisHelper.GeoHash(key, members);
    }
}
