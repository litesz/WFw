using CSRedis;
using WFw.Cache;

namespace WFw.Redis
{
    /// <summary>
    /// string
    /// </summary>
    public partial interface IRedisCache : ICache
    {
        /// <summary>
        /// 该命令用于在 key 存在时删除 key。
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        long Del(params string[] keys);

        /// <summary>
        /// 检查给定 key 是否存在。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// 序列化给定 key ，并返回被序列化的值。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] Dump(string key);

        /// <summary>
        /// 为给定 key 设置过期时间，以秒计
        /// </summary>
        /// <param name="key"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        bool Expire(string key, int seconds);

        /// <summary>
        /// EXPIREAT 的作用和 EXPIRE 类似，都用于为 key 设置过期时间。 不同在于 EXPIREAT 命令接受的时间参数是 UNIX 时间戳(unix timestamp)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        bool ExpireAt(string key, System.DateTime expire);

        /// <summary>
        /// 设置 key 的过期时间以毫秒计。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        bool PExpire(string key, int milliseconds);

        /// <summary>
        /// 设置 key 过期时间的时间戳(unix timestamp) 以毫秒计
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        bool PExpireAt(string key, System.DateTime expire);

        /// <summary>
        /// 查找所有符合给定模式( pattern)的 key 。 
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        string[] Keys(string pattern = "*");

        /// <summary>
        /// 将当前数据库的 key 移动到给定的数据库 db 当中。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="db"></param>
        bool Move(string key, int db);

        /// <summary>
        /// 移除 key 的过期时间，key 将持久保持。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Persist(string key);

        /// <summary>
        /// 以毫秒为单位返回 key 的剩余的过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long PTtl(string key);

        /// <summary>
        /// 以秒为单位，返回给定 key 的剩余生存时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long Ttl(string key);

        /// <summary>
        /// 从当前数据库中随机返回一个 key 
        /// </summary>
        /// <returns></returns>
        string RandomKey();

        /// <summary>
        /// 修改 key 的名称
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        /// <returns></returns>
        bool Rename(string key, string newKey);

        /// <summary>
        /// 仅当 newkey 不存在时，将 key 改名为 newkey
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        /// <returns></returns>
        bool RenameNx(string key, string newKey);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cursor"></param>
        /// <param name="pattern"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        RedisScan<T> Scan<T>(string key, long cursor, string pattern = null, long? count = null);
        /// <summary>
        /// 返回 key 所储存的值的类型。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        KeyType Type(string key);
    }
}
