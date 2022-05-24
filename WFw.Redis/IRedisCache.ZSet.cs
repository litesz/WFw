using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// sortedset
    /// </summary>
    partial interface IRedisCache : ICache
    {
        /// <summary>
        /// 将一个或多个成员元素及其分数值加入到有序集当中。
        /// 如果某个成员已经是有序集的成员，那么更新这个成员的分数值，并通过重新插入这个成员元素，来保证该成员在正确的位置上。
        /// 分数值可以是整数值或双精度浮点数。
        /// 如果有序集合 key 不存在，则创建一个空的有序集并执行 ZADD 操作。
        /// 当 key 存在但不是有序集类型时，返回一个错误。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="scoreMembers">一个或多个成员元素</param>
        /// <returns>被成功添加的新成员的数量，不包括那些被更新的、已经存在的成员</returns>
        long ZAdd(string key, params (decimal, object)[] scoreMembers);

        /// <summary>
        /// 计算集合中元素的数量
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <returns>当 key 存在且是有序集类型时，返回有序集的基数。 当 key 不存在时，返回 0 。 </returns>
        long ZCard(string key);

        /// <summary>
        /// 计算有序集合中指定分数区间的成员数量。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">最小值（包含）</param>
        /// <param name="max">最大值（包含）</param>
        /// <returns>分数值在 min 和 max 之间的成员的数量。</returns>
        long ZCount(string key, decimal min, decimal max);

        /// <summary>
        /// 对有序集合中指定成员的分数加上增量 increment
        /// 可以通过传递一个负数值 increment ，让分数减去相应的值，比如 ZINCRBY key -5 member ，就是让 member 的 score 值减去 5 。
        /// 当 key 不存在，或分数不是 key 的成员时， ZINCRBY key increment member 等同于 ZADD key increment member 。
        /// 当 key 不是有序集类型时，返回一个错误。
        /// 分数值可以是整数值或双精度浮点数。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="increment">增量</param>
        /// <param name="member">指定成员</param>
        /// <returns>member 成员的新分数值，以字符串形式表示。</returns>
        decimal ZIncrBy(string key, decimal increment, string member);

        /// <summary>
        /// 计算给定的一个或多个有序集的交集，其中给定 key 的数量必须以 numkeys 参数指定，并将该交集(结果集)储存到 destination 。
        /// 默认情况下，结果集中某个成员的分数值是所有给定集下该成员分数值之和。 
        /// </summary>
        /// <param name="destination"> 新的有序集合，不含prefix前辍</param>
        /// <param name="weights">使用 WEIGHTS 选项，你可以为 每个 给定有序集 分别 指定一个乘法因子。如果没有指定 WEIGHTS 选项，乘法因子默认设置为 1 。</param>
        /// <param name="aggregateType">Sum | Min | Max</param>
        /// <param name="keys"> 一个或多个有序集合，不含prefix前辍</param>
        /// <returns>保存到目标结果集的的成员数量。 </returns>
        long ZInterStore(string destination, decimal[] weights, RedisAggregateType aggregateType, params string[] keys);

        /// <summary>
        ///  当有序集合的所有成员都具有相同的分值时，有序集合的元素会根据成员的字典序来进行排序，这个命令可以返回给定的有序集合键 key 中，值介于 min 和 max 之间的成员。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <returns>指定区间内的成员数量。 </returns>
        long ZLexCount(string key, string min, string max);

        /// <summary>
        ///  Redis Zrange 返回有序集中，指定区间内的成员。
        ///  其中成员的位置按分数值递增(从小到大)来排序。
        ///  具有相同分数值的成员按字典序(lexicographical order)来排列。
        ///  如果你需要成员按值递减(从大到小)来排列，请使用 ZREVRANGE 命令。
        ///  下标参数 start 和 stop 都以 0 为底，也就是说，以 0 表示有序集第一个成员，以 1 表示有序集第二个成员，以此类推。
        ///  你也可以使用负数下标，以 -1 表示最后一个成员， -2 表示倒数第二个成员，以此类推。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start"> 开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop"> 结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>指定区间内的元素列表</returns>
        string[] ZRange(string key, long start, long stop);

        /// <summary>
        /// 当有序集合的所有成员都具有相同的分值时，有序集合的元素会根据成员的字典序来进行排序，这个命令可以返回给定的有序集合键 key 中，值介于 min 和 max
        /// 之间的成员。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> '(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="limit"> 返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内的元素列表</returns>
        string[] ZRangeByLex(string key, string min, string max, long? limit = null, long offset = 0L);

        /// <summary>
        /// 返回有序集合中指定分数区间的成员列表。有序集成员按分数值递增(从小到大)次序排列。
        /// 具有相同分数值的成员按字典序来排列(该属性是有序集提供的，不需要额外的计算)。
        /// 默认情况下，区间的取值使用闭区间(小于等于或大于等于)，你也可以通过给参数前增加(符号来使用可选的开区间 (小于或大于)。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit"> 返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内的元素列表</returns>
        string[] ZRangeByScore(string key, decimal min, decimal max, long? limit = null, long offset = 0L);

        /// <summary>
        ///  返回有序集中指定成员的排名。其中有序集成员按分数值递增(从小到大)顺序排列
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <returns>如果成员是有序集 key 的成员，返回 member 的排名。 如果成员不是有序集 key 的成员，返回 nil 。</returns>
        long? ZRank(string key, object member);

        /// <summary>
        /// 移除有序集中的一个或多个成员，不存在的成员将被忽略。
        /// 当 key 存在但不是有序集类型时，返回一个错误。
        /// 注意： 在 Redis 2.4 版本以前， ZREM 每次只能删除一个元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="members"> 一个或多个成员</param>
        /// <returns>被成功移除的成员的数量，不包括被忽略的成员。 </returns>
        long ZRem<T>(string key, params T[] members);

        /// <summary>
        /// 移除有序集合中给定的字典区间的所有成员。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> '(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <returns>被成功移除的成员的数量，不包括被忽略的成员。 </returns>
        long ZRemRangeByLex(string key, string min, string max);

        /// <summary>
        /// 于移除有序集中，指定排名(rank)区间内的所有成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>被移除成员的数量 </returns>
        long ZRemRangeByRank(string key, long start, long stop);

        /// <summary>
        /// 移除有序集中，指定分数（score）区间内的所有成员。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <returns>被移除成员的数量</returns>
        long ZRemRangeByScore(string key, decimal min, decimal max);

        /// <summary>
        /// 返回有序集中，指定区间内的成员。
        /// 其中成员的位置按分数值递减(从大到小)来排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order)排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGE 命令的其他方面和 ZRANGE 命令一样。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>指定区间内，的有序集成员的列表。 </returns>
        string[] ZRevRange(string key, long start, long stop);

        /// <summary>
        /// 返回有序集中，指定区间内的成员。
        /// 其中成员的位置按分数值递减(从大到小)来排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order)排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGE 命令的其他方面和 ZRANGE 命令一样。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        (string member, decimal score)[] ZRevRangeWithScores(string key, long start, long stop);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max"> 分数最大值 +inf (10 10</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        string[] ZRevRangeByScore(string key, string max, string min, long? limit = null, long? offset = 0L);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        string[] ZRevRangeByScore(string key, decimal max, decimal min, long? limit = null, long offset = 0L);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max"> 分数最大值 +inf (10 10</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        (string member, decimal score)[] ZRevRangeByScoreWithScores(string key, string max, string min, long? limit = null, long offset = 0L);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        (string member, decimal score)[] ZRevRangeByScoreWithScores(string key, decimal max, decimal min, long? limit = null, long offset = 0L);

        /// <summary>
        /// 返回有序集中成员的排名。其中有序集成员按分数值递减(从大到小)排序。
        /// 排名以 0 为底，也就是说， 分数值最大的成员排名为 0 。
        /// 使用 ZRANK 命令可以获得成员按分数值递增(从小到大)排列的排名。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <returns>如果成员是有序集 key 的成员，返回成员的排名。 如果成员不是有序集 key 的成员，返回 nil 。 </returns>
        long? ZRevRank(string key, object member);

        /// <summary>
        /// 返回有序集中，成员的分数值。 如果成员元素不是有序集 key 的成员，或 key 不存在，返回 nil 。 
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <returns>成员的分数值</returns>
        decimal? ZScore(string key, object member);

        /// <summary>
        /// 计算给定的一个或多个有序集的并集，其中给定 key 的数量必须以 numkeys 参数指定，并将该并集(结果集)储存到 destination 。
        /// 默认情况下，结果集中某个成员的分数值是所有给定集下该成员分数值之和 。
        /// </summary>
        /// <param name="destination"> 新的有序集合，不含prefix前辍</param>
        /// <param name="weights">使用 WEIGHTS 选项，你可以为 每个 给定有序集 分别 指定一个乘法因子。如果没有指定 WEIGHTS 选项，乘法因子默认设置为 1 。</param>
        /// <param name="aggregateType">Sum | Min | Max</param>
        /// <param name="keys"> 一个或多个有序集合，不含prefix前辍</param>
        /// <returns>保存到目标结果集的的成员数量。 </returns>
        long ZUnionStore(string destination, decimal[] weights, RedisAggregateType aggregateType, params string[] keys);

        /// <summary>
        /// 迭代有序集合中的元素（包括元素成员和元素分值）
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">游标</param>
        /// <param name="pattern">指定模式</param>
        /// <param name="count">数组长度</param>
        /// <returns>返回的每个元素都是一个有序集合元素，一个有序集合元素由一个成员（member）和一个分值（score）组成。 </returns>
        ScanResult<(string member, decimal score)> ZScan(string key, long cursor, string pattern = null, long? count = null);

    }
}
