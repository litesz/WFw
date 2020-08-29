namespace WFw.GeTui.Models.Push.ToSingle
{
    /// <summary>
    /// 执行单推结果内容
    /// </summary>
    public class SinglePushResultItem
    {
        /// <summary>
        /// cid
        /// </summary>
        public string Cid { get; set; }
        public PushResultStatus Status { get; set; }
    }
}
