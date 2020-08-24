using NETCore.Encrypt.Extensions;
using System;

namespace WFw.GeTui.Models.Auth
{
    public class AuthRequest
    {
        public string sign { get; set; }
        public string timestamp { get; set; }
        public string appkey { get; set; }

        public AuthRequest(IAuth auth)
        {
            appkey = auth.AppKey;
            timestamp = DateTime.Now.ToMillisecondTimeStamp();
           // var xxxxx = $"{auth.AppKey}{timestamp}{auth.MasterSecret}";
            sign = $"{auth.AppKey}{timestamp}{auth.MasterSecret}".SHA256();
            //sign = sign.ToLower();

        }
    }
}
