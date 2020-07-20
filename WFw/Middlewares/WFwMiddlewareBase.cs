using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WFw.Middlewares
{
    public abstract class WFwMiddlewareBase
    {
        private readonly RequestDelegate _next;

        protected WFwMiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        public virtual Task Invoke(HttpContext context)
        {
            return _next(context);
        }
    }

 
}
