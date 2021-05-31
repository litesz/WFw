using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WFw.Exceptions;
using WFw.Results;


namespace WFw.Middlewares
{
    /// <summary>
    /// 错误处理中间件
    /// </summary>
    public class WFwErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

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
                await _next(context);
            }

            //catch (BadRequestException bad)
            //{
            //    logger?.LogError(bad.ToLogMessage(requestId));
            //    await WriteError(requestId, context, bad.OperationResult, bad.ParamName);
            //}
            catch (WFwException wf)
            {
                logger?.LogError(wf.ToLogMessage(context.TraceIdentifier));
                await WriteError(context, wf.OperationResult, wf.Message);
            }
            //catch (ArgumentNullException ae)
            //{
            //    logger?.LogError(ae.ToString());
            //    await WriteError(context, OperationResultType.IsEmpty, ae.ParamName);
            //}
            catch (Exception ex)
            {
                logger?.LogError(ex.ToLineLogMessage(context.TraceIdentifier));
                await WriteError(context, OperationResultType.Unexpected, OperationResultType.Unexpected.GetEnumDescription(), 500);
            }

            if (context.Response.StatusCode == 401)
            {
                await WriteError(context, OperationResultType.Unauthorized, OperationResultType.Unauthorized.GetEnumDescription(), 401);
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
            return context.Response.WriteAsync(new ErrApiResult(context.TraceIdentifier, type, message).Serialize());
        }
    }
}
