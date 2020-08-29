using System.Threading.Tasks;
using WFw.GeTui.Models.Push.ToSingle;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 单推
    /// </summary>
    public partial class GeTuiService : IGeTuiService
    {
        /// <summary>
        /// 单推，自动识别Cid或Alias
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task PushSingle(SinglePushTask pushTask)
        {
            if (pushTask.Audience.Cid != null)
            {
                await PushSingleByCid(pushTask);
            }
            else
            {
                await PushSingleByAlias(pushTask);
            }

            // SinglePushResult

        }

        /// <summary>
        /// 单推，cid
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task PushSingleByCid(SinglePushTask pushTask)
        {

            await PostAndCheckCodeAsync("push/single/cid", pushTask);
        }

        /// <summary>
        /// 单推,Alias
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task PushSingleByAlias(SinglePushTask pushTask)
        {

            await PostAndCheckCodeAsync("push/single/alias", pushTask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task PushSingleBatch(SingleBatchPushTask pushTask)
        {
            if (pushTask.List[0].Audience.Cid != null)
            {
                await PushSingleBatchByCid(pushTask);
            }
            else
            {
                await PushSingleBatchByAlias(pushTask);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task PushSingleBatchByCid(SingleBatchPushTask pushTask)
        {
            await PostAndCheckCodeAsync("push/single/batch/cid", pushTask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pushTask"></param>
        /// <returns></returns>
        public async Task PushSingleBatchByAlias(SingleBatchPushTask pushTask)
        {
            await PostAndCheckCodeAsync("push/single/batch/alias", pushTask);
        }
    }
}
