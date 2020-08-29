using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToList
{
    /// <summary>
    /// 批量推任务
    /// </summary>
    public class ListPushTask : PushTask
    {
        /// <summary>
        /// 任务组名
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }
}
