using System.Collections.Generic;
using WFw.Cache;
using System.Linq;
using CSRedis;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {
        private void ExpireHash(string key)
        {
            var sec = RedisHelper.HGet<int>(GetExpireSettingKey(key), SlidingSecsField);
            if (sec > 0)
            {
                RedisHelper.StartPipe(p => p.Expire(key, sec).Expire(GetExpireSettingKey(key), sec + expireSettingKeyDelay));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public long HDel(string key, params string[] fields)
        {
            long r = RedisHelper.HDel(key, fields);

            if (!Exists(key))
            {
                RedisHelper.Del(GetExpireSettingKey(key));
            }

            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool HExists(string key, string field) => RedisHelper.HExists(key, field);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public (T output, bool IsOk) HGet<T>(string key, string field)
        {
            if (!HExists(key, field))
            {
                return (default, false);
            }

            return (HGetValue<T>(key, field), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public T HGetValue<T>(string key, string field)
        {
            ExpireHash(key);

            return RedisHelper.HGet<T>(key, field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dictionary<string, T> HGetAll<T>(string key)
        {
            ExpireHash(key);
            return RedisHelper.HGetAll<T>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public long HIncrBy(string key, string field, long increment = 1)
        {
            return RedisHelper.HIncrBy(key, field, increment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public decimal HIncrByFloat(string key, string field, decimal increment = 1)
        {
            return RedisHelper.HIncrByFloat(key, field, increment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] HKeys(string key)
        {
            return RedisHelper.HKeys(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long HLen(string key)
        {
            return RedisHelper.HLen(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public T[] HmGet<T>(string key, params string[] field)
        {
            ExpireHash(key);
            return RedisHelper.HMGet<T>(key, field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyValues"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool HmSet(string key, object[] keyValues, CacheItemOptions options)
        {
            RedisHelper.StartPipe(p =>
            p.HMSet(key, keyValues)
            .HSet(GetExpireSettingKey(key), SlidingSecsField, options.GetSlidingExpirationSecs())
            .Expire(key, options.GetAbsluteExpirationSecs())
            .Expire(GetExpireSettingKey(key), options.GetAbsluteExpirationSecs() + expireSettingKeyDelay));
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool HSet<T>(string key, string field, T value, CacheItemOptions options)
        {
            RedisHelper.StartPipe(p =>
            p.HSet(key, field, value)
            .HSet(GetExpireSettingKey(key), SlidingSecsField, options.GetSlidingExpirationSecs())
            .Expire(key, options.GetAbsluteExpirationSecs())
            .Expire(GetExpireSettingKey(key), options.GetAbsluteExpirationSecs() + expireSettingKeyDelay)
            );
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool HSetNx<T>(string key, string field, T value, CacheItemOptions options)
        {
            RedisHelper.StartPipe(p =>
            p.HSetNx(key, field, value)
            .HSet(GetExpireSettingKey(key), SlidingSecsField, options.GetSlidingExpirationSecs())
            .Expire(key, options.GetAbsluteExpirationSecs())
            .Expire(GetExpireSettingKey(key), options.GetAbsluteExpirationSecs() + expireSettingKeyDelay));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T[] HVals<T>(string key)
        {
            ExpireHash(key);
            return RedisHelper.HVals<T>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cursor"></param>
        /// <param name="pattern"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public RedisScan<(string, T)> HScan<T>(string key, long cursor, string pattern = null, long? count = null) => RedisHelper.HScan<T>(key, cursor, pattern, count);



    }
}
