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
        /// 获取指定 key 的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 获取存储在指定 key 中字符串的子字符串。字符串的截取范围由 start 和 end 两个偏移量决定(包括 start 和 end 在内)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>截取得到的子字符串</returns>
        string GetRange(string key, long start, long end);

        /// <summary>
        /// 设置指定 key 的值，并返回 key 的旧值。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns> 返回给定 key 的旧值。 当 key 没有旧值时，即 key 不存在时，返回 nil 。
        /// 当 key 存在但不是字符串类型时，返回一个错误。 </returns>
        string GetSet(string key, string value);

        /// <summary>
        /// 对 key 所储存的字符串值，获取指定偏移量上的位(bit)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <returns> 字符串值指定偏移量上的位(bit)。
        /// 当偏移量 OFFSET 比字符串值的长度大，或者 key 不存在时，返回 0 。</returns>
        bool GetBit(string key, uint offset);

        /// <summary>
        /// 返回所有(一个或多个)给定 key 的值。 如果给定的 key 里面，有某个 key 不存在，那么这个 key 返回特殊值 nil
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>一个包含所有给定 key 的值的列表。</returns>
        string[] MGet(params string[] keys);

        /// <summary>
        /// 对 key 所储存的字符串值，设置或清除指定偏移量上的位(bit)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        /// <returns>指定偏移量原来储存的位。 </returns>
        bool SetBit(string key, uint offset, bool value);

        /// <summary>
        /// 用指定的字符串覆盖给定 key 所储存的字符串值，覆盖的位置从偏移量 offset 开始。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        /// <returns>被修改后的字符串长度。</returns>
        long SetRange(string key, uint offset, string value);

        /// <summary>
        /// 获取指定 key 所储存的字符串值的长度。当 key 储存的不是字符串值时，返回一个错误。 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>字符串值的长度。 当 key 不存在时，返回 0。 </returns>
        long StrLen(string key);

        /// <summary>
        /// 同时设置一个或多个 key-value 对。
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns>总是返回 true</returns>
        bool MSet(params dynamic[] keyValues);

        /// <summary>
        /// 所有给定 key 都不存在时，同时设置一个或多个 key-value 对。 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns>当所有 key 都成功设置，返回 true 。 如果所有给定 key 都设置失败(至少有一个 key 已经存在)，那么返回 false 。</returns>
        bool MSetNx(params dynamic[] keyValues);

        /// <summary>
        /// Redis Incr 命令将 key 中储存的数字值增一。
        /// 如果 key 不存在，那么 key 的值会先被初始化为 0 ，然后再执行 INCR 操作。
        /// 如果值包含错误的类型，或字符串类型的值不能表示为数字，那么返回一个错误。
        /// 本操作的值限制在 64 位(bit)有符号数字表示之内。 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>执行 INCR 命令之后 key 的值。</returns>
        long Incr(string key);

        /// <summary>
        /// Redis Incrby 命令将 key 中储存的数字加上指定的增量值。
        /// 如果 key 不存在，那么 key 的值会先被初始化为 0 ，然后再执行 INCRBY 命令。
        /// 如果值包含错误的类型，或字符串类型的值不能表示为数字，那么返回一个错误。
        /// 本操作的值限制在 64 位(bit)有符号数字表示之内。 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="increment"></param>
        /// <returns>加上指定的增量值之后， key 的值。</returns>
        long IncrBy(string key, long increment);

        /// <summary>
        /// Redis Incrbyfloat 命令为 key 中所储存的值加上指定的浮点数增量值。
        /// 如果 key 不存在，那么 INCRBYFLOAT 会先将 key 的值设为 0 ，再执行加法操作。 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="increment"></param>
        /// <returns>执行命令之后 key 的值。 </returns>
        decimal IncrByFloat(string key, decimal increment);

        /// <summary>
        /// Redis Decr 命令将 key 中储存的数字值减一。
        /// 如果 key 不存在，那么 key 的值会先被初始化为 0 ，然后再执行 DECR 操作。
        /// 如果值包含错误的类型，或字符串类型的值不能表示为数字，那么返回一个错误。
        /// 本操作的值限制在 64 位(bit)有符号数字表示之内。 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>执行命令之后 key 的值。 </returns>
        long Decr(string key);

        /// <summary>
        /// Redis Decrby 命令将 key 所储存的值减去指定的减量值。
        /// 如果 key 不存在，那么 key 的值会先被初始化为 0 ，然后再执行 DECRBY 操作。
        /// 如果值包含错误的类型，或字符串类型的值不能表示为数字，那么返回一个错误。
        /// 本操作的值限制在 64 位(bit)有符号数字表示之内。 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="decrement"></param>
        /// <returns>减去指定减量值之后， key 的值。</returns>
        long DecrBy(string key, long decrement);

        /// <summary>
        /// Redis Append 命令用于为指定的 key 追加值。
        /// 如果 key 已经存在并且是一个字符串， APPEND 命令将 value 追加到 key 原来的值的末尾。
        /// 如果 key 不存在， APPEND 就简单地将给定 key 设为 value ，就像执行 SET key value 一样。 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>追加指定值之后， key 中字符串的长度。 </returns>
        long Append(string key, string value);
    }
}
