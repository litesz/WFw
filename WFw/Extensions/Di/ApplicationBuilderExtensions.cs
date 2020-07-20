using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.Middlewares;

namespace WFw.Extensions.Di
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 使用全局错误
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
            return builder;
        }

        /// <summary>
        /// 添加获得当前用户信息中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWFwCurrentUser(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<WFwCurrentUserMiddleware>();
            return builder;
        }

        /// <summary>
        /// 使用线程作用域初始化
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IApplicationBuilder Init(this IApplicationBuilder builder, Action<IServiceScope> action)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                action(scope);
            }

            return builder;
        }

    }
}
