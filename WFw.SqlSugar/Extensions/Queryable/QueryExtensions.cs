using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using WFw.DbContext;
using WFw.IEntity;

namespace WFw.IDbContext
{
    /// <summary>
    /// 
    /// </summary>
    public static class QueryExtensions
    {

        /// <summary>
        /// 获得sqlsugarQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static ISugarQueryable<T> ToISugarQueryable<T>(this IRepository<T> repository) where T : class, IEntity<int>, new()
        {
            return ((SugarWQueryable<T>)repository.Query).Queryable;
        }

    }
}
