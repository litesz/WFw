using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Cache;
using WFw.MemoryCache;

namespace WFw.Extensions.Di
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWFwMemoryCache(this IServiceCollection services)
        {
            services.TryAddSingleton<ICacheManager, MemoryCacheManager>();
            return services;
        }

    }
}
