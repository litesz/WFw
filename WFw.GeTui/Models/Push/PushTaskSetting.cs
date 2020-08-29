using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push
{
    /// <summary>
    /// 推送条件设置
    /// </summary>
    public class PushTaskSetting
    {

        /// <summary>
        /// 消息离线时间设置，单位毫秒，-1表示不设离线，-1 ～ 3 * 24 * 3600 * 1000(3天)之间
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; set; } = 3600000;

        /// <summary>
        /// 定速推送，例如100，个推控制下发速度在100条/秒左右，0表示不限速
        /// </summary>
        [JsonProperty("speed")]
        public int? Speed { get; set; }

        /// <summary>
        /// 定时推送时间，格式：毫秒时间戳，此功能需要开通VIP，如需开通请联系 lieg@getui.com
        /// </summary>
        [JsonProperty("schedule_time")]
        public int? Schedule { get; set; }

    }

}


