using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFw.GeTui.Models.Report;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 统计
    /// </summary>
    public partial interface IGeTuiService
    {
        /// <summary>
        /// 获取推送结果
        /// </summary>
        /// <param name="taskIds"></param>
        /// <returns></returns>
        Task<IList<PushResultWithTaskIdReport>> GetPushReportByTaskId(string[] taskIds);

        /// <summary>
        /// 任务组名查报表
        /// </summary>
        /// <param name="taskGroupName"></param>
        /// <returns></returns>
        Task<PushResultWithGroupNameReport> GetPushReportByTaskGroup(string taskGroupName);

        /// <summary>
        /// 获取单日推送数据
        /// </summary>
        /// <param name="date">目前只支持查询非当天的数据</param>
        /// <returns></returns>
        Task<PushResultWithDateReport> GetPushReportByDate(DateTime date);

        /// <summary>
        /// 获取单日用户数据接口
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<UserReport> GetUserReportByDate(DateTime date);

        /// <summary>
        /// 查询当前时间一天内的在线用户数(10分钟一个点，1个小时六个点)
        /// </summary>
        /// <returns></returns>
        Task<OnlineStatics> GetOnlineUser();
    }
}
