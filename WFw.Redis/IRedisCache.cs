using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRedisCache : ICache
    {

        /// <summary>
        /// HSET
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool HSet<T>(string key, string field, T value, CacheItemOptions options);

        /// <summary>
        /// hget
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        (T output, bool IsOk) HGet<T>(string key, string field);

        /// <summary>
        /// hget
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        T HGetValue<T>(string key, string field);


        /// <summary>
        /// hmset
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyValues"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool HmSet(string key, object[] keyValues, CacheItemOptions options);

        /// <summary>
        /// hmget
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        T[] HmGet<T>(string key, params string[] field);
    }
}
