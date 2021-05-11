using System;
using WFw.Results;

namespace WFw.Exceptions
{
    [Obsolete]
    /// <summary>
    /// 错误请求
    /// </summary>
    public class BadRequestException : WFwException
    {

        /// <summary>
        /// 
        /// </summary>
        public BadRequestException() { }

        public BadRequestException(OperationResultType result) : base(result, "", "")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        public BadRequestException(OperationResultType result, string value) : base(result, value, value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        /// <param name="param"></param>
        public BadRequestException(OperationResultType result, string value,string param) : base(result, value, param)
        {

        }
    }
}
