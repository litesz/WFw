using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WFw.DbContext
{
    public interface IWUpdatable<T>
    {
        int ExecuteCommand();
        Task<int> ExecuteCommandAsync();
        IWUpdatable<T> SetColumns(Expression<Func<T, T>> columns);
        IWUpdatable<T> Where(Expression<Func<T, bool>> expression);

    }
}
