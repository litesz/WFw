using SqlSugar;
using System;
using System.Threading.Tasks;

namespace WFw.DbContext
{
    public class SugarWDeletable<T> : IWDeletable<T> where T : class, new()
    {
        readonly IDeleteable<T> _deletable;

        public SugarWDeletable(SqlSugarClient client)
        {
            _deletable = client.Deleteable<T>();
        }

        public SugarWDeletable(IDeleteable<T> able)
        {
            _deletable = able;
        }

        public int ExecuteCommand()
        {
            return _deletable.ExecuteCommand();
        }

        public Task<int> ExecuteCommandAsync()
        {
            return _deletable.ExecuteCommandAsync();
        }
    }

}
