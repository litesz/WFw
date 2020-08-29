using NETCore.Encrypt.Extensions;
using System;

namespace WFw.GeTui.Models.Auth
{
    /// <summary>
    /// 鉴权
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// appkey
        /// </summary>
        public string appkey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        public AuthRequest(IAuth auth)
        {
            appkey = auth.AppKey;
            timestamp = DateTime.Now.ToMillisecondTimeStamp();
            sign = $"{auth.AppKey}{timestamp}{auth.MasterSecret}".SHA256();
        }
    }
}
