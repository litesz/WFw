using Microsoft.Extensions.Logging;
using WFw.Results;

namespace WFw
{


    /// <summary>
    /// 为空错误
    /// </summary>
    public class WFwIsEmptyException : WFwException
    {

        /// <summary>
        /// 为空错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwIsEmptyException(string param, string logParam = "") : base(OperationResultType.IsEmpty, param, logParam)
        {
        }

        /// <summary>
        /// 为空错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="eventId">事件id</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwIsEmptyException(string param, EventId eventId, string logParam = "") : base(OperationResultType.IsEmpty, eventId, param, logParam)
        {
        }

        /// <summary>
        /// 为空错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwIsEmptyException(string param, params string[] logKeyValues) : base(OperationResultType.IsEmpty, param, logKeyValues)
        {

        }

        /// <summary>
        /// 为空错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="eventId">事件id</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwIsEmptyException(string param, EventId eventId, params string[] logKeyValues) : base(OperationResultType.IsEmpty, eventId, param, logKeyValues)
        {

        }

    }
}
