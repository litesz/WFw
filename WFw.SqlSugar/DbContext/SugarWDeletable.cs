using SqlSugar;
using System.Threading.Tasks;
using WFw.IDbContext;

namespace WFw.DbContext
{
    /// <summary>
    /// 删除接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SugarWDeletable<T> : IWDeletable<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public IDeleteable<T> Deletable => _deletable;

        /// <summary>
        /// 
        /// </summary>
        readonly IDeleteable<T> _deletable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public SugarWDeletable(SqlSugarClient client)
        {
            _deletable = client.Deleteable<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="able"></param>
        public SugarWDeletable(IDeleteable<T> able)
        {
            _deletable = able;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteCommand()
        {
            return _deletable.ExecuteCommand();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> ExecuteCommandAsync()
        {
            return _deletable.ExecuteCommandAsync();
        }
    }

}
