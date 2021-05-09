using System.Collections.Generic;
using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// string
    /// </summary>
    public partial interface IRedisCache : ICache
    {
        /// <summary>
        /// 设置给定 key 的值。如果 key 已经存储其他值， SET 就覆写旧值，且无视类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns> 在 Redis 2.6.12 以前版本， SET 命令总是返回 OK 。
        /// 从 Redis 2.6.12 版本开始， SET 在设置操作成功完成时，才返回 OK 。 </returns>
        bool Set<T>(string key, T value);

        /// <summary>
        /// 获取存储在指定 key 中字符串的子字符串。字符串的截取范围由 start 和 end 两个偏移量决定(包括 start 和 end 在内)。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>截取得到的子字符串。 </returns>
        T GetRange<T>(string key, long start, long end);

        /// <summary>
        /// 设置指定 key 的值，并返回 key 的旧值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns> 返回给定 key 的旧值。 当 key 没有旧值时，即 key 不存在时，返回 nil 。
        /// 当 key 存在但不是字符串类型时，返回一个错误。 </returns>
        T GetSet<T>(string key, T value);

        /// <summary>
        /// 返回所有(一个或多个)给定 key 的值。 如果给定的 key 里面，有某个 key 不存在，那么这个 key 返回特殊值 nil 。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns>一个包含所有给定 key 的值的列表。 </returns>
        T[] MGet<T>(params string[] keys);

        /// <summary>
        /// 为指定的 key 设置值及其过期时间。如果 key 已经存在， SETEX 命令将会替换旧的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="seconds"></param>
        /// <param name="value"></param>
        /// <returns>设置成功时返回 OK 。 </returns>
        bool SetEx<T>(string key, int seconds, T value);

        /// <summary>
        /// 在指定的 key 不存在时，为 key 设置指定的值。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>设置成功，返回 true 。 设置失败，返回 false 。 </returns>
        bool SetNx<T>(string key, T value);

        /// <summary>
        /// 以毫秒为单位设置 key 的生存时间。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="milliseconds"></param>
        /// <param name="value"></param>
        /// <returns>设置成功时返回 OK 。 </returns>
        bool PSetEx<T>(string key, int milliseconds, T value);
    }
}
