namespace WFw.GeTui.Models.Push.ToSingle
{
    /// <summary>
    /// 推送结果 
    /// </summary>
    public enum PushResultStatus
    {
        /// <summary>
        /// 离线下发(包含厂商通道下发)
        /// </summary>
        Offline,
        /// <summary>
        /// 在线下发
        /// </summary>
        Online,
        /// <summary>
        /// 最近90天内不活跃用户不下发
        /// </summary>
        Ignore
    }
}
