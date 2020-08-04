using System.Threading.Tasks;


namespace WFw.IDbContext
{
    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWDeletable<T>
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
    }
}
