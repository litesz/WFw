
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.ISms;
using WFw.TencentCloud.Clients.Cos;
using WFw.TencentCloud.Clients.Ocr;
using WFw.TencentCloud.Clients.Sms;
using WFw.TencentCloud.Clients.Sts;
using WFw.TencentCloud.Options;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        static bool isConfigureTencentCloudOptions = false;


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
        public static IServiceCollection AddTencentStsClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTencentCloudOptions(configuration);
            services.TryAddSingleton<IWFwStsClient, WFwStsClient>();
            return services;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddTencentCosClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTencentCloudOptions(configuration);
            services.TryAddSingleton<IWFwCosClient, WFwCosClient>();
            return services;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddTencentSmsClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTencentCloudOptions(configuration);
            services.TryAddSingleton<WFwSmsClient>();
            services.TryAddSingleton<IWFwSmsClient>(op => op.GetRequiredService<WFwSmsClient>());
            services.TryAddSingleton<ISmsClient>(op => op.GetRequiredService<WFwSmsClient>());

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddTencentOcrClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTencentCloudOptions(configuration);
            services.TryAddSingleton<IWFwOcrClient, WFwOcrClient>();
            return services;
        }
    }
}
