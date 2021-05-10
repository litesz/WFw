using Microsoft.Extensions.Options;
using WFw.Cache;
using WFw.Redis.Options;
using System.Linq;
using CSRedis;

namespace WFw.Redis
{
    /// <summary>
    /// connection
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {
        /// <summary>
        /// 打印给定的字符串。
        /// </summary>
        /// <param name="msg">给定的字符串</param>
        public void Echo(string msg) => RedisHelper.Echo(msg);

        /// <summary>
        /// 命令使用客户端向 Redis 服务器发送一个 PING ，如果服务器运作正常的话，会返回一个 PONG 
        /// </summary>
        /// <returns>如果连接正常就返回一个 true ，否则返回一个连接错误</returns>
        public bool Ping() => RedisHelper.Ping();



    }
}
