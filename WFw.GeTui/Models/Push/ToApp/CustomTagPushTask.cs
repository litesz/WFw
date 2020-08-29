using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToApp
{
    /// <summary>
    /// 使用标签快速推送
    /// </summary>
    public class CustomTagPushTask
    {
        /// <summary>
        /// 任务组名
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// 推送目标用户
        /// </summary>
        public CustomTagPushAudience Audience { get; set; }
    }
}
