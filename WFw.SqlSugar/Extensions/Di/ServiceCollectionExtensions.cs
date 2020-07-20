using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WFw.DbContext;

namespace WFw.Extensions.Di
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<DbOptions>(configurationSection);

            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));

            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));

            //services.AddScoped(typeof(IWInsertable<>), typeof(SugarWInsertable<>));
            //services.AddScoped(typeof(IWQueryable<>), typeof(SugarWQueryable<>));
            //services.AddScoped(typeof(IWUpdatable<>), typeof(SugarWUpdatable<>));
            //services.AddScoped(typeof(IWDeletable<>), typeof(SugarWDeletable<>));
            return services;
        }


        public static IServiceCollection AddSqlSugar(this IServiceCollection services, Action<DbOptions> action)
        {
            services.Configure<DbOptions>(action);

            services.AddScoped(typeof(IWDbContext), typeof(SqlSugarDbContext));
            services.AddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));

            //services.AddScoped(typeof(IWInsertable<>), typeof(SugarWInsertable<>));
            //services.AddScoped(typeof(IWQueryable<>), typeof(SugarWQueryable<>));
            //services.AddScoped(typeof(IWUpdatable<>), typeof(SugarWUpdatable<>));
            //services.AddScoped(typeof(IWDeletable<>), typeof(SugarWDeletable<>));

            return services;
        }

    }
}
