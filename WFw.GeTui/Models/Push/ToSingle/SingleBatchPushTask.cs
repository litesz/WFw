using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToSingle
{
    /// <summary>
    /// 执行批量单推
    /// </summary>
    public class SingleBatchPushTask
    {
        /// <summary>
        /// 是否异步
        /// </summary>
        [JsonProperty("is_async")]
        public bool IsAsync { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("msg_list")]
        public SinglePushTask[] List { get; set; }
    }
}
