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
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwIsEmptyException(string param, params string[] logKeyValues) : base(OperationResultType.IsEmpty, param, logKeyValues)
        {

        }

    }
}
