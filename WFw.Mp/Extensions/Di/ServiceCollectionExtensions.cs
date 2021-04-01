
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Mp;
using WFw.Mp.Options;
using WFw.Mp.Utils;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加公众号api
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwMp(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MpOptions>(configuration.GetSection(MpOptions.Position));

            services.TryAddScoped<WFwMpUrlBuilder>();

            services.AddHttpClient<IWFwMpApiHttpClient, WFwMpApiHttpClient>();

            return services;
        }
    }
}
