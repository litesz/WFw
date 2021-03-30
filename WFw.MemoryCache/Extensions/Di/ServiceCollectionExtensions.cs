using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.ICache;
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
            services.TryAddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddMemoryCache();
            return services;
        }

    }
}
