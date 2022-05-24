
using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static CSRedis.RedisAggregate ToCSRedisAggregate(this RedisAggregateType type)
        {
            return type switch
            {
                RedisAggregateType.Max => CSRedis.RedisAggregate.Max,
                RedisAggregateType.Min => CSRedis.RedisAggregate.Min,
                RedisAggregateType.Sum => CSRedis.RedisAggregate.Sum,
                _ => CSRedis.RedisAggregate.Sum,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        internal static CSRedis.GeoUnit ToGeoUnit(this GeoUnit unit)
        {
            return unit switch
            {
                GeoUnit.km => CSRedis.GeoUnit.km,
                GeoUnit.ft => CSRedis.GeoUnit.ft,
                GeoUnit.mi => CSRedis.GeoUnit.mi,
                GeoUnit.m => CSRedis.GeoUnit.m,
                _ => CSRedis.GeoUnit.m
            };
        }

        internal static CSRedis.GeoOrderBy? ToGeoOrderBy(this GeoOrderBy? v)
        {
            if (v == null)
            {
                return null;
            }

            return v switch
            {
                GeoOrderBy.ASC => CSRedis.GeoOrderBy.ASC,
                GeoOrderBy.DESC => CSRedis.GeoOrderBy.DESC,
                _ => CSRedis.GeoOrderBy.ASC
            };
        }

        internal static KeyType ToKeyType(this CSRedis.KeyType keyType)
        {
            return keyType switch
            {
                CSRedis.KeyType.None => KeyType.None,
                CSRedis.KeyType.Hash => KeyType.Hash,
                CSRedis.KeyType.List => KeyType.List,
                CSRedis.KeyType.Stream => KeyType.Stream,
                CSRedis.KeyType.Set => KeyType.Set,
                CSRedis.KeyType.ZSet => KeyType.ZSet,
                CSRedis.KeyType.String => KeyType.String,
                _ => KeyType.None
            };
        }
    }
}
