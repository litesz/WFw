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
        /// 设置指定 key 的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value) => RedisHelper.Set(key, value);

        /// <summary>
        /// 返回 key 中字符串值的子字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public T GetRange<T>(string key, long start, long end) => RedisHelper.GetRange<T>(key, start, end);

        /// <summary>
        /// 将给定 key 的值设为 value ，并返回 key 的旧值(old value)。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public T GetSet<T>(string key, T value) => RedisHelper.GetSet<T>(key, value);

        /// <summary>
        ///  获取所有(一个或多个)给定 key 的值。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public T[] MGet<T>(params string[] keys) => RedisHelper.MGet<T>(keys);

        /// <summary>
        /// 将值 value 关联到 key ，并将 key 的过期时间设为 seconds (以秒为单位)。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="seconds"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetEx<T>(string key, int seconds, T value) => RedisHelper.Set(key, value, seconds);

        /// <summary>
        /// 只有在 key 不存在时设置 key 的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetNx<T>(string key, T value) => RedisHelper.SetNx(key, value);

        /// <summary>
        /// 以毫秒为单位设置 key 的生存时间。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="milliseconds"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool PSetEx<T>(string key, int milliseconds, T value)
        {
            //TODO:返回值
            RedisHelper.StartPipe(p => p.Set(key, value).PExpire(key, milliseconds));
            return true;
        }

    }
}
