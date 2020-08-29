using WFw.GeTui.Models.Message;

namespace WFw.GeTui.Models.Push.ToSingle
{
    /// <summary>
    /// 执行单推
    /// </summary>
    public class SinglePushTask : PushTask
    {
        /// <summary>
        /// 推送目标用户，详细解释见下方audience说明
        /// </summary>
        public Audience Audience { get; set; }
    }
}
