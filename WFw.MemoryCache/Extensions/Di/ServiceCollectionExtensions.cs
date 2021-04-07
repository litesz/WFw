using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
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
        ///// 添加icachememroy 缓存
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="setupAction"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddWFwMemoryCache(this IServiceCollection services, Action<WFwMemoryCacheOptions> setupAction)
        //{
        //    services.TryAddSingleton<ICache, WFwMemoryCache>();
        //    WFwMemoryCacheOptions options = new WFwMemoryCacheOptions();
        //    setupAction.Invoke(options);
        //    services.AddMemoryCache(opt =>
        //    {
        //        opt.SizeLimit = options.SizeLimit;
        //    });
        //    return services;
        //}

    }
}
