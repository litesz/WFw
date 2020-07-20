using System.Threading.Tasks;

namespace WFw.DbContext
{
    public interface IWDeletable<T>
    {
        int ExecuteCommand();
        Task<int> ExecuteCommandAsync();
    }
}
