using SqlSugar;
using System.Threading.Tasks;
using WFw.IDbContext;

namespace WFw.DbContext
{
    /// <summary>
    /// 插入接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SugarWInsertable<T> : IWInsertable<T>
    {

        /// <summary>
        /// 
        /// </summary>
        readonly IInsertable<T> _insertable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="able"></param>
        public SugarWInsertable(IInsertable<T> able)
        {
            _insertable = able;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteCommand()
        {
            return _insertable.ExecuteCommand();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> ExecuteCommandAsync()
        {
            return _insertable.ExecuteCommandAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ExecuteCommandIdentityIntoEntity()
        {
            return _insertable.ExecuteCommandIdentityIntoEntity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<bool> ExecuteCommandIdentityIntoEntityAsync()
        {
            return _insertable.ExecuteCommandIdentityIntoEntityAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteReturnIdentity()
        {
            return _insertable.ExecuteReturnIdentity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> ExecuteReturnIdentityAsync()
        {
            return _insertable.ExecuteReturnIdentityAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long ExecuteReturnLongIdentity()
        {
            return _insertable.ExecuteReturnBigIdentity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<long> ExecuteReturnLongIdentityAsync()
        {
            return _insertable.ExecuteReturnBigIdentityAsync();
        }

     
    }

}
