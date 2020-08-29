using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToApp
{
    /// <summary>
    /// 群推
    /// </summary>
    public class AllPushTask : PushTask
    {
        /// <summary>
        /// 推送目标用户该接口audience 对应值为all，表示推送所有用户
        /// </summary>
        public string Audience { get; } = "all";

        /// <summary>
        /// 任务组名
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }
}
