using System.Threading.Tasks;

namespace WFw.Http.Services
{
    /// <summary>
    /// 短信接口
    /// </summary>
    public interface ISmsService
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task<string> Send(string phone, string msg);
    }
}
