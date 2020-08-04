using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.DbContext;
using WFw.IDbContext;

namespace WFw
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<DbOptions>(configurationSection);

            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));

            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, Action<DbOptions> action)
        {
            services.Configure<DbOptions>(action);

            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));
            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));

            return services;
        }

    }
}
