using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WFw.DbContext
{
    /// <summary>
    /// 
    /// </summary>
    public class SugarAdo : IDbContext.IAdo
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IAdo ado;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ado"></param>
        public SugarAdo(IAdo ado)
        {
            this.ado = ado;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BeginTransaction()
        {
            ado.BeginTran();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CommitTransaction()
        {
            ado.CommitTran();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(string sql, object parameters = null)
        {
            return ado.ExecuteCommand(sql, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<int> ExecuteCommandAsync(string sql, object parameters = null)
        {
            return ado.ExecuteCommandAsync(sql, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RollBackTransaction()
        {
            ado.RollbackTran();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<TEntity> SqlQuery<TEntity>(string sql, object parameters = null)
        {
            return ado.SqlQuery<TEntity>(sql, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IList<TEntity>> SqlQueryAsync<TEntity>(string sql, object parameters = null)
        {
            return await ado.SqlQueryAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        public IDbContext.TranResult<bool> UseTran(Action action, Action<Exception> errorCallBack = null)
        {
            var rt = ado.UseTran(action, errorCallBack);
            return new IDbContext.TranResult<bool>
            {
                Data = rt.Data,
                ErrorException = rt.ErrorException,
                ErrorMessage = rt.ErrorMessage,
                IsSuccess = rt.IsSuccess
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        public async Task<IDbContext.TranResult<bool>> UseTranAsync(Action action, Action<Exception> errorCallBack = null)
        {
            var rt = await ado.UseTranAsync(action, errorCallBack);
            return new IDbContext.TranResult<bool>
            {
                Data = rt.Data,
                ErrorException = rt.ErrorException,
                ErrorMessage = rt.ErrorMessage,
                IsSuccess = rt.IsSuccess
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        public IDbContext.TranResult<T> UseTran<T>(Func<T> action, Action<Exception> errorCallBack = null)
        {
            var rt = ado.UseTran<T>(action, errorCallBack);
            return new IDbContext.TranResult<T>
            {
                Data = rt.Data,
                ErrorException = rt.ErrorException,
                ErrorMessage = rt.ErrorMessage,
                IsSuccess = rt.IsSuccess
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="errorCallBack"></param>
        /// <returns></returns>
        public async Task<IDbContext.TranResult<T>> UseTranAsync<T>(Func<T> action, Action<Exception> errorCallBack = null)
        {
            var rt = await ado.UseTranAsync<T>(action, errorCallBack);
            return new IDbContext.TranResult<T>
            {
                Data = rt.Data,
                ErrorException = rt.ErrorException,
                ErrorMessage = rt.ErrorMessage,
                IsSuccess = rt.IsSuccess
            };
        }


    }


}
