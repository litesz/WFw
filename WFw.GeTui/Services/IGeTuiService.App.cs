using System.Threading.Tasks;
using WFw.GeTui.Models.Push.ToApp;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 群推
    /// </summary>
    public partial interface IGeTuiService
    {
        /// <summary>
        /// 执行群推
        /// 注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口根据条件筛选用户推送共享限制)，定时推送功能需要申请开通才可以使用，申请修改请联系邮箱：lieg@getui.com。
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task<string> PushAll(AllPushTask pushTask);

        /// <summary>
        /// 根据条件筛选用户推送
        /// 注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口执行群推共享限制)，定时推送功能需要申请开通才可以使用，申请修改请联系邮箱：lieg@getui.com。
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns>taskId</returns>
        Task<string> PushTag(TagPushTask pushTask);

        /// <summary>
        /// 根据条件筛选用户推送
        /// 该功能需要申请相关套餐，请联系邮箱：lieg@getui.com 。
        /// </summary>
        /// <param name="使用标签快速推送"></param>
        /// <returns>taskId</returns>
        Task<string> PushCustomTag(CustomTagPushTask pushTask);
    }
}
