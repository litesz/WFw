using SqlSugar;
using WFw.DbContext;

namespace WFw.IDbContext
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbContextExtensions
    {

        /// <summary>
        /// 获得sqlsugarQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static ISugarQueryable<T> ToSugarQueryable<T>(this IWQueryable<T> query)
        {
            return (query as SugarWQueryable<T>).Queryable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updatable"></param>
        /// <returns></returns>
        public static IUpdateable<T> ToSugarUpdateable<T>(this IWUpdatable<T> updatable) where T : class, new()
        {
            return (updatable as SugarWUpdatable<T>).Updateable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deletable"></param>
        /// <returns></returns>
        public static IDeleteable<T> ToSugarDeletable<T>(this IWDeletable<T> deletable) where T : class, new()
        {
            return (deletable as SugarWDeletable<T>).Deletable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="insertable"></param>
        /// <returns></returns>
        public static IInsertable<T> ToSugarDeletable<T>(this IWInsertable<T> insertable) where T : class, new()
        {
            return (insertable as SugarWInsertable<T>).Insertable;
        }

    }
}
