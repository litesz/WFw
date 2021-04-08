
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WFw.ISms;
using WFw.TencentCloud;
using WFw.TencentCloud.Cos;
using WFw.TencentCloud.Options;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        private static bool isConfigureTencentCloudOptions = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddTencentCloudOptions(this IServiceCollection services, IConfiguration configuration)
        {
            if (!isConfigureTencentCloudOptions)
            {
                services.Configure<TencentCloudOptions>(configuration.GetSection(TencentCloudOptions.Position));
                isConfigureTencentCloudOptions = true;
            }

            return services;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwStsClient(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTencentCloudOptions(configuration)
                .AddSingleton<IWFwStsClient, WFwStsClient>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwCosClient(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTencentCloudOptions(configuration)
                .AddSingleton<IWFwCosClient, WFwCosClient>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwSmsClient(this IServiceCollection services, IConfiguration configuration)
        {
            return services
              .AddTencentCloudOptions(configuration)
              .AddSingleton<WFwSmsClient>()
              .AddSingleton<IWFwSmsClient>(op => op.GetRequiredService<WFwSmsClient>())
              .AddSingleton<ISmsClient>(op => op.GetRequiredService<WFwSmsClient>());
        }

    }
}
