using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WFw.ISms
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISmsClient
    {

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="expireMin"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<(bool, string)> SendVerification(string code, int expireMin, string phone);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phone"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        Task<(bool, string)> SendSms(string text, string phone, string templateId = "");

        /// <summary>
        /// 剩余短信数
        /// </summary>
        /// <returns></returns>
        Task<int> GetMessageRemaining();
    }
}
