using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Identity;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// 添加当前用户信息中间件
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwCurrentUser(this IServiceCollection services)
        {
            services.TryAddScoped<ICurrentUser, CurrentUser>();
            return services;
        }



    }
}
