using System.Threading.Tasks;

namespace WFw.DbContext
{
    public interface IWInsertable<T>
    {
        int ExecuteCommand();
        Task<int> ExecuteCommandAsync();

        int ExecuteReturnIdentity();
        Task<int> ExecuteReturnIdentityAsync();
        bool ExecuteCommandIdentityIntoEntity();
        Task<bool> ExecuteCommandIdentityIntoEntityAsync();
    }
}
