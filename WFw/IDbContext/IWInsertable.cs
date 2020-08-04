using System.Threading.Tasks;

namespace WFw.IDbContext
{
    /// <summary>
    /// 插入
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWInsertable<T>
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
        /// 执行返回int主键
        /// </summary>
        /// <returns></returns>
        int ExecuteReturnIdentity();

        /// <summary>
        /// 异步执行返回int主键
        /// </summary>
        /// <returns></returns>
        Task<int> ExecuteReturnIdentityAsync();

        /// <summary>
        /// 执行返回long主键
        /// </summary>
        /// <returns></returns>
        long ExecuteReturnLongIdentity();

        /// <summary>
        /// 异步执行返回long主键
        /// </summary>
        /// <returns></returns>
        Task<long> ExecuteReturnLongIdentityAsync();

        /// <summary>
        /// 执行，主键插入实体
        /// </summary>
        /// <returns></returns>
        bool ExecuteCommandIdentityIntoEntity();

        /// <summary>
        /// 异步执行，主键插入实体
        /// </summary>
        /// <returns></returns>
        Task<bool> ExecuteCommandIdentityIntoEntityAsync();
    }
}
