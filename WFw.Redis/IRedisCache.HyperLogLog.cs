using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// HyperLogLog
    /// </summary>
    public partial interface IRedisCache : ICache
    {

        /// <summary>
        /// 将所有元素参数添加到 HyperLogLog 数据结构中。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="elements">元素参数</param>
        /// <returns>如果至少有个元素被添加返回 1， 否则返回 0。 </returns>
        bool PfAdd<T>(string key, params T[] elements);

        /// <summary>
        /// 返回给定 HyperLogLog 的基数估算值。注意：分区模式下，若keys分散在多个分区节点时，将报错。
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>返回给定 HyperLogLog 的基数值，如果多个 HyperLogLog 则返回基数估值之和。</returns>
        long PfCount(params string[] keys);

        /// <summary>
        /// 将多个 HyperLogLog 合并为一个 HyperLogLog
        /// 注意：分区模式下，若keys分散在多个分区节点时，将报错
        /// </summary>
        /// <param name="destKey">新的 HyperLogLog，不含prefix前辍</param>
        /// <param name="sourceKeys">源 HyperLogLog，不含prefix前辍</param>
        /// <returns>返回true。</returns>
        bool PfMerge(string destKey, params string[] sourceKeys);

    }
}
