
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WFw.Mp;
using WFw.Mp.Options;

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

            services.AddScoped<WFwMpUrlBuilder>();

            services.AddHttpClient<WFwMpApiHttpClient, WFwMpApiHttpClient>();

            return services;
        }
    }
}
