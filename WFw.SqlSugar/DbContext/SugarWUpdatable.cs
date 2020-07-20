using SqlSugar;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WFw.DbContext
{

    public class SugarWUpdatable<T> : IWUpdatable<T> where T : class, new()
    {

        private IUpdateable<T> _updateable;

        public SugarWUpdatable(SqlSugarClient client)
        {
            _updateable = client.Updateable<T>();
        }

        public SugarWUpdatable(IUpdateable<T> able)
        {
            _updateable = able;
        }

        public int ExecuteCommand()
        {
            return _updateable.ExecuteCommand();
        }

        public Task<int> ExecuteCommandAsync()
        {
            return _updateable.ExecuteCommandAsync();
        }

        public IWUpdatable<T> SetColumns(Expression<Func<T, T>> columns)
        {
            _updateable = _updateable.SetColumns(columns);
            return this;
        }

        public IWUpdatable<T> Where(Expression<Func<T, bool>> expression)
        {
            _updateable = _updateable.Where(expression);
            return this;
        }
    }

}
