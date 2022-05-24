using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// list
    /// </summary>
    public partial interface IRedisCache : ICache
    {
       
        /// <summary>
        /// 移出并获取列表的第一个元素， 如果列表没有元素会阻塞列表直到等待超时或发现可弹出元素为止。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="timeout">超时(秒)</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>如果列表为空，返回一个 nil 。 否则，返回被弹出元素的值。 </returns>
        T BLPop<T>(int timeout, params string[] keys);

        /// <summary>
        /// 移出并获取列表的最后一个元素， 如果列表没有元素会阻塞列表直到等待超时或发现可弹出元素为止。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="timeout">超时(秒)</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>如果列表为空，返回一个 nil 。 否则，返回被弹出元素的值。</returns>
        T BRPop<T>(int timeout, params string[] keys);

        /// <summary>
        /// 从列表中取出最后一个元素，并插入到另外一个列表的头部； 如果列表没有元素会阻塞列表直到等待超时或发现可弹出元素为止。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源列表Key,不含prefix前缀</param>
        /// <param name="destination">目标列表Key,不含prefix前缀</param>
        /// <param name="timeout">超时(秒)</param>
        /// <returns>假如在指定时间内没有任何元素被弹出，则返回一个 nil 和等待时长。 否则，返回被弹出元素的值。</returns>
        T BRPopLPush<T>(string source, string destination, int timeout);

        /// <summary>
        /// 通过索引获取列表中的元素。你也可以使用负数下标，以 -1 表示列表的最后一个元素， -2 表示列表的倒数第二个元素，以此类推。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="index">索引</param>
        /// <returns>列表中下标为指定索引值的元素。 如果指定索引值不在列表的区间范围内，返回 nil 。 </returns>
        T LIndex<T>(string key, long index);

        /// <summary>
        /// 移除并返回列表的第一个元素。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>列表的第一个元素。 当列表 key 不存在时，返回 nil 。 </returns>
        T LPop<T>(string key);

        /// <summary>
        /// 返回列表中指定区间内的元素，区间以偏移量 START 和 END 指定。 其中 0 表示列表的第一个元素， 1 表示列表的第二个元素，以此类推。 你也可以使用负数下标，以 -1 表示列表的最后一个元素， -2 表示列表的倒数第二个元素，以此类推
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="start">开始位置，0 表示列表的第一个元素，-1 表示列表的最后一个元素</param>
        /// <param name="stop">结束位置，0 表示列表的第一个元素，-1 表示列表的最后一个元素</param>
        /// <returns>一个列表，包含指定区间内的元素。</returns>
        T[] LRange<T>(string key, long start, long stop);

        /// <summary>
        /// 移除列表的最后一个元素，返回值为移除的元素。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <returns> 被移除的元素 当列表不存在时，返回 nil</returns>
        T RPop<T>(string key);

        /// <summary>
        /// 移除列表的最后一个元素，并将该元素添加到另一个列表并返回。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源列表Key,不含prefix前缀</param>
        /// <param name="destination">目标列表Key,不含prefix前缀</param>
        /// <returns>被弹出的元素。</returns>
        T RPopLPush<T>(string source, string destination);

    }
}
