using Newtonsoft.Json;

namespace WFw.GeTui.Models.Report
{
    /// <summary>
    /// 用户数
    /// </summary>
    public class UserReport
    {
        /// <summary>
        /// 累计注册用户数
        /// </summary>
        [JsonProperty("accumulative_num")]
        public int Accumulative { get; set; }

        /// <summary>
        /// 注册用户数
        /// </summary>
        [JsonProperty("register_num")]
        public int Register { get; set; }

        /// <summary>
        /// 活跃用户数
        /// </summary>

        [JsonProperty("active_num")]
        public int Active { get; set; }

        /// <summary>
        /// 在线用户数
        /// </summary>
        [JsonProperty("online_num")]
        public int Online { get; set; }
    }
}
