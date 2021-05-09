using Microsoft.Extensions.Options;
using WFw.Cache;
using WFw.Redis.Options;
using System.Linq;
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
        /// <returns></returns>
        public string Get(string key) => RedisHelper.Get(key);

        /// <summary>
        /// 返回 key 中字符串值的子字符
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string GetRange(string key, long start, long end) => RedisHelper.GetRange(key, start, end);

        /// <summary>
        /// 将给定 key 的值设为 value ，并返回 key 的旧值(old value)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetSet(string key, string value) => RedisHelper.GetSet(key, value);

        /// <summary>
        /// 对 key 所储存的字符串值，获取指定偏移量上的位(bit)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool GetBit(string key, uint offset) => RedisHelper.GetBit(key, offset);


        /// <summary>
        /// 获取所有(一个或多个)给定 key 的值。 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string[] MGet(params string[] keys) => RedisHelper.MGet(keys);

        /// <summary>
        /// 对 key 所储存的字符串值，设置或清除指定偏移量上的位(bit)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetBit(string key, uint offset, bool value) => RedisHelper.SetBit(key, offset, value);

        /// <summary>
        /// 用 value 参数覆写给定 key 所储存的字符串值，从偏移量 offset 开始。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long SetRange(string key, uint offset, string value) => RedisHelper.SetRange(key, offset, value);

        /// <summary>
        /// 返回 key 所储存的字符串值的长度。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long StrLen(string key) => RedisHelper.StrLen(key);

        /// <summary>
        /// 同时设置一个或多个 key-value 对
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public bool MSet(params dynamic[] keyValues) => RedisHelper.MSet(keyValues);

        /// <summary>
        /// 同时设置一个或多个 key-value 对，当且仅当所有给定 key 都不存在。
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public bool MSetNx(params dynamic[] keyValues) => RedisHelper.MSetNx(keyValues);

        /// <summary>
        /// 将 key 中储存的数字值增一。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Incr(string key) => RedisHelper.IncrBy(key);

        /// <summary>
        /// 将 key 所储存的值加上给定的增量值（increment） 。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public long IncrBy(string key, long increment) => RedisHelper.IncrBy(key, increment);

        /// <summary>
        /// 将 key 所储存的值加上给定的浮点增量值（increment） 。 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public decimal IncrByFloat(string key, decimal increment) => RedisHelper.IncrByFloat(key, increment);

        /// <summary>
        /// 将 key 中储存的数字值减一。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Decr(string key) => RedisHelper.IncrBy(key, -1);

        /// <summary>
        /// key 所储存的值减去给定的减量值（decrement） 。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="decrement"></param>
        /// <returns></returns>
        public long DecrBy(string key, long decrement) => RedisHelper.IncrBy(key, -decrement);

        /// <summary>
        /// 如果 key 已经存在并且是一个字符串， APPEND 命令将指定的 value 追加到该 key 原来值（value）的末尾
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Append(string key, string value) => RedisHelper.Append(key, value);
    }
}
