﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using WFw.IDbContext;
using WFw.SqlSugar.DbContext.Config;

namespace WFw.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class SqlSugarDbContext : IWDbContext, ISqlSugarDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ISqlSugarClient Db { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IDbContext.IAdo Ado => new SugarAdo(Db.Ado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlSugarClient"></param>

        public SqlSugarDbContext(ISqlSugarClient sqlSugarClient)
        {
            Db = sqlSugarClient;
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

