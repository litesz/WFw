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
        /// 剩余短信数
        /// </summary>
        /// <returns></returns>
        Task<int> GetMessageRemaining();

        /// <summary>
        /// 群发短信
        /// </summary>
        /// <param name="phones">手机号</param>
        /// <param name="values">内容键值对</param>
        /// <param name="template">签名、模板ID等</param>
        /// <returns></returns>
        Task SendMsg(string[] phones, IList<KeyValuePair<string, string>> values, ISmsTemplate template = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <param name="expireMin"></param>
        /// <param name="template">签名、模板ID等</param>
        /// <returns></returns>
        Task SendVerificationCode(string phone, string code, int expireMin, ISmsTemplate template = null);
    }
}
