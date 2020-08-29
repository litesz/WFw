using System;

namespace WFw.GeTui.Stores
{
    /// <summary>
    /// 令牌存储
    /// </summary>
    public class GeTuiTokenStore
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expire { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        public bool IsExpire
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Token))
                {
                    return true;
                }
                if (Expire >= DateTime.Now.AddMinutes(-30))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GeTuiTokenStore()
        {
        }
    }
}
