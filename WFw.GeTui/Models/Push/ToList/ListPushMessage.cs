using Newtonsoft.Json;
using WFw.GeTui.Models.Message;

namespace WFw.GeTui.Models.Push.ToList
{
    /// <summary>
    /// 批量推
    /// </summary>
    public class ListPushMessage
    {
        /// <summary>
        /// 是否异步推送，异步推送不会返回data
        /// </summary>
        [JsonProperty("is_async")]
        public bool IsAsync { get; set; }

        /// <summary>
        /// 使用创建消息接口返回的taskId
        /// </summary>
        [JsonProperty("taskid")]
        public string TaskId { get; set; }

        /// <summary>
        /// 推送目标用户
        /// </summary>
        public Audience Audience { get; set; }
    }
}


