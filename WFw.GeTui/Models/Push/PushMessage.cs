using Newtonsoft.Json;

namespace WFw.GeTui.Models.Message
{
    /// <summary>
    /// 推送消息内容
    /// </summary>
    public class PushMessage
    {

        /// <summary>
        /// 手机端通知展示时间段，格式为毫秒时间戳段，两个时间的时间差必须大于10分钟，例如："1590547347000-1590633747000"
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// 纯透传消息内容，安卓和iOS均支持，与notification 二选一，两个都填写时报错，长度 ≤ 3072
        /// </summary>
        [JsonProperty("transmission")]
        public string Transmission { get; set; }

        /// <summary>
        /// 通知消息内容，仅支持安卓系统，iOS系统不展示个推通知消息，与transmission二选一，两个都填写时报错
        /// </summary>
        [JsonProperty("notification")]
        public Notification Notification { get; set; }

    }

}


