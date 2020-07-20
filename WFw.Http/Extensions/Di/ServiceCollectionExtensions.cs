
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.Http.Services;

namespace WFw.Extensions.Di
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSmsChinese(this IServiceCollection services)
        {
            services.AddHttpClient<SmsChineseService>(c =>
            {
                c.BaseAddress = new Uri("http://utf8.api.smschinese.cn/");
                c.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");
            });

            return services;
        }




    }
}
