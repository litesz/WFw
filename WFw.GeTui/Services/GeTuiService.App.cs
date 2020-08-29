using System.Threading.Tasks;
using WFw.GeTui.Models.Push;
using WFw.GeTui.Models.Push.ToApp;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 群推
    /// </summary>
    public partial class GeTuiService : IGeTuiService
    {
        /// <summary>
        /// 执行群推
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task<string> PushAll(AllPushTask pushTask)
        {
            return (await PostAndReturnAsync<TaskIdData>("push/all", pushTask)).TaskId;
        }

        /// <summary>
        /// 根据条件筛选用户推送
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task<string> PushTag(TagPushTask pushTask)
        {
            return (await PostAndReturnAsync<TaskIdData>("push/tag", pushTask)).TaskId;
        }

        /// <summary>
        /// 根据条件筛选用户推送
        /// </summary>
        /// <param name="使用标签快速推送"></param>
        /// <returns></returns>
        public async Task<string> PushCustomTag(CustomTagPushTask pushTask)
        {
            return (await PostAndReturnAsync<TaskIdData>("push/fast_custom_tag", pushTask)).TaskId;
        }
    }
}
