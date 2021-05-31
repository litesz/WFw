using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            services.TryAddScoped<SqlSugarDbContext>();

            services.TryAddScoped<ISqlSugarDbContext>(x => x.GetRequiredService<SqlSugarDbContext>());
            services.TryAddScoped<IWDbContext>(x => x.GetRequiredService<SqlSugarDbContext>());
            //services.TryAddScoped<ISqlSugarDbContext, SqlSugarDbContext>();
            //services.TryAddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));

            services.TryAddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));
            services.TryAddScoped(typeof(IRepository<>), typeof(DefaultRepository<>));
            return services;
        }

        ///// <summary>
        ///// 添加sqlsugarContext
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="configuration"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddWFwSqlSugarDbContext(this IServiceCollection services, IConfiguration configuration)
        //{
        //    return services.AddWFwSqlSugarDbContext(configuration.GetSection(DbOptions.Position));
        //}


        ///// <summary>
        ///// 添加sqlsugarContext
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="configurationSection"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddWFwSqlSugarDbContext(this IServiceCollection services, IConfigurationSection configurationSection)
        //{
        //    services.Configure<DbOptions>(configurationSection);
        //    services.TryAddScoped<ISqlSugarDbContext, SqlSugarDbContext>();
        //    return services;
        //}


        ///// <summary>
        ///// 添加sqlsugarContext
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="action"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddWFwSqlSugarDbContext(this IServiceCollection services, Action<DbOptions> action)
        //{
        //    services.Configure(action);
        //    services.TryAddScoped<ISqlSugarDbContext, SqlSugarDbContext>();
        //    return services;
        //}

    }
}
