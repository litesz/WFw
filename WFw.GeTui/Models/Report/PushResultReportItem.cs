using Newtonsoft.Json;

namespace WFw.GeTui.Models.Report
{
    /// <summary>
    /// 推送结果
    /// </summary>
    public class PushResultReportItem
    {
        /// <summary>
        /// 目标下发数
        /// </summary>
        [JsonProperty("target_num")]
        public int Target { get; set; }

        /// <summary>
        /// 消息接收数
        /// </summary>
        [JsonProperty("receive_num")]
        public int Receive { get; set; }

        /// <summary>
        /// 消息展示数
        /// </summary>

        [JsonProperty("display_num")]
        public int Display { get; set; }

        /// <summary>
        /// 消息点击数
        /// </summary>
        [JsonProperty("click_num")]
        public int Click { get; set; }

    }
}
