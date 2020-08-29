namespace WFw.GeTui.Models.Report
{
    /// <summary>
    /// 带任务编号的推送结果
    /// </summary>
    public class PushResultWithTaskIdReport : PushResultReport
    {
        /// <summary>
        /// 任务id
        /// </summary>
        public string TaskId { get; set; }

    }
}
