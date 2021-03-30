using System;
using WFw.Results;
using WFw.Utils;

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
        public string ContentText { get; }

        /// <summary>
        /// 日志记录错误
        /// </summary>
        public string LogContent { get; }

        /// <summary>
        /// 
        /// </summary>
        public WFwException() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public WFwException(OperationResultType result) : this(result, "")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        public WFwException(OperationResultType result, string msg) : this(result, msg, msg)
        {
        }

        public WFwException(OperationResultType result, string msg, string logMsg) : base(string.Format(result.GetEnumDescription(), msg))
        {
            ContentText = msg;
            LogContent = logMsg;
            OperationResult = result;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="result"></param>
        ///// <param name="value"></param>
        //public WFwException(OperationResultType result, string value) : base(string.Format(result.GetEnumDescription(), value))
        //{
        //    ContentText = value;
        //    OperationResult = result;
        //}

    }
}
