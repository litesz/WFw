using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WFw.Identity;

namespace WFw.Middlewares
{

    public class WFwCurrentUserMiddleware
    {
        private readonly RequestDelegate _next;
        public WFwCurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }


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
