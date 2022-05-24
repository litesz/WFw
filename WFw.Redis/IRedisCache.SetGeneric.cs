using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// set
    /// </summary>
    public partial interface IRedisCache : ICache
    {

        /// <summary>
        /// 返回第一个集合与其他集合之间的差异，也可以认为说第一个集合中独有的元素。不存在的集合 key 将视为空集。
        /// 差集的结果来自前面的 FIRST_KEY, 而不是后面的 OTHER_KEY1，也不是整个 FIRST_KEY OTHER_KEY1..OTHER_KEYN 的差集。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>包含差集成员的列表。</returns>
        T[] SDiff<T>(params string[] keys);

        /// <summary>
        /// 返回给定所有给定集合的交集。 不存在的集合 key 被视为空集。 当给定集合当中有一个空集时，结果也为空集(根据集合运算定律)。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>交集成员的列表</returns>
        T[] SInter<T>(params string[] keys);

        /// <summary>
        /// 返回集合中的所有的成员。 不存在的集合 key 被视为空集合。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>集合中的所有成员。</returns>
        T[] SMembers<T>(string key);

        /// <summary>
        /// 用于移除集合中的指定 key 的一个随机元素，移除后会返回移除的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>被移除的随机元素。 当集合不存在或是空集时，返回 nil </returns>
        T SPop<T>(string key);

        /// <summary>
        /// 用于移除集合中的指定 key 的一个或多个随机元素，移除后会返回移除的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">一个或多个随机元素</param>
        /// <returns>被移除的随机元素。 当集合不存在或是空集时，返回 nil </returns>
        T[] SPop<T>(string key, long count);

        /// <summary>
        /// 返回集合中的一个随机元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>返回一个元素；如果集合为空，返回 nil 。</returns>
        T SRandMember<T>(string key);

        /// <summary>
        /// 返回集合中的一个或多个随机元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="count">一个或多个随机元素</param>
        /// <returns>那么返回一个数组；如果集合为空，返回空数组</returns>
        T[] SRandMembers<T>(string key, int count = 1);

        /// <summary>
        /// 返回给定集合的并集。不存在的集合 key 被视为空集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>并集成员的列表。 </returns>
        T[] SUnion<T>(params string[] keys);

        /// <summary>
        /// 用于迭代集合中键的元素，Sscan 继承自 Scan。 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">游标</param>
        /// <param name="pattern">匹配的模式</param>
        /// <param name="count">指定从数据集里返回多少元素，默认值为 10</param>
        /// <returns></returns>
        ScanResult<T> SScan<T>(string key, long cursor, string pattern = null, long count = 10);
    }
}
