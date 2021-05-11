using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.Identity;
using WFw.Middlewares;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        ///// <summary>
        ///// 使用全局错误
        ///// </summary>
        ///// <param name="builder"></param>
        ///// <returns></returns>
        //public static IApplicationBuilder UseVerificationCode(this IApplicationBuilder builder)
        //{
        //    builder.UseMiddleware<VerificationCodeMiddleware>();
        //    return builder;
        //}

    }
}
