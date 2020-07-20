using Microsoft.AspNetCore.Builder;
using System;
using WFw.Middlewares;

namespace WFw.Extensions.Di
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
            return builder;
        }

        public static IApplicationBuilder UseWFwCurrentUser(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<WFwCurrentUserMiddleware>();
            return builder;
        }
    }
}
