using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using WFw.Cache;
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
            return services.TryAddService();
        }

        /// <summary>
        /// 添加redis
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwRedis(this IServiceCollection services, Action<RedisOptions> configureOptions)
        {
            services.Configure(configureOptions);

            return services.TryAddService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection TryAddService(this IServiceCollection services)
        {
            services.TryAddSingleton<IRedisCache, WFwRedisCache>();
            services.TryAddSingleton<ICache>(s =>
            {
                return s.GetRequiredService<IRedisCache>();
            });
            return services;
        }

    }
}
