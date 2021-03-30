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
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwSqlSugar(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddWFwSqlSugar(configuration.GetSection(DbOptions.Position));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwSqlSugar(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<DbOptions>(configurationSection);
            return AddScopeds(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwSqlSugar(this IServiceCollection services, Action<DbOptions> action)
        {
            services.Configure(action);
            return AddScopeds(services);
        }

        private static IServiceCollection AddScopeds(IServiceCollection services)
        {
            services.AddScoped<SqlSugarDbContext>();
            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));

            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));
            services.AddScoped(typeof(IRepository<>), typeof(DefaultRepository<>));
            return services;
        }



    }
}
