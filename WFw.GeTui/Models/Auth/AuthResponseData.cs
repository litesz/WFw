using Newtonsoft.Json;

namespace WFw.GeTui.Models.Auth
{
    /// <summary>
    /// 鉴权结果
    /// </summary>
    public class AuthResponseData
    {
        /// <summary>
        /// 过期时间戳
        /// </summary>
        [JsonProperty("expire_time")]
        public long Expire { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
    }
}
