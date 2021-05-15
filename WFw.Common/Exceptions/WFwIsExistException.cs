using WFw.Results;

namespace WFw
{
    /// <summary>
    /// 已存在错误
    /// </summary>
    public class WFwIsExistException : WFwException
    {

        /// <summary>
        /// 已存在错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwIsExistException(string param, string logParam = "") : base(OperationResultType.IsExist, param, logParam)
        {

        }

        /// <summary>
        /// 已存在错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwIsExistException(string param, params string[] logKeyValues) : base(OperationResultType.IsExist, param, logKeyValues)
        {

        }

    }
}
