using SqlSugar;
using System;
using System.Threading.Tasks;

namespace WFw.DbContext
{

    public class SugarWInsertable<T> : IWInsertable<T>
    {

        readonly IInsertable<T> _insertable;

        public SugarWInsertable(IInsertable<T> able)
        {
            _insertable = able;
        }

        public int ExecuteCommand()
        {
          return  _insertable.ExecuteCommand();
        }

        public Task<int> ExecuteCommandAsync()
        {
            return _insertable.ExecuteCommandAsync();
        }

        public bool ExecuteCommandIdentityIntoEntity()
        {
            return _insertable.ExecuteCommandIdentityIntoEntity();
        }

        public Task<bool> ExecuteCommandIdentityIntoEntityAsync()
        {
            return _insertable.ExecuteCommandIdentityIntoEntityAsync();
        }

        public int ExecuteReturnIdentity()
        {
            return _insertable.ExecuteReturnIdentity();
        }

        public Task<int> ExecuteReturnIdentityAsync()
        {
            return _insertable.ExecuteReturnIdentityAsync();
        }
    }

}
