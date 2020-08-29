using System;

namespace WFw.GeTui.Models.Report
{
    /// <summary>
    /// 在线用户统计数据
    /// </summary>
    public class OnlineStaticsItem
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }
    }
}
