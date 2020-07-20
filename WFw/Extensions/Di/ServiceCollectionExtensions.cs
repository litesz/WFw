using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WFw.Identity;

namespace WFw.Extensions.Di
{
    public static class ServiceCollectionExtensions
    {


        public static IServiceCollection AddWFwCurrentUser(this IServiceCollection services)
        {
            services.TryAddScoped<ICurrentUser, CurrentUser>();
            return services;
        }

     

    }
}
