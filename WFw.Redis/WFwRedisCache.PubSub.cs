using Microsoft.Extensions.Options;
using WFw.Cache;
using WFw.Redis.Options;
using System.Linq;
using CSRedis;
using System;

namespace WFw.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {
        //public long Publish(string channel, string message) => RedisHelper.Publish(channel, message);

        //public string[] PubSubChannels(string pattern) => RedisHelper.PubSubChannels(pattern);

        //public bool Subscribe(string key,Action<string> action)=>RedisHelper.Subscribe((key,args=>action(args.Body)))
    }
}
