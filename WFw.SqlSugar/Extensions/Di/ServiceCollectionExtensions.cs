using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.DbContext;

namespace WFw
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<DbOptions>(configurationSection);

            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));

            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));

            return services;
        }


        public static IServiceCollection AddSqlSugar(this IServiceCollection services, Action<DbOptions> action)
        {
            services.Configure<DbOptions>(action);

            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));
            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));

            return services;
        }

    }
}
