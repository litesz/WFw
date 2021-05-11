using CSRedis;
using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// key
    /// </summary>
    public partial interface IRedisCache : ICache
    {
        /// <summary>
        /// 该命令用于在 key 存在时删除 key。
        /// </summary>
        /// <param name="keys">不含prefix前缀</param>
        /// <returns>被删除 key 的数量</returns>
        long Del(params string[] keys);

        /// <summary>
        /// 检查给定 key 是否存在。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>若 key 存在返回 true ，否则返回 false 。 </returns>
        bool Exists(string key);

        /// <summary>
        /// 序列化给定 key ，并返回被序列化的值。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>如果 key 不存在，那么返回 nil 。 否则，返回序列化之后的值。 </returns>
        byte[] Dump(string key);

        /// <summary>
        /// 为给定 key 设置过期时间，以秒计
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="seconds">过期时间（秒）</param>
        /// <returns>设置成功返回 true 。 当 key 不存在或者不能为 key 设置过期时间时(比如在低于 2.1.3 版本的 Redis 中你尝试更新 key 的过期时间)返回 false 。</returns>
        bool Expire(string key, int seconds);

        /// <summary>
        /// EXPIREAT 的作用和 EXPIRE 类似，都用于为 key 设置过期时间。 不同在于 EXPIREAT 命令接受的时间参数是 UNIX 时间戳(unix timestamp)。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="expire">过期时间</param>
        /// <returns>设置成功返回 true 。 当 key 不存在或者不能为 key 设置过期时间时(比如在低于 2.1.3 版本的 Redis 中你尝试更新 key 的过期时间)返回 false 。</returns>
        bool ExpireAt(string key, System.DateTime expire);

        /// <summary>
        /// 设置 key 的过期时间以毫秒计。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="milliseconds">过期时间（毫秒）</param>
        /// <returns>设置成功返回 true 。 当 key 不存在或者不能为 key 设置过期时间时(比如在低于 2.1.3 版本的 Redis 中你尝试更新 key 的过期时间)返回 false 。</returns>
        bool PExpire(string key, int milliseconds);

        /// <summary>
        /// 设置 key 过期时间的时间戳(unix timestamp) 以毫秒计
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="expire">过期时间</param>
        /// <returns>设置成功返回 true 。 当 key 不存在或者不能为 key 设置过期时间时(比如在低于 2.1.3 版本的 Redis 中你尝试更新 key 的过期时间)返回 false 。</returns>
        bool PExpireAt(string key, System.DateTime expire);

        /// <summary>
        /// 查找所有符合给定模式( pattern)的 key 。 
        /// </summary>
        /// <param name="pattern">给定模式</param>
        /// <returns>符合给定模式的 key 列表 (Array)。 </returns>
        string[] Keys(string pattern = "*");

        /// <summary>
        /// 将当前数据库的 key 移动到给定的数据库 db 当中。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="db">db库</param>
        /// <returns>移动成功返回 true ，失败则返回 false 。 </returns>
        bool Move(string key, int db);

        /// <summary>
        /// 移除 key 的过期时间，key 将持久保持。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>当过期时间移除成功时，返回 true 。 如果 key 不存在或 key 没有设置过期时间，返回 false 。 </returns>
        bool Persist(string key);

        /// <summary>
        /// 以毫秒为单位返回 key 的剩余的过期时间
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns> 当 key 不存在时，返回 -2 。 当 key 存在但没有设置剩余生存时间时，返回 -1 。 否则，以毫秒为单位，返回 key 的剩余生存时间。
        /// 注意：在 Redis 2.8 以前，当 key 不存在，或者 key 没有设置剩余生存时间时，命令都返回 -1 。</returns>
        long PTtl(string key);

        /// <summary>
        /// 以秒为单位，返回给定 key 的剩余生存时间
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns> 当 key 不存在时，返回 -2 。 当 key 存在但没有设置剩余生存时间时，返回 -1 。 否则，以毫秒为单位，返回 key 的剩余生存时间。
        /// 注意：在 Redis 2.8 以前，当 key 不存在，或者 key 没有设置剩余生存时间时，命令都返回 -1 。</returns>
        long Ttl(string key);

        /// <summary>
        /// 从当前数据库中随机返回一个 key 
        /// </summary>
        /// <returns>当数据库不为空时，返回一个 key 。 当数据库为空时，返回 nil （windows 系统返回 null）。 </returns>
        string RandomKey();

        /// <summary>
        /// 修改 key 的名称
        /// </summary>
        /// <param name="key">旧key，不含prefix前缀</param>
        /// <param name="newKey">新key，不含prefix前缀</param>
        /// <returns> 改名成功时提示 true ，失败时候返回一个错误。
        /// 当 OLD_KEY_NAME 和 NEW_KEY_NAME 相同，或者 OLD_KEY_NAME 不存在时，返回一个错误。 当 NEW_KEY_NAME 已经存在时， RENAME 命令将覆盖旧值。 </returns>
        bool Rename(string key, string newKey);

        /// <summary>
        /// 仅当 newkey 不存在时，将 key 改名为 newkey
        /// </summary>
        /// <param name="key">旧key，不含prefix前缀</param>
        /// <param name="newKey">新key，不含prefix前缀</param>
        /// <returns>修改成功时，返回 true 。 如果 NEW_KEY_NAME 已经存在，返回 false 。 </returns>
        bool RenameNx(string key, string newKey);

        /// <summary>
        ///  Redis Scan 命令用于迭代数据库中的数据库键。
        ///  SCAN 命令是一个基于游标的迭代器，每次被调用之后， 都会向用户返回一个新的游标， 用户在下次迭代时需要使用这个新游标作为 SCAN 命令的游标参数， 以此来延续之前的迭代过程。
        ///  SCAN 返回一个包含两个元素的数组， 第一个元素是用于进行下一次迭代的新游标， 而第二个元素则是一个数组， 这个数组中包含了所有被迭代的元素。如果新游标返回 0 表示迭代已结束。
        ///  相关命令：
        ///  SSCAN 命令用于迭代集合键中的元素。
        ///  HSCAN 命令用于迭代哈希键中的键值对。
        ///  ZSCAN 命令用于迭代有序集合中的元素（包括元素成员和元素分值）。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">不含prefix前缀</param>
        /// <param name="cursor">指针</param>
        /// <param name="pattern">模式</param>
        /// <param name="count">数组长度</param>
        /// <returns>数组列表。</returns>
        RedisScan<T> Scan<T>(string key, long cursor, string pattern = null, long? count = null);

        /// <summary>
        /// 返回 key 所储存的值的类型。
        /// </summary>
        /// <param name="key">不含prefix前缀</param>
        /// <returns>
        ///  返回 key 的数据类型，数据类型有：
        ///  none(key不存在)
        ///  string (字符串)
        ///  list(列表)
        ///  set(集合)
        ///  zset(有序集)
        ///  hash(哈希表)
        /// </returns>
        KeyType Type(string key);
    }
}
