using System.Threading.Tasks;
using WFw.GeTui.Models.Push.Schedule;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial class GeTuiService : IGeTuiService
    {
        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task StopTask(string taskId)
        {
            await DeleteAsync("task/" + taskId);

        }

        /// <summary>
        /// 查询定时任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public Task<ScheduleItem> GetSchedule(string taskId)
        {

            return GetAsync<ScheduleItem>("task/schedule/" + taskId);
        }

        /// <summary>
        /// 删除定时任务
        /// 用来删除还未下发的任务，删除后定时任务不再出发
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task StopSchedule(string taskId)
        {
            await DeleteAsync("task/schedule/" + taskId);
        }
    }
}
