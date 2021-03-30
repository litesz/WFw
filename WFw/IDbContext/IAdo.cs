using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WFw.IDbContext
{
    /// <summary>
    /// ado
    /// </summary>
    public interface IAdo
    {

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<TEntity> SqlQuery<TEntity>(string sql, object parameters = null);

        /// <summary>
        ///  执行sql语句
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IList<TEntity>> SqlQueryAsync<TEntity>(string sql, object parameters = null);

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteCommand(string sql, object parameters = null);

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<int> ExecuteCommandAsync(string sql, object parameters = null);

        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚
        /// </summary>
        void RollBackTransaction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        TranResult<bool> UseTran(Action action, Action<Exception> errorCallBack = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        TranResult<T> UseTran<T>(Func<T> action, Action<Exception> errorCallBack = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        Task<TranResult<bool>> UseTranAsync(Action action, Action<Exception> errorCallBack = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        Task<TranResult<T>> UseTranAsync<T>(Func<T> action, Action<Exception> errorCallBack = null);
    }
}
