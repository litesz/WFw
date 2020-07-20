using Microsoft.Extensions.Options;
using SqlSugar;
using System;

namespace WFw.DbContext
{

    public class SqlSugarDbContext : IWDbContext
    {
        public SqlSugarClient Db { get; private set; }
        public SqlSugarDbContext(IOptions<DbOptions> dbOptions)
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = dbOptions.Value.ConnectionString,
                DbType = GetDbType(dbOptions.Value.DatabaseType),
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
            });
        }

        public void InitTables(params Type[] tables)
        {
            Db.CodeFirst.InitTables(tables);
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

        public void Init<TEntity>(params TEntity[] initData) where TEntity : class
        {
            Db.CodeFirst.InitTables<TEntity>();
        }

        public IWQueryable<TEntity> Queryable<TEntity>()
        {
            return new SugarWQueryable<TEntity>(Db);
        }

        public IWDeletable<TEntity> Deletable<TEntity>() where TEntity : class, new()
        {
            return new SugarWDeletable<TEntity>(Db);
        }

        public IWDeletable<TEntity> Deletable<TEntity>(params dynamic[] ids) where TEntity : class, new()
        {

            return new SugarWDeletable<TEntity>(Db.Deleteable<TEntity>(ids));
        }

        public IWUpdatable<TEntity> Updatable<TEntity>() where TEntity : class, new()
        {
            return new SugarWUpdatable<TEntity>(Db);
        }

        public IWUpdatable<TEntity> Updatable<TEntity>(params TEntity[] objs) where TEntity : class, new()
        {
            return new SugarWUpdatable<TEntity>(Db.Updateable<TEntity>(objs));
        }

        public IWInsertable<TEntity> Insertable<TEntity>(params TEntity[] insertObjs) where TEntity : class, new()
        {
            return new SugarWInsertable<TEntity>(Db.Insertable<TEntity>(insertObjs));
        }
    }

}

