using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WFw.Identity
{
    /// <summary>
    /// 登录用户信息中间件
    /// </summary>
    public class WFwCurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public WFwCurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_currentIdentity"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ICurrentUser _currentIdentity)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                _currentIdentity.IsAuthenticated = true;

                foreach (var item in context.User.Claims)
                {
                    _currentIdentity.AddClaim(item.Type, item.Value);
                }
            }

            await _next(context);
        }
    }
}
