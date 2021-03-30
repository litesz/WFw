using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using WFw.IDbContext;

namespace WFw.DbContext
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlSugarDbContext : IWDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public SqlSugarClient Db { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IDbContext.IAdo Ado => new SugarAdo(Db.Ado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbOptions"></param>
        public SqlSugarDbContext(IServiceProvider sp)
        {
            var dbOptions = sp.GetService<IOptions<DbOptions>>().Value;
            //IOptions<DbOptions> dbOptions
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = dbOptions.ConnectionString,
                DbType = GetDbType(dbOptions.DatabaseType),
                InitKeyType = dbOptions.InitKeyType == "attribute" ? InitKeyType.Attribute : InitKeyType.SystemTable,
                IsAutoCloseConnection = dbOptions.IsAutoCloseConnection,
                IsShardSameThread = dbOptions.IsShardSameThread,
            });

        }


        private DbType GetDbType(string type)
        {
            return (type.ToLower()) switch
            {
                "mysql" => DbType.MySql,
                "sqlserver" => DbType.SqlServer,
                "sqlite" => DbType.Sqlite,
                _ => throw new ArgumentOutOfRangeException("无法使用数据库类型:" + type),
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="initData"></param>
        public void Init<TEntity>(params TEntity[] initData) where TEntity : class
        {
            Db.CodeFirst.InitTables<TEntity>();
        }

        /// <summary>
        /// 如果不存在创建数据库
        /// </summary>
        public void InitDatabase()
        {
            Db.DbMaintenance.CreateDatabase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IWQueryable<TEntity> Queryable<TEntity>()
        {
            return new SugarWQueryable<TEntity>(Db);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IWDeletable<TEntity> Deletable<TEntity>() where TEntity : class, new()
        {
            return new SugarWDeletable<TEntity>(Db);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IWDeletable<TEntity> Deletable<TEntity>(params dynamic[] ids) where TEntity : class, new()
        {

            return new SugarWDeletable<TEntity>(Db.Deleteable<TEntity>(ids));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IWUpdatable<TEntity> Updatable<TEntity>() where TEntity : class, new()
        {
            return new SugarWUpdatable<TEntity>(Db);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        public IWUpdatable<TEntity> Updatable<TEntity>(params TEntity[] objs) where TEntity : class, new()
        {
            return new SugarWUpdatable<TEntity>(Db.Updateable<TEntity>(objs));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public IWInsertable<TEntity> Insertable<TEntity>(params TEntity[] insertObjs) where TEntity : class, new()
        {
            return new SugarWInsertable<TEntity>(Db.Insertable<TEntity>(insertObjs));
        }


    }

}

