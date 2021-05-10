using Microsoft.Extensions.Options;
using WFw.Cache;
using WFw.Redis.Options;
using System.Linq;
using CSRedis;

namespace WFw.Redis
{
    /// <summary>
    /// set
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {

        /// <summary>
        /// 将一个或多个成员元素加入到集合中，已经存在于集合的成员元素将被忽略。
        /// 假如集合 key 不存在，则创建一个只包含添加的元素作成员的集合。
        /// 当集合 key 不是集合类型时，返回一个错误。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="members">一个或多个成员</param>
        /// <returns>被添加到集合中的新元素的数量，不包括被忽略的元素。</returns>
        public long SAdd<T>(string key, params T[] members) => RedisHelper.SAdd<T>(key, members);

        /// <summary>
        /// 返回集合中元素的数量。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>集合的数量。 当集合 key 不存在时，返回 0 。</returns>
        public long Scard(string key) => RedisHelper.SCard(key);

        /// <summary>
        /// 返回第一个集合与其他集合之间的差异，也可以认为说第一个集合中独有的元素。不存在的集合 key 将视为空集。
        /// 差集的结果来自前面的 FIRST_KEY, 而不是后面的 OTHER_KEY1，也不是整个 FIRST_KEY OTHER_KEY1..OTHER_KEYN 的差集。
        /// </summary>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>包含差集成员的列表。</returns>
        public string[] SDiff(params string[] keys) => RedisHelper.SDiff(keys);

        /// <summary>
        /// 返回第一个集合与其他集合之间的差异，也可以认为说第一个集合中独有的元素。不存在的集合 key 将视为空集。
        /// 差集的结果来自前面的 FIRST_KEY, 而不是后面的 OTHER_KEY1，也不是整个 FIRST_KEY OTHER_KEY1..OTHER_KEYN 的差集。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>包含差集成员的列表。</returns>
        public T[] SDiff<T>(params string[] keys) => RedisHelper.SDiff<T>(keys);

        /// <summary>
        /// 将给定集合之间的差集存储在指定的集合中。如果指定的集合 key 已存在，则会被覆盖
        /// </summary>
        /// <param name="destination">指定的集合</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns></returns>
        public long SDiffStore(string destination, params string[] keys) => RedisHelper.SDiffStore(destination, keys);

        /// <summary>
        /// 返回给定所有给定集合的交集。 不存在的集合 key 被视为空集。 当给定集合当中有一个空集时，结果也为空集(根据集合运算定律)。 
        /// </summary>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>交集成员的列表</returns>
        public string[] SInter(params string[] keys) => RedisHelper.SInter(keys);

        /// <summary>
        /// 返回给定所有给定集合的交集。 不存在的集合 key 被视为空集。 当给定集合当中有一个空集时，结果也为空集(根据集合运算定律)。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>交集成员的列表</returns>
        public T[] SInter<T>(params string[] keys) => RedisHelper.SInter<T>(keys);


        /// <summary>
        /// 将给定集合之间的交集存储在指定的集合中。如果指定的集合已经存在，则将其覆盖。
        /// </summary>
        /// <param name="destination">指定的集合</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>返回存储交集的集合的元素数量</returns>
        public long SInterStore(string destination, params string[] keys) => RedisHelper.SInterStore(destination, keys);

        /// <summary>
        /// 判断成员元素是否是集合的成员。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="member">成员</param>
        /// <returns>如果成员元素是集合的成员，返回 1 。 如果成员元素不是集合的成员，或 key 不存在，返回 0</returns>
        public bool SIsMember<T>(string key, T member) => RedisHelper.SIsMember(key, member);

        /// <summary>
        /// 返回集合中的所有的成员。 不存在的集合 key 被视为空集合。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>集合中的所有成员。</returns>
        public string[] SMembers(string key) => RedisHelper.SMembers(key);

        /// <summary>
        /// 返回集合中的所有的成员。 不存在的集合 key 被视为空集合。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>集合中的所有成员。</returns>
        public T[] SMembers<T>(string key) => RedisHelper.SMembers<T>(key);

        /// <summary>
        /// 将指定成员 member 元素从 source 集合移动到 destination 集合。
        /// SMOVE 是原子性操作。
        /// 如果 source 集合不存在或不包含指定的 member 元素，则 SMOVE 命令不执行任何操作，仅返回 0 。否则， member 元素从 source 集合中被移除，并添加到 destination 集合中去。
        /// 当 destination 集合已经包含 member 元素时， SMOVE 命令只是简单地将 source 集合中的 member 元素删除。
        /// 当 source 或 destination 不是集合类型时，返回一个错误。
        /// </summary>
        /// <param name="source">不含prefix前缀</param>
        /// <param name="destination">不含prefix前缀</param>
        /// <param name="memeber">成员</param>
        /// <returns></returns>
        public bool SMove(string source, string destination, object memeber) => RedisHelper.SMove(source, destination, memeber);

        /// <summary>
        /// 用于移除集合中的指定 key 的一个随机元素，移除后会返回移除的元素。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>被移除的随机元素。 当集合不存在或是空集时，返回 nil </returns>
        public string SPop(string key) => RedisHelper.SPop(key);

        /// <summary>
        /// 用于移除集合中的指定 key 的一个随机元素，移除后会返回移除的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>被移除的随机元素。 当集合不存在或是空集时，返回 nil </returns>
        public T SPop<T>(string key) => RedisHelper.SPop<T>(key);

        /// <summary>
        /// 用于移除集合中的指定 key 的一个或多个随机元素，移除后会返回移除的元素。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">一个或多个随机元素</param>
        /// <returns>被移除的随机元素。 当集合不存在或是空集时，返回 nil </returns>
        public string[] SPop(string key, long count ) => RedisHelper.SPop(key, count);

        /// <summary>
        /// 用于移除集合中的指定 key 的一个或多个随机元素，移除后会返回移除的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">一个或多个随机元素</param>
        /// <returns>被移除的随机元素。 当集合不存在或是空集时，返回 nil </returns>
        public T[] SPop<T>(string key, long count ) => RedisHelper.SPop<T>(key, count);

        /// <summary>
        /// 返回集合中的一个随机元素。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>返回一个元素；如果集合为空，返回 nil 。</returns>
        public string SRandMember(string key) => RedisHelper.SRandMember(key);

        /// <summary>
        /// 返回集合中的一个随机元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>返回一个元素；如果集合为空，返回 nil 。</returns>
        public T SRandMember<T>(string key) => RedisHelper.SRandMember<T>(key);



        /// <summary>
        /// 返回集合中的一个或多个随机元素。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">一个或多个随机元素</param>
        /// <returns>那么返回一个数组；如果集合为空，返回空数组</returns>
        public string[] SRandMembers(string key, int count = 1) => RedisHelper.SRandMembers(key, count);

        /// <summary>
        /// 返回集合中的一个或多个随机元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">一个或多个随机元素</param>
        /// <returns>那么返回一个数组；如果集合为空，返回空数组</returns>
        public T[] SRandMembers<T>(string key, int count = 1) => RedisHelper.SRandMembers<T>(key, count);

        /// <summary>
        /// 于移除集合中的一个或多个成员元素，不存在的成员元素会被忽略。当 key 不是集合类型，返回一个错误。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="members">一个或多个成员</param>
        /// <returns></returns>
        public long SRem<T>(string key, params T[] members) => RedisHelper.SRem<T>(key, members);

        /// <summary>
        /// 返回给定集合的并集。不存在的集合 key 被视为空集
        /// </summary>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>并集成员的列表。 </returns>
        public string[] SUnion(params string[] keys) => RedisHelper.SUnion(keys);

        /// <summary>
        /// 返回给定集合的并集。不存在的集合 key 被视为空集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>并集成员的列表。 </returns>
        public T[] SUnion<T>(params string[] keys) => RedisHelper.SUnion<T>(keys);

        /// <summary>
        /// 将给定集合的并集存储在指定的集合 destination 中。如果 destination 已经存在，则将其覆盖。 
        /// </summary>
        /// <param name="destination">指定的集合</param>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>结果集中的元素数量</returns>
        public long SUnionStore(string destination, params string[] keys) => RedisHelper.SUnionStore(destination, keys);

        /// <summary>
        /// 用于迭代集合中键的元素，Sscan 继承自 Scan。 
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">游标</param>
        /// <param name="pattern">匹配的模式</param>
        /// <param name="count">指定从数据集里返回多少元素，默认值为 10</param>
        /// <returns></returns>
        public RedisScan<string> SScan(string key, long cursor, string pattern = null, long count = 10) => RedisHelper.SScan(key, cursor, pattern, count);

        /// <summary>
        /// 用于迭代集合中键的元素，Sscan 继承自 Scan。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">游标</param>
        /// <param name="pattern">匹配的模式</param>
        /// <param name="count">指定从数据集里返回多少元素，默认值为 10</param>
        /// <returns></returns>
        public RedisScan<T> SScan<T>(string key, long cursor, string pattern = null, long count = 10) => RedisHelper.SScan<T>(key, cursor, pattern, count);
    }
}
