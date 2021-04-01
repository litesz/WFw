using Microsoft.Extensions.Options;

namespace WFw.Redis.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisOptions : IOptions<RedisOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        public RedisOptions Value => this;

        /// <summary>
        /// 
        /// </summary>
        public const string Position = "Redis";

        /// <summary>
        /// 
        /// </summary>
        public string Configuration { get; set; } = "127.0.0.1:6379,defaultDatabase=0";
    }
}
