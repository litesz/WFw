using System;
using WFw.Results;

namespace WFw
{
    /// <summary>
    /// 错误请求
    /// </summary>
    public class WFwException : Exception
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public OperationResultType OperationResult { get; }
        /// <summary>
        /// 显示描述
        /// </summary>
        public string ParamName { get; }

        /// <summary>
        /// 日志记录参数
        /// </summary>
        public string LogParam { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WFwException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(string param, string logParam) : this(OperationResultType.IsErr, param, logParam) { }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="result">状态</param>
        ///// <param name="logParam">日志消息参数</param>
        //public WFwException(OperationResultType result, string logParam) : this(result, "", logParam)
        //{
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(OperationResultType result, string param, string logParam) : base(string.Format(result.GetEnumDescription(), param))
        {
            OperationResult = result;
            ParamName = param;
            LogParam = logParam;
        }


     

    }
}
