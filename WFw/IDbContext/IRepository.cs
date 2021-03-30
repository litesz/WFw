using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.IEntity;

namespace WFw.IDbContext
{

    /// <summary>
    /// 数据库上下文
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>, new()
    {

    }


    /// <summary>
    /// 数据库上下文
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    public partial interface IRepository<TEntity, TPrimary> where TEntity : class, IEntity<TPrimary>, new()
    {
        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <param name="initData"></param>
        void Init(params TEntity[] initData);

        #region 同步

        /// <summary>
        /// 插入实体并返回主键
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象主键</returns>
        TPrimary InsertReturnId(TEntity entity);
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数是否大于0</returns>
        bool Insert(params TEntity[] entities);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数</returns>
        int Delete(params TEntity[] entities);
        /// <summary>
        /// 删除指定编号的实体
        /// </summary>
        /// <param name="key">实体主键</param>
        /// <returns>操作影响的行数</returns>
        int Delete(TPrimary key);
        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entities">更新后的实体对象</param>
        /// <returns>操作影响的行数</returns>
        int Update(params TEntity[] entities);

        /// <summary>
        /// 查找指定主键的实体
        /// </summary>
        /// <param name="key">实体主键</param>
        /// <returns>符合主键的实体，不存在时返回null</returns>
        TEntity GetFirst(TPrimary key);

        /// <summary>
        /// 查找第一个符合条件的数据
        /// </summary>
        /// <param name="predicate">数据查询谓语表达式</param>
        /// <returns>符合条件的实体，不存在时返回null</returns>
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAll();

        #endregion

        #region  异步

        /// <summary>
        /// 插入实体并返回主键
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象主键</returns>
        Task<TPrimary> InsertReturnIdAsync(TEntity entity);
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数是否大于0</returns>
        Task<bool> InsertAsync(params TEntity[] entities);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数</returns>
        Task<int> DeleteAsync(params TEntity[] entities);
        /// <summary>
        /// 删除指定编号的实体
        /// </summary>
        /// <param name="key">实体主键</param>
        /// <returns>操作影响的行数</returns>
        Task<int> DeleteAsync(TPrimary key);
        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entities">更新后的实体对象</param>
        /// <returns>操作影响的行数</returns>
        Task<int> UpdateAsync(params TEntity[] entities);



        /// <summary>
        /// 查找指定主键的实体
        /// </summary>
        /// <param name="key">实体主键</param>
        /// <returns>符合主键的实体，不存在时返回null</returns>
        Task<TEntity> GetFirstAsync(TPrimary key);

        /// <summary>
        /// 查找第一个符合条件的数据
        /// </summary>
        /// <param name="predicate">数据查询谓语表达式</param>
        /// <returns>符合条件的实体，不存在时返回null</returns>
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAllAsync();

        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        IWQueryable<TEntity> Query { get; }

        /// <summary>
        /// 查询(包含软删除)
        /// </summary>
        IWQueryable<TEntity> QueryNoFlag { get; }

     

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        ///// <summary>
        ///// 根据sql查询
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //IWQueryable<TEntity> SqlQueryable(string sql);

        /// <summary>
        /// ADO
        /// </summary>
        IAdo Ado { get; }
    }
}
