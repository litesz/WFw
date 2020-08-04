
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.Http.Services;

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
        public static IServiceCollection AddSmsChinese(this IServiceCollection services)
        {
            services.AddHttpClient<ISmsService, SmsChineseService>(c =>
             {
                 c.BaseAddress = new Uri("http://utf8.api.smschinese.cn/");
                 c.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");
             });

            return services;
        }




    }
}
