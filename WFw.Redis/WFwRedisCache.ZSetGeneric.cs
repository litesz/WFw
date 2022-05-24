namespace WFw.Redis
{

    /// <summary>
    /// sortedset
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {
        /// <summary>
        ///  Redis Zrange 返回有序集中，指定区间内的成员。
        ///  其中成员的位置按分数值递增(从小到大)来排序。
        ///  具有相同分数值的成员按字典序(lexicographical order)来排列。
        ///  如果你需要成员按值递减(从大到小)来排列，请使用 ZREVRANGE 命令。
        ///  下标参数 start 和 stop 都以 0 为底，也就是说，以 0 表示有序集第一个成员，以 1 表示有序集第二个成员，以此类推。
        ///  你也可以使用负数下标，以 -1 表示最后一个成员， -2 表示倒数第二个成员，以此类推。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start"> 开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop"> 结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>指定区间内的元素列表</returns>
        public T[] ZRange<T>(string key, long start, long stop) => RedisHelper.ZRange<T>(key, start, stop);

        /// <summary>
        /// 当有序集合的所有成员都具有相同的分值时，有序集合的元素会根据成员的字典序来进行排序，这个命令可以返回给定的有序集合键 key 中，值介于 min 和 max
        /// 之间的成员。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> '(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="limit"> 返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内的元素列表</returns>
        public T[] ZRangeByLex<T>(string key, string min, string max, long? limit = null, long offset = 0L) => RedisHelper.ZRangeByLex<T>(key, min, max, limit, offset);

        /// <summary>
        /// 返回有序集合中指定分数区间的成员列表。有序集成员按分数值递增(从小到大)次序排列。
        /// 具有相同分数值的成员按字典序来排列(该属性是有序集提供的，不需要额外的计算)。
        /// 默认情况下，区间的取值使用闭区间(小于等于或大于等于)，你也可以通过给参数前增加(符号来使用可选的开区间 (小于或大于)。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit"> 返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内的元素列表</returns>
        public T[] ZRangeByScore<T>(string key, decimal min, decimal max, long? limit = null, long offset = 0L) => RedisHelper.ZRangeByScore<T>(key, min, max, limit, offset);

        /// <summary>
        /// 返回有序集中，指定区间内的成员。
        /// 其中成员的位置按分数值递减(从大到小)来排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order)排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGE 命令的其他方面和 ZRANGE 命令一样。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>指定区间内，的有序集成员的列表。 </returns>
        public T[] ZRevRange<T>(string key, long start, long stop) => RedisHelper.ZRevRange<T>(key, start, stop);

        /// <summary>
        /// 返回有序集中，指定区间内的成员。
        /// 其中成员的位置按分数值递减(从大到小)来排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order)排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGE 命令的其他方面和 ZRANGE 命令一样。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        public (T member, decimal score)[] ZRevRangeWithScores<T>(string key, long start, long stop) => RedisHelper.ZRevRangeWithScores<T>(key, start, stop);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max"> 分数最大值 +inf (10 10</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        public T[] ZRevRangeByScore<T>(string key, string max, string min, long? limit = null, long offset = 0L) => RedisHelper.ZRevRangeByScore<T>(key, max, min, limit, offset);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        public T[] ZRevRangeByScore<T>(string key, decimal max, decimal min, long? limit = null, long offset = 0L) => RedisHelper.ZRevRangeByScore<T>(key, max, min, limit, offset);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max"> 分数最大值 +inf (10 10</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        public (T member, decimal score)[] ZRevRangeByScoreWithScores<T>(string key, string max, string min, long? limit = null, long offset = 0L) => RedisHelper.ZRevRangeByScoreWithScores<T>(key, max, min, limit, offset);

        /// <summary>
        /// 返回有序集中指定分数区间内的所有的成员。有序集成员按分数值递减(从大到小)的次序排列。
        /// 具有相同分数值的成员按字典序的逆序(reverse lexicographical order )排列。
        /// 除了成员按分数值递减的次序排列这一点外， ZREVRANGEBYSCORE 命令的其他方面和 ZRANGEBYSCORE 命令一样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min"> 分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns>指定区间内，带有分数值(可选)的有序集成员的列表。 </returns>
        public (T member, decimal score)[] ZRevRangeByScoreWithScores<T>(string key, decimal max, decimal min, long? limit = null, long offset = 0L) => RedisHelper.ZRevRangeByScoreWithScores<T>(key, max, min, limit, offset);

        /// <summary>
        /// 迭代有序集合中的元素（包括元素成员和元素分值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">游标</param>
        /// <param name="pattern">指定模式</param>
        /// <param name="count">数组长度</param>
        /// <returns>返回的每个元素都是一个有序集合元素，一个有序集合元素由一个成员（member）和一个分值（score）组成。 </returns>
        public ScanResult<(T member, decimal score)> ZScan<T>(string key, long cursor, string pattern = null, long? count = null) => new ScanResult<(T member, decimal score)>(RedisHelper.ZScan<T>(key, cursor, pattern, count));
    }
}
