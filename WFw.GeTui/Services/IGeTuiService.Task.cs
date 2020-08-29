using System.Threading.Tasks;
using WFw.GeTui.Models.Push.Schedule;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial interface IGeTuiService
    {


        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task StopTask(string taskId);

        /// <summary>
        /// 删除定时任务
        /// 用来删除还未下发的任务，删除后定时任务不再出发
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task StopSchedule(string taskId);

        /// <summary>
        /// 查询定时任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<ScheduleItem> GetSchedule(string taskId);



    }
}
