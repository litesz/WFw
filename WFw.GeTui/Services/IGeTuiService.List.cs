using System.Threading.Tasks;
using WFw.GeTui.Models.Push.ToList;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 批量推
    /// </summary>
    public partial interface IGeTuiService
    {
        /// <summary>
        /// 创建消息
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task<string> CreatePushMessage(ListPushTask pushTask);

        /// <summary>
        /// 执行批量推
        /// 注：此接口频次限制200万次/天(和执行别名批量推共享限制)，申请修改请联系邮箱：lieg@getui.com。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task PushList(ListPushMessage message);

        /// <summary>
        /// 执行cid批量推
        /// 注：此接口频次限制200万次/天(和执行别名批量推共享限制)，申请修改请联系邮箱：lieg@getui.com。
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="cids"></param>
        /// <returns></returns>
        Task PushListByCid(string taskId, string[] cids);

        /// <summary>
        /// 执行别名批量推
        /// 注：此接口频次限制200万次/天(和执行cid批量推共享限制)，申请修改请联系邮箱：lieg@getui.com。
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        Task PushListByAlias(string taskId, string[] alias);
    }
}
