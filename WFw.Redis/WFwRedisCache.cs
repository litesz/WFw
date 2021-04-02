using Microsoft.Extensions.Options;
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
        const string SlidingSecsField = "slidingSecs";

        /// <summary>
        /// 绝对值过期时间
        /// </summary>
        const string ValueField = "value";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public WFwRedisCache(IOptions<RedisOptions> options)
        {
            var csredis = new CSRedis.CSRedisClient(options.Value.Configuration);
            RedisHelper.Initialization(csredis);
        }

        /// <summary>
        /// 获得对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public (T output, bool IsOk) Get<T>(string key)
        {
            if (!RedisHelper.Exists(key))
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
            var sec = RedisHelper.HGet<int>(key, SlidingSecsField);
            if (sec > 0)
            {
                RedisHelper.Expire(key, sec);
            }

            return RedisHelper.HGet<T>(key, ValueField);
        }

        /// <summary>
        /// 删除键
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public long Remove(params string[] keys)
        {
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




    }
}
