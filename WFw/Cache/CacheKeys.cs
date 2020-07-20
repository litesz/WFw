using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Cache
{
    public class CacheKeys
    {
        public static string VerifyCodeKey(string phone)
        {
            return $"VerifyCode:{phone}";
        }
    }
}
