using Newtonsoft.Json;
using System;
using WFw.GeTui.Models.Message;

namespace WFw.GeTui.Models.Push
{
    /// <summary>
    /// 创建消息
    /// </summary>
    public class PushTask
    {
        /// <summary>
        /// 请求唯一标识号，10-32位之间；如果request_id重复，会导致消息丢失
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 推送条件设置
        /// </summary>
        [JsonProperty("settings")]
        public PushTaskSetting Settings { get; set; }

        /// <summary>
        /// 个推推送消息参数，详细内容见push_message
        /// </summary>
        [JsonProperty("push_message")]
        public PushMessage Message { get; set; }

    }
}


