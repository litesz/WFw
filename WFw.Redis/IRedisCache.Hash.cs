using System.Collections.Generic;
using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// hash
    /// </summary>
    public partial interface IRedisCache : ICache
    {
        /// <summary>
        /// 删除一个或多个哈希表字段
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="fields">一个或多个字段</param>
        /// <returns>被成功删除字段的数量，不包括被忽略的字段。 </returns>
        long HDel(string key, params string[] fields);

        /// <summary>
        /// 查看哈希表 key 中，指定的字段是否存在。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">一个或多个字段</param>
        /// <returns>如果哈希表含有给定字段，返回 1 。 如果哈希表不含有给定字段，或 key 不存在，返回 0 。 </returns>
        bool HExists(string key, string field);

        /// <summary>
        /// 获取存储在哈希表中指定字段的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">指定字段</param>
        /// <returns></returns>
        (T output, bool IsOk) HGet<T>(string key, string field);

        /// <summary>
        ///获取存储在哈希表中指定字段的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">指定字段</param>
        /// <returns>返回给定字段的值。如果给定的字段或 key 不存在时，返回 nil 。 </returns>
        T HGetValue<T>(string key, string field);

        /// <summary>
        /// 获取在哈希表中指定 key 的所有字段和值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        Dictionary<string, T> HGetAll<T>(string key);

        /// <summary>
        /// 为哈希表 key 中的指定字段的整数值加上增量 increment
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">指定字段</param>
        /// <param name="increment">增量</param>
        /// <returns></returns>
        long HIncrBy(string key, string field, long increment = 1);

        /// <summary>
        /// 为哈希表 key 中的指定字段的浮点数值加上增量 increment 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">指定字段</param>
        /// <param name="increment">增量</param>
        /// <returns>执行 HINCRBY 命令之后，哈希表中字段的值。 </returns>
        decimal HIncrByFloat(string key, string field, decimal increment = 1);

        /// <summary>
        /// 获取所有哈希表中的字段
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>哈希表中的字段</returns>
        string[] HKeys(string key);

        /// <summary>
        /// 获取哈希表中字段的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns>哈希表中字段的数量</returns>
        long HLen(string key);

        /// <summary>
        /// 将哈希表 key 中的字段 field 的值设为 value 。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">指定字段</param>
        /// <param name="value">值</param>
        /// <param name="options">过期设置</param>
        /// <returns></returns>
        bool HSet<T>(string key, string field, T value, CacheItemOptions options);

        /// <summary>
        /// 同时将多个 field-value (域-值)对设置到哈希表 key 中。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyValues"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool HmSet(string key, object[] keyValues, CacheItemOptions options);

        /// <summary>
        /// 获取所有给定字段的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">一个或多个指定字段</param>
        /// <returns></returns>
        T[] HmGet<T>(string key, params string[] field);

        /// <summary>
        /// 获取哈希表中所有值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns></returns>
        T[] HVals<T>(string key);

        /// <summary>
        /// 只有在字段 field 不存在时，设置哈希表字段的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="field">指定字段</param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool HSetNx<T>(string key, string field, T value, CacheItemOptions options);

        /// <summary>
        /// 迭代哈希表中的键值对。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">游标</param>
        /// <param name="pattern">指定模式</param>
        /// <param name="count">数组长度</param>
        /// <returns></returns>
        CSRedis.RedisScan<(string, T)> HScan<T>(string key, long cursor, string pattern = null, long? count = null);
    }
}
