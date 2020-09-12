using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.IEntity;

namespace WFw.IDbContext
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimary"></typeparam>
        /// <param name="repository"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int Delete<TEntity, TPrimary>(this IRepository<TEntity, TPrimary> repository, IList<TEntity> list) where TEntity : class, IEntity<TPrimary>, new()
        {
            return repository.Delete(list.ToArray());
        }

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimary"></typeparam>
        /// <param name="repository"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Task<int> DeleteAsync<TEntity, TPrimary>(this IRepository<TEntity, TPrimary> repository, IList<TEntity> list) where TEntity : class, IEntity<TPrimary>, new()
        {
            return repository.DeleteAsync(list.ToArray());
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimary"></typeparam>
        /// <param name="repository"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int Update<TEntity, TPrimary>(this IRepository<TEntity, TPrimary> repository, IList<TEntity> list) where TEntity : class, IEntity<TPrimary>, new()
        {
            return repository.Update(list.ToArray());
        }

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimary"></typeparam>
        /// <param name="repository"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Task<int> UpdateAsync<TEntity, TPrimary>(this IRepository<TEntity, TPrimary> repository, IList<TEntity> list) where TEntity : class, IEntity<TPrimary>, new()
        {
            return repository.UpdateAsync(list.ToArray());
        }


        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimary"></typeparam>
        /// <param name="repository"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool Insert<TEntity, TPrimary>(this IRepository<TEntity, TPrimary> repository, IList<TEntity> list) where TEntity : class, IEntity<TPrimary>, new()
        {
            return repository.Insert(list.ToArray());
        }

        /// <summary>
        /// 异步插入
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimary"></typeparam>
        /// <param name="repository"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Task<bool> InsertAsync<TEntity, TPrimary>(this IRepository<TEntity, TPrimary> repository, IList<TEntity> list) where TEntity : class, IEntity<TPrimary>, new()
        {
            return repository.InsertAsync(list.ToArray());
        }
    }
}
