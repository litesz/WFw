using CSRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static RedisAggregate ToCSRedisAggregate(this RedisAggregateType type)
        {
            switch (type)
            {
                case RedisAggregateType.Max: return RedisAggregate.Max;
                case RedisAggregateType.Min: return RedisAggregate.Min;
                default: return RedisAggregate.Sum;
            }

        }

    }
}
