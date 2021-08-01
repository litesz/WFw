using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WFw.Results;


namespace WFw.Middlewares
{
    /// <summary>
    /// 错误处理中间件
    /// </summary>
    public class WFwErrorHandlingMiddleware
    {
        readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public WFwErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ILogger<WFwErrorHandlingMiddleware> logger)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(context.Request.Headers[HttpHeaderConst.RequestId]))
                {
                    context.Request.Headers.Add(HttpHeaderConst.RequestId, context.TraceIdentifier);
                }
                if (!context.Response.HasStarted)
                {
                    context.Response.Headers.Add(HttpHeaderConst.RequestId, context.TraceIdentifier);
                }

                await _next(context);

                if (context.Response.StatusCode == 401)
                {
                    await WriteError(context, OperationResultType.Unauthorized, OperationResultType.Unauthorized.GetEnumDescription(), 401);
                }

            }
            catch (WFwException wf)
            {
                logger?.LogError(wf.ToLogMessage(context.TraceIdentifier));
                await WriteError(context, wf.OperationResult, wf.Message, wf.OperationResult == OperationResultType.Unauthorized ? 401 : 400);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToLogMessage(context.TraceIdentifier));
                await WriteError(context, OperationResultType.Unexpected, OperationResultType.Unexpected.GetEnumDescription(), 500);
            }



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        private Task WriteError(HttpContext context, OperationResultType type, string message, int statusCode = 400)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(new ErrApiResult(type, message).Serialize());
        }
    }
}
