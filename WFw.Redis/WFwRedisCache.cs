using Microsoft.Extensions.Options;
using System.Linq;
using WFw.Cache;
using WFw.Redis.Options;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {

        /// <summary>
        /// 滑动过期时间
        /// </summary>
        private const string SlidingSecsField = "slidingSecs";

        /// <summary>
        /// 绝对值过期时间
        /// </summary>
        private const string ValueField = "value";
        /// <summary>
        /// 时间对象延迟时间(秒)
        /// </summary>
        private const int expireSettingKeyDelay = 5;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public WFwRedisCache(IOptions<RedisOptions> options)
        {
            var csredis = new CSRedis.CSRedisClient(options.Value.ToString());
            RedisHelper.Initialization(csredis);
        }

        /// <summary>
        /// 非string获得过期设置key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetExpireSettingKey(string key) => $"{key}:Expire";

        /// <summary>
        /// 延时string
        /// </summary>
        /// <param name="key"></param>
        private void ExpireKey(string key)
        {
            var sec = RedisHelper.HGet<int>(key, SlidingSecsField);
            if (sec > 0)
            {
                RedisHelper.Expire(key, sec);
            }
        }

        /// <summary>
        /// 删除键
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public long Remove(params string[] keys)
        {
            string[] expireKeys = keys.Select(u => GetExpireSettingKey(u)).ToArray();
            RedisHelper.Del(expireKeys);
            return RedisHelper.Del(keys);
        }


        /// <summary>
        /// 保存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, CacheItemOptions options)
        {
            RedisHelper.StartPipe(p => p.HMSet(key, SlidingSecsField, options.GetSlidingExpirationSecs(), ValueField, value).Expire(key, options.GetAbsluteExpirationSecs()));

            return true;
        }


        /// <summary>
        /// 获得对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public (T output, bool IsOk) Get<T>(string key)
        {
            if (!Exists(key))
            {
                return (default, false);
            }

            return (GetValue<T>(key), true);
        }

        /// <summary>
        /// 获得对象值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetValue<T>(string key)
        {
            ExpireKey(key);
            return RedisHelper.HGet<T>(key, ValueField);
        }


    }
}
