using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToApp
{
    /// <summary>
    /// 根据条件筛选用户推送
    /// </summary>
    public class TagPushTask : PushTask
    {
        /// <summary>
        /// 任务组名
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// 推送目标用户
        /// </summary>
        public TagPushAudience Audience { get; set; }

    }
}
