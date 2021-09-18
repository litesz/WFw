using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WFw.ISms
{
    /// <summary>
    /// 
    /// </summary>
    public static class SmsExtensions
    {
        /// <summary>
        /// 发短信
        /// </summary>
        /// <param name="c">客户端</param>
        /// <param name="text">消息</param>
        /// <param name="phone">电话号码</param>
        /// <param name="key">属性名，极光模板用</param>
        /// <param name="template">模板id、签名等</param>
        /// <returns></returns>
        public static Task SendMsg(this ISmsClient c, string text, string phone, string key = "", ISmsTemplate template = null)
        {
            return c.SendMsg(new string[] { phone }, new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(string.IsNullOrWhiteSpace(key) ? SmsClientConst.KEY_TEXT : key, text) }, template);
        }

        /// <summary>
        /// 发短信
        /// </summary>
        /// <param name="c">客户端</param>
        /// <param name="values">消息键值对，模板用</param>
        /// <param name="phone">电话号码</param>
        /// <param name="template">模板id、签名等</param>
        /// <returns></returns>
        public static Task SendMsg(this ISmsClient c, string phone, IList<KeyValuePair<string, string>> values, ISmsTemplate template = null)
        {
            return c.SendMsg(new string[] { phone }, values, template);
        }

    }
}
