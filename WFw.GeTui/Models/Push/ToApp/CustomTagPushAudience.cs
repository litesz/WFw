using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToApp
{
    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class CustomTagPushAudience
    {
        /// <summary>
        /// 使用用户标签筛选目标用户
        /// </summary>
        [JsonProperty("fast_custom_tag")]
        public string CustomTag { get; set; }
    }
}
