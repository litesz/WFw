using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using WFw.Data;
using WFw.Exceptions;
using WFw.Utils;
using WFw.Extensions.Utils;

namespace WFw.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestException bad)
            {
                var str = SerializeUtils.SerializeJson(new ApiResult(bad.OperationResult, bad.Message));
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(str);
            }
            catch (Exception ex)
            {
                var str = SerializeUtils.SerializeJson(new ApiResult(OperationResultType.Unexpected, ex.Message));
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(str);
            }

            if (context.Response.StatusCode == 401)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.StatusCode = 401;
                var str = SerializeUtils.SerializeJson(new ApiResult(OperationResultType.Unauthorized, OperationResultType.Unauthorized.GetEnumDescription()));
                await context.Response.WriteAsync(str);
            }

        }
    }
}
