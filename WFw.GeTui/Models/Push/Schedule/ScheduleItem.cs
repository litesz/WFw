using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.Schedule
{
    /// <summary>
    /// 查询定时任务
    /// </summary>
    public class ScheduleItem
    {
        /// <summary>
        /// 定时任务创建时间，毫秒时间戳
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }
        /// <summary>
        /// 定时任务状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 透传内容
        /// </summary>
        [JsonProperty("transmission_content")]
        public string Content { get; set; }
        /// <summary>
        /// 定时任务推送时间，毫秒时间戳
        /// </summary>
        [JsonProperty("push_time")]
        public string PushTime { get; set; }
    }
}
