using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using WFw.DbContext;
using WFw.IDbContext;
using WFw.SqlSugar.DbContext.Config;

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
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwSqlSugar(this IServiceCollection services, IConfigurationSection configurationSection, Action<IServiceProvider, SqlSugarClient> configAction = null)
        {
            services.Configure<DbOptions>(configurationSection);
            return AddScopeds(services, configAction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwSqlSugar(this IServiceCollection services, Action<DbOptions> action, Action<IServiceProvider, SqlSugarClient> configAction = null)
        {
            services.Configure(action);
            return AddScopeds(services, configAction);
        }


        private static IServiceCollection AddScopeds(IServiceCollection services, Action<IServiceProvider, SqlSugarClient> configAction = null)
        {

            services.TryAddSingleton<ISqlSugarClient>(serverProvider =>
            {
                var option = serverProvider.GetRequiredService<IOptions<DbOptions>>().Value;

                return new SqlSugarScope(option.ToConnectionConfig(), db =>
                {
                    configAction?.Invoke(serverProvider, db);
                });
            });

            services.TryAddScoped<SqlSugarDbContext>();

            services.TryAddScoped<ISqlSugarDbContext>(x => x.GetRequiredService<SqlSugarDbContext>());
            services.TryAddScoped<IWDbContext>(x => x.GetRequiredService<SqlSugarDbContext>());

            services.TryAddSingleton(typeof(IAuditHandler<,>), typeof(DefaultAuditHandler<,>));
            services.TryAddScoped(typeof(IRepository<,,>), typeof(DefaultRepository<,,>));
            services.TryAddScoped(typeof(IRepository<,>), typeof(DefaultRepository<,>));
            services.TryAddScoped(typeof(ISimpleClient<>), typeof(SimpleClient<>));

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ConnectionConfig ToConnectionConfig(this DbOptions options)
        {
            var dbType = options.DatabaseType.ToLower() switch
            {
                "mysql" => DbType.MySql,
                "sqlserver" => DbType.SqlServer,
                "sqlite" => DbType.Sqlite,
                "oracle" => DbType.Oracle,
                "postgresql" => DbType.PostgreSQL,
                "dm" => DbType.Dm,
                "kdbndp" => DbType.Kdbndp,
                _ => throw new ArgumentOutOfRangeException("无法使用数据库类型:" + options.DatabaseType),
            };
            return new ConnectionConfig()
            {
                ConnectionString = options.ConnectionString,
                DbType = dbType,
                InitKeyType = options.InitKeyType == "attribute" ? InitKeyType.Attribute : InitKeyType.SystemTable,
                IsAutoCloseConnection = options.IsAutoCloseConnection,
                //IsShardSameThread = options.IsShardSameThread,
                ConfigureExternalServices = new WfwConfigureExternalServices(options)
            };

        }
    }
}
