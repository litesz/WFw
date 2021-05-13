using WFw.Results;

namespace WFw
{
    /// <summary>
    /// 不存在错误
    /// </summary>
    public class WFwNotExistException : WFwException
    {

        /// <summary>
        /// 不存在错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwNotExistException(string param, string logParam = "") : base(OperationResultType.NotExist, param, logParam)
        {

        }

        /// <summary>
        /// 不存在错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwNotExistException(string param, params string[] logKeyValues) : base(OperationResultType.NotExist, param, logKeyValues)
        {

        }

    }
}
