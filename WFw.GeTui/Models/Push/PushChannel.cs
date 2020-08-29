using Newtonsoft.Json;

namespace WFw.GeTui.Models.Message
{
    /// <summary>
    /// 推送通道
    /// </summary>
    public class PushChannel
    {
        /// <summary>
        /// ios通道推送消息内容
        /// </summary>
        [JsonProperty("ios")]
        public PushChannelIos Ios { get; set; }


        /// <summary>
        /// android通道推送消息内容
        /// </summary>
        [JsonProperty("android")]
        public PushChannelAndroid Android { get; set; }

    }

}


