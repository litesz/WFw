using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WFw.IDbContext
{
    /// <summary>
    /// 更新
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWUpdatable<T>
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        int ExecuteCommand();
        /// <summary>
        /// 异步执行
        /// </summary>
        /// <returns></returns>
        Task<int> ExecuteCommandAsync();
        /// <summary>
        /// 指定列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IWUpdatable<T> SetColumns(Expression<Func<T, T>> columns);
        /// <summary>
        /// 判断条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWUpdatable<T> Where(Expression<Func<T, bool>> expression);

    }
}
