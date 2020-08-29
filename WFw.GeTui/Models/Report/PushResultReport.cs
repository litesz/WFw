using System;

namespace WFw.GeTui.Models.Report
{
    /// <summary>
    /// 推送结果
    /// </summary>
    public class PushResultReport
    {

        /// <summary>
        /// 个推
        /// </summary>
        public PushResultReportItem Gt { get; set; }

        /// <summary>
        /// apn
        /// </summary>
        public PushResultReportItem Ios { get; set; }

        /// <summary>
        /// 坚果
        /// </summary>
        public PushResultReportItem St { get; set; }

        /// <summary>
        /// 华为
        /// </summary>
        public PushResultReportItem Hw { get; set; }

        /// <summary>
        /// 小米
        /// </summary>
        public PushResultReportItem Xm { get; set; }

        /// <summary>
        /// vivo
        /// </summary>
        public PushResultReportItem Vv { get; set; }

        /// <summary>
        /// 魅族
        /// </summary>
        public PushResultReportItem Mz { get; set; }

        /// <summary>
        /// Oppo
        /// </summary>
        public PushResultReportItem Op { get; set; }

        /// <summary>
        /// 总计
        /// </summary>
        public PushResultReportItem Total { get; set; }

    }

    /// <summary>
    /// 带日期的推送结果
    /// </summary>
    public class PushResultWithDateReport : PushResultReport
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

    }
}
