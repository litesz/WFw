using SqlSugar;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.IDbContext;

namespace WFw.DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SugarWUpdatable<T> : IWUpdatable<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>

        private IUpdateable<T> _updateable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public SugarWUpdatable(SqlSugarClient client)
        {
            _updateable = client.Updateable<T>();
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="able"></param>
        public SugarWUpdatable(IUpdateable<T> able)
        {
            _updateable = able;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteCommand()
        {
            return _updateable.ExecuteCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> ExecuteCommandAsync()
        {
            return _updateable.ExecuteCommandAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public IWUpdatable<T> SetColumns(Expression<Func<T, T>> columns)
        {
            _updateable = _updateable.SetColumns(columns);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWUpdatable<T> Where(Expression<Func<T, bool>> expression)
        {
            _updateable = _updateable.Where(expression);
            return this;
        }
    }

}
