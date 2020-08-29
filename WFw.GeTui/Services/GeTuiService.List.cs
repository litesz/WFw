using System.Threading.Tasks;
using WFw.GeTui.Models.Message;
using WFw.GeTui.Models.Push;
using WFw.GeTui.Models.Push.ToList;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 批量推
    /// </summary>
    public partial class GeTuiService : IGeTuiService
    {
        /// <summary>
        /// 创建消息
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task<string> CreatePushMessage(ListPushTask pushTask)
        {
            return (await PostAndReturnAsync<TaskIdData>("push/list/message", pushTask)).TaskId;
        }

        /// <summary>
        /// 执行cid批量推
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task PushList(ListPushMessage message)
        {

            await PostAndCheckCodeAsync("push/list/cid", message);
        }

        /// <summary>
        /// 执行别名批量推
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="cids"></param>
        /// <returns></returns>
        public async Task PushListByCid(string taskId, string[] cids)
        {
            await PushList(new ListPushMessage
            {
                TaskId = taskId,
                Audience = new Audience
                {
                    Cid = cids
                }
            });
        }

        /// <summary>
        /// 执行别名批量推
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public async Task PushListByAlias(string taskId, string[] alias)
        {
            await PushList(new ListPushMessage
            {
                TaskId = taskId,
                Audience = new Audience
                {
                    Alias = alias
                }
            });
        }

    }
}
