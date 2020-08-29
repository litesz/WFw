using System.Threading.Tasks;
using WFw.GeTui.Models.Push.ToApp;
using WFw.GeTui.Models.Push.ToSingle;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 单推接口
    /// </summary>
    public partial interface IGeTuiService
    {
        /// <summary>
        /// 单推，自动识别接口
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task PushSingle(SinglePushTask pushTask);
        /// <summary>
        /// 单推cid
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task PushSingleByCid(SinglePushTask pushTask);
        /// <summary>
        /// 单推alias
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task PushSingleByAlias(SinglePushTask pushTask);

        /// <summary>
        /// 批量单推，自动识别
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task PushSingleBatch(SingleBatchPushTask pushTask);

        /// <summary>
        /// 批量单推cid
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task PushSingleBatchByCid(SingleBatchPushTask pushTask);

        /// <summary>
        /// 批量单推alias
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        Task PushSingleBatchByAlias(SingleBatchPushTask pushTask);
    }
}
