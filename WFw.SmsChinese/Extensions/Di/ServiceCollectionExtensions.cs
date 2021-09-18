
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Http.Services;
using WFw.ISms;
using WFw.SmsChinese.Options;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加smschinese短信平台
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSmsChineseClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmsChineseOptions>(configuration.GetSection(SmsChineseOptions.Position));

            services.AddHttpClient(SmsChineseOptions.Position, client =>
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");
            });

            services.TryAddSingleton<ISmsClient, SmsChineseApiClient>();
            return services;
        }

    }
}
