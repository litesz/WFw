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
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        public bool Exists(string key) => RedisHelper.Exists(key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns></returns>
        public long Del(params string[] keys) => Remove(keys);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        public byte[] Dump(string key) => RedisHelper.Dump(key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="seconds">过期时间(秒)</param>
        /// <returns></returns>
        public bool Expire(string key, int seconds) => RedisHelper.Expire(key, seconds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="expire">过期时间</param>
        /// <returns></returns>
        public bool ExpireAt(string key, System.DateTime expire) => RedisHelper.ExpireAt(key, expire);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="milliseconds">过期时间(毫秒)</param>
        /// <returns></returns>
        public bool PExpire(string key, int milliseconds) => RedisHelper.PExpire(key, milliseconds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="expire">过期时间</param>
        /// <returns></returns>
        public bool PExpireAt(string key, System.DateTime expire) => RedisHelper.PExpireAt(key, expire);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern">给定模式</param>
        /// <returns></returns>
        public string[] Keys(string pattern = "*") => RedisHelper.Keys(pattern);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="db">数据库</param>
        public bool Move(string key, int db) => RedisHelper.Move(key, db);

        /// <summary>
        /// 移除 key 的过期时间，key 将持久保持。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        public bool Persist(string key) => RedisHelper.Persist(key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        public long PTtl(string key) => RedisHelper.PTtl(key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"><不含prefix前缀/param>
        /// <returns></returns>
        public long Ttl(string key) => RedisHelper.Ttl(key);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string RandomKey() => RedisHelper.RandomKey();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">旧key，不含prefix前缀</param>
        /// <param name="newKey">新key，不含prefix前缀</param>
        /// <returns></returns>
        public bool Rename(string key, string newKey) => RedisHelper.Rename(key, newKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">旧key，不含prefix前缀</param>
        /// <param name="newKey">新key，不含prefix前缀</param>
        /// <returns></returns>
        public bool RenameNx(string key, string newKey) => RedisHelper.RenameNx(key, newKey);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor"></param>
        /// <param name="pattern"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public RedisScan<T> Scan<T>(string key, long cursor, string pattern = null, long? count = null) => RedisHelper.Scan<T>(key, cursor, pattern, count);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        public KeyType Type(string key) => RedisHelper.Type(key);
    }
}
