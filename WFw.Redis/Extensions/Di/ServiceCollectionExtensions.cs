using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Redis;
using WFw.Redis.Options;

namespace WFw
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {


        /// <summary>
        /// 添加redis
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisOptions>(configuration.GetSection(RedisOptions.Position));
            services.TryAddSingleton<IRedisCache, WFwRedisCache>();
            return services;
        }

    }
}
