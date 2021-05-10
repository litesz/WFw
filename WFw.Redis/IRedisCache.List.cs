using System.Collections.Generic;
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
        /// <param name="timeout">超时(秒)</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>如果列表为空，返回一个 nil 。 否则，返回被弹出元素的值。 </returns>
        string BLPop(int timeout, params string[] keys);

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
        /// <param name="timeout">超时(秒)</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>如果列表为空，返回一个 nil 。 否则，返回被弹出元素的值。 </returns>
        string BRPop(int timeout, params string[] keys);

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
        /// <param name="source">源列表Key,不含prefix前缀</param>
        /// <param name="destination">目标列表Key,不含prefix前缀</param>
        /// <param name="timeout">超时(秒)</param>
        /// <returns>假如在指定时间内没有任何元素被弹出，则返回一个 nil 和等待时长。 否则，返回被弹出元素的值。</returns>
        string BRPopLPush(string source, string destination, int timeout);


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
        /// <param name="key">不含prefix前缀</param>
        /// <param name="index">索引</param>
        /// <returns>列表中下标为指定索引值的元素。 如果指定索引值不在列表的区间范围内，返回 nil 。 </returns>
        string LIndex(string key, long index);


        /// <summary>
        /// 通过索引获取列表中的元素。你也可以使用负数下标，以 -1 表示列表的最后一个元素， -2 表示列表的倒数第二个元素，以此类推。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="index">索引</param>
        /// <returns>列表中下标为指定索引值的元素。 如果指定索引值不在列表的区间范围内，返回 nil 。 </returns>
        T LIndex<T>(string key, long index);


        /// <summary>
        /// 用于在列表的元素前或者后插入元素。当指定元素不存在于列表中时，不执行任何操作。
        /// 当列表不存在时，被视为空列表，不执行任何操作。
        /// 如果 key 不是列表类型，返回一个错误。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="pivot">列表元素</param>
        /// <param name="value">新元素</param>
        /// <returns>如果命令执行成功，返回插入操作完成之后，列表的长度。 如果没有找到指定元素 ，返回 -1 。 如果 key 不存在或为空列表，返回 0 。</returns>
        long LInsertBefore(string key, object pivot, object value);


        /// <summary>
        /// 用于在列表的元素前或者后插入元素。当指定元素不存在于列表中时，不执行任何操作。
        /// 当列表不存在时，被视为空列表，不执行任何操作。
        /// 如果 key 不是列表类型，返回一个错误。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="pivot">列表元素</param>
        /// <param name="value">新元素</param>
        /// <returns>如果命令执行成功，返回插入操作完成之后，列表的长度。 如果没有找到指定元素 ，返回 -1 。 如果 key 不存在或为空列表，返回 0 。</returns>
        long LInsertAfter(string key, object pivot, object value);

        /// <summary>
        /// 返回列表的长度。 如果列表 key 不存在，则 key 被解释为一个空列表，返回 0 。 如果 key 不是列表类型，返回一个错误
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>列表的长度。 </returns>
        long LLen(string key);

        /// <summary>
        /// 移除并返回列表的第一个元素。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>列表的第一个元素。 当列表 key 不存在时，返回 nil 。 </returns>
        string LPop(string key);

        /// <summary>
        /// 移除并返回列表的第一个元素。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>列表的第一个元素。 当列表 key 不存在时，返回 nil 。 </returns>
        T LPop<T>(string key);

        /// <summary>
        /// 命令将一个或多个值插入到列表头部。 如果 key 不存在，一个空列表会被创建并执行 LPUSH 操作。 当 key 存在但不是列表类型时，返回一个错误。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="values">一个或多个值</param>
        /// <returns>执行 LPUSH 命令后，列表的长度。 </returns>
        long LPush<T>(string key, params T[] values);

        /// <summary>
        ///  将一个值插入到已存在的列表头部，列表不存在时操作无效。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="value">值</param>
        /// <returns>LPUSHX 命令执行之后，列表的长度。 </returns>
        long LPushX<T>(string key, T value);

        /// <summary>
        /// 返回列表中指定区间内的元素，区间以偏移量 START 和 END 指定。 其中 0 表示列表的第一个元素， 1 表示列表的第二个元素，以此类推。 你也可以使用负数下标，以 -1 表示列表的最后一个元素， -2 表示列表的倒数第二个元素，以此类推。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="start">开始位置，0 表示列表的第一个元素，-1 表示列表的最后一个元素</param>
        /// <param name="stop">结束位置，0 表示列表的第一个元素，-1 表示列表的最后一个元素</param>
        /// <returns>一个列表，包含指定区间内的元素。</returns>
        string[] LRange(string key, long start, long stop);


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
        ///  Redis Lrem 根据参数 COUNT 的值，移除列表中与参数 VALUE 相等的元素。
        ///  COUNT 的值可以是以下几种：
        ///      count > 0 : 从表头开始向表尾搜索，移除与 VALUE 相等的元素，数量为 COUNT 。
        ///      count< 0 : 从表尾开始向表头搜索，移除与 VALUE 相等的元素，数量为 COUNT 的绝对值。
        ///      count = 0 : 移除表中所有与 VALUE 相等的值。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">count > 0 : 从表头开始向表尾搜索，移除与 VALUE 相等的元素，数量为 COUNT 。count< 0 : 从表尾开始向表头搜索，移除与 VALUE 相等的元素，数量为 COUNT 的绝对值。count = 0 : 移除表中所有与 VALUE 相等的值。</param>
        /// <param name="value">值</param>
        /// <returns>被移除元素的数量。 列表不存在时返回 0 。</returns>
        long LRem(string key, long count, object value);

        /// <summary>
        /// 通过索引来设置元素的值。
        /// 当索引参数超出范围，或对一个空列表进行 LSET 时，返回一个错误。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns>操作成功返回 ok ，否则返回错误信息。 </returns>
        bool LSet(string key, long index, object value);

        /// <summary>
        /// 对一个列表进行修剪(trim)，就是说，让列表只保留指定区间内的元素，不在指定区间之内的元素都将被删除。
        /// 下标 0 表示列表的第一个元素，以 1 表示列表的第二个元素，以此类推。 你也可以使用负数下标，以 -1 表示列表的最后一个元素， -2 表示列表的倒数第二个元素，以此类推。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>命令执行成功时，返回 ok 。 </returns>
        bool LTrim(string key, long start, long stop);

        /// <summary>
        /// 移除列表的最后一个元素，返回值为移除的元素。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <returns> 被移除的元素。
        /// 当列表不存在时，返回 nil</returns>
        string RPop(string key);

        /// <summary>
        /// 移除列表的最后一个元素，返回值为移除的元素。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// 当列表不存在时，返回 nil</returns>
        /// <returns> 被移除的元素。
        /// 当列表不存在时，返回 nil</returns>
        T RPop<T>(string key);


        /// <summary>
        /// 移除列表的最后一个元素，并将该元素添加到另一个列表并返回。 
        /// </summary>
        /// <param name="source">源列表Key,不含prefix前缀</param>
        /// <param name="destination">目标列表Key,不含prefix前缀</param>
        /// <returns>被弹出的元素。</returns>
        string RPopLPush(string source, string destination);


        /// <summary>
        /// 移除列表的最后一个元素，并将该元素添加到另一个列表并返回。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源列表Key,不含prefix前缀</param>
        /// <param name="destination">目标列表Key,不含prefix前缀</param>
        /// <returns>被弹出的元素。</returns>
        T RPopLPush<T>(string source, string destination);

        /// <summary>
        /// 命令将一个或多个值插入到列表尾部。 如果 key 不存在，一个空列表会被创建并执行 LPUSH 操作。 当 key 存在但不是列表类型时，返回一个错误。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="values">一个或多个值</param>
        /// <returns>执行 RPUSH 命令后，列表的长度。 </returns>
        long RPush<T>(string key, params T[] values);


        /// <summary>
        /// 将一个值插入到已存在的列表尾部，列表不存在时操作无效。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="value">值</param>
        /// <returns>RPUSHX 命令执行之后，列表的长度。 </returns>
        long RPushX<T>(string key, T value);
    }
}
