using System;
using WFw.Results;
using WFw.Utils;

namespace WFw.Exceptions
{
    /// <summary>
    /// 错误请求
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public OperationResultType OperationResult { get; }
        /// <summary>
        /// 描述
        /// </summary>
        public string ContentText { get; }
        /// <summary>
        /// 
        /// </summary>
        public BadRequestException() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public BadRequestException(OperationResultType result) : this(result, "") //base(result.GetEnumDescription())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        public BadRequestException(OperationResultType result, string value) : base(string.Format(result.GetEnumDescription(), value))
        {
            ContentText = value;
            OperationResult = result;
        }
    }
}
