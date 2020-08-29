using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.GeTui.Models.Report;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 统计
    /// </summary>
    public partial class GeTuiService : IGeTuiService
    {
        /// <summary>
        /// 获取推送结果
        /// </summary>
        /// <param name="taskIds"></param>
        /// <returns></returns>
        public async Task<IList<PushResultWithTaskIdReport>> GetPushReportByTaskId(string[] taskIds)
        {
            int index = 0;
            var ids = taskIds.Skip(index * 200).Take(200);
            IList<PushResultWithTaskIdReport> output = new List<PushResultWithTaskIdReport>(taskIds.Length);
            while (ids.Any())
            {
                var jTokens = await GetJTokensAsync("report/push/task/" + string.Join(",", ids));

                foreach (var x in jTokens)
                {
                    var t = x.ToObject<PushResultWithTaskIdReport>();
                    t.TaskId = x.Path;
                    output.Add(t);
                }

                index++;
                ids = taskIds.Skip(index * 200).Take(200);
            }

            return output;
        }


        /// <summary>
        /// 任务组名查报表
        /// </summary>
        /// <param name="taskGroupName"></param>
        /// <returns></returns>
        public async Task<PushResultWithGroupNameReport> GetPushReportByTaskGroup(string taskGroupName)
        {

            var jTokens = await GetJTokensAsync("report/push/task_group/" + taskGroupName);
            var content = jTokens.First();

            var output = content.ToObject<PushResultWithGroupNameReport>();
            output.GroupName = taskGroupName;
            return output;
        }

        /// <summary>
        /// 获取单日推送数据
        /// </summary>
        /// <param name="date">目前只支持查询非当天的数据</param>
        /// <returns></returns>
        public async Task<PushResultWithDateReport> GetPushReportByDate(DateTime date)
        {

            var jTokens = await GetJTokensAsync("report/push/date/" + date.ToString("yyyy-MM-dd"));
            var content = jTokens.First();

            var output = content.ToObject<PushResultWithDateReport>();
            output.Date = date;
            return output;

        }

        /// <summary>
        /// 获取单日用户数据接口
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<UserReport> GetUserReportByDate(DateTime date)
        {

            var jTokens = await GetJTokensAsync("report/user/date/" + date.ToString("yyyy-MM-dd"));
            var content = jTokens.First();

            return content.ToObject<UserReport>();
        }

        /// <summary>
        /// 获取24个小时在线用户数
        /// </summary>
        /// <returns></returns>
        public async Task<OnlineStatics> GetOnlineUser()
        {

            var content = await GetDataStrAsync("report/online_user");
            var data = content.GetSelectedSection("online_statics");
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("查询结果解码失败");
            }
            var array = data.Trim('{', '}').Split(',');
            OnlineStaticsItem[] items = new OnlineStaticsItem[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                var tmp = array[i].Split(':');
                items[i] = new OnlineStaticsItem
                {
                    Number = int.Parse(tmp[1]),
                    DateTime = long.Parse(tmp[0].Trim('\"')).ToDateTime()
                };
            }

            return new OnlineStatics
            {
                Items = items
            };
        }

    }
}
