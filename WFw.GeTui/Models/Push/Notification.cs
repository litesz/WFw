using Newtonsoft.Json;
using WFw.GeTui.Models.Push;

namespace WFw.GeTui.Models.Message
{
    /// <summary>
    /// 通知
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// 通知消息标题，长度 ≤ 50
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 通知消息内容，长度 ≤ 256
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// 长文本消息内容，通知消息+长文本样式，与big_image二选一，两个都填写时报错，长度 ≤ 512
        /// </summary>
        [JsonProperty("big_text")]
        public string BigText { get; set; }

        /// <summary>
        /// 大图的URL地址，通知消息+大图样式， 与big_text二选一，两个都填写时报错，长度 ≤ 1024
        /// </summary>
        [JsonProperty("big_image")]
        public string BigImage { get; set; }

        /// <summary>
        /// 通知的图标名称，包含后缀名（需要在客户端开发时嵌入），如“push.png”，长度 ≤ 64
        /// </summary>
        [JsonProperty("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// 通知图标URL地址，长度 ≤ 256
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 通知渠道id，长度 ≤ 64
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; } = "Default";

        /// <summary>
        /// 通知渠道名称，长度 ≤ 64
        /// </summary>
        [JsonProperty("channel_name")]
        public string ChannelName { get; set; } = "Default";

        /// <summary>
        /// 设置通知渠道重要性（可以控制响铃，震动，浮动，闪灯等等）
        /// android8.0以下
        /// 0，1，2:无声音，无振动，不浮动
        /// 3:有声音，无振动，不浮动
        /// 4:有声音，有振动，有浮动
        /// android8.0以上
        /// 0：无声音，无振动，不显示；
        /// 1：无声音，无振动，锁屏不显示，通知栏中被折叠显示，导航栏无logo;
        /// 2：无声音，无振动，锁屏和通知栏中都显示，通知不唤醒屏幕;
        /// 3：有声音，无振动，锁屏和通知栏中都显示，通知唤醒屏幕;
        /// 4：有声音，有振动，亮屏下通知悬浮展示，锁屏通知以默认形式展示且唤醒屏幕;
        /// </summary>
        [JsonProperty("channel_level")]
        public ChannelLevel ChannelLevel { get; set; } = ChannelLevel.Default;

        /// <summary>
        /// 点击通知后续动作，
        /// 目前支持5种后续动作，
        /// intent：打开应用内特定页面，
        /// url：打开网页地址，
        /// payload：启动应用加自定义消息内容，
        /// startapp：打开应用首页，
        /// none：纯通知，无后续动作
        /// </summary>

        [JsonProperty("click_type")]
        public string ClickType { get; set; } = "none";

        /// <summary>
        /// click_type为intent时必填
        /// 点击通知打开应用特定页面，长度 ≤ 2048;
        /// 示例：intent:#Intent;component=你的包名/你要打开的 activity 全路径;S.parm1=value1;S.parm2=value2;end
        /// intent生成请参考
        /// </summary>
        [JsonProperty("intent")]
        public string Intent { get; set; }

        /// <summary>
        /// click_type为url时必填
        /// 点击通知打开链接，长度 ≤ 1024
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// click_type为payload时必填
        /// 点击通知加自定义消息，长度 ≤ 3072
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// 覆盖任务时会使用到该字段，两条消息的notify_id相同，新的消息会覆盖老的消息
        /// </summary>
        [JsonProperty("notify_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? NotifyId { get; set; }
    }

}


