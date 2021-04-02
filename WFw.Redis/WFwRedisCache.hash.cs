using WFw.Cache;

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
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool HSet<T>(string key, string field, T value, CacheItemOptions options)
        {

            RedisHelper.StartPipe(p => p.HMSet(key, SlidingSecsField, options.GetSlidingExpirationSecs(), field, value).Expire(key, options.GetAbsluteExpirationSecs()));

            return true;
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
            RedisHelper.StartPipe(p => p.HMSet(key, keyValues).HSet(key, SlidingSecsField, options.GetSlidingExpirationSecs()).Expire(key, options.GetAbsluteExpirationSecs()));
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public (T output, bool IsOk) HGet<T>(string key, string field)
        {
            if (!RedisHelper.HExists(key, field))
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
            var sec = RedisHelper.HGet<int>(key, SlidingSecsField);
            if (sec > 0)
            {
                RedisHelper.Expire(key, sec);
            }

            return RedisHelper.HGet<T>(key, field);
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
            var sec = RedisHelper.HGet<int>(key, SlidingSecsField);
            if (sec > 0)
            {
                RedisHelper.Expire(key, sec);
            }
            return RedisHelper.HMGet<T>(key, field);
        }

    }
}
