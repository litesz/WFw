
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Cache;
using WFw.MemoryCache;

namespace WFw
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加icachememroy 缓存
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwMemoryCache(this IServiceCollection services)
        {
            services.TryAddSingleton<ICache, WFwMemoryCache>();
            services.AddMemoryCache();
            return services;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="configuration"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddWFwMemoryCache(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.Configure<CacheItemOptions>(configuration.GetSection("123"));
        //    services.TryAddSingleton<ICache, WFwMemoryCache>();
        //    services.AddMemoryCache();
        //    return services;
        //}


        ///// <summary>
        ///// 添加icachememroy 缓存
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="setupAction"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddWFwMemoryCache(this IServiceCollection services, Action<MemoryCacheOptions> setupAction)
        //{
        //    services.TryAddSingleton<ICache, MemoryCacheManager>();
        //    services.AddMemoryCache(setupAction);
        //    return services;
        //}

    }
}
