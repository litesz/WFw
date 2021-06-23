
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WFw.Ys;
using WFw.Ys.Options;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// 添加萤石云
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddYsApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<YsOptions>(configuration.GetSection(YsOptions.Position));
            services.AddHttpClient<IYsApiClient, YsApiClient>();

            return services;
        }



    }
}
