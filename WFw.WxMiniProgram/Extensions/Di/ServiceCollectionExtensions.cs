
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.WxMiniProgram;
using WFw.WxMiniProgram.Options;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加小程序api
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWxMiniProgram(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WxMinProgramOptions>(configuration.GetSection(WxMinProgramOptions.Position));
            services.AddHttpClient<IWxMiniProgramApiHttpClient, WxMiniProgramApiHttpClient>();

            return services;
        }




    }
}
