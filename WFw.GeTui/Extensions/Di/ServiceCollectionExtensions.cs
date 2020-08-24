
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.GeTui.Models.Options;
using WFw.GeTui.Services;
using WFw.GeTui.Stores;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public const string baseUrl = "https://restapi.getui.com/v2/";

        /// <summary>
        /// 添加个推APIV2接口
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGeTuiV2(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<PushOptions>(configurationSection);
            services.AddSingleton<GeTuiTokenStore>();
            services.AddHttpClient<IGeTuiService, GeTuiService>(c =>
            {
                 c.BaseAddress = new Uri(baseUrl);
             });

            return services;
        }


        /// <summary>
        /// 添加个推APIV2接口
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IServiceCollection AddGeTuiV2(this IServiceCollection services, Action<PushOptions> action)
        {
            services.Configure<PushOptions>(action);
            services.AddSingleton<GeTuiTokenStore>();
            services.AddHttpClient<IGeTuiService, GeTuiService>(c =>
            {
                c.BaseAddress = new Uri(baseUrl);
            });

            return services;
        }


    }
}
