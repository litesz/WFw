using System;
using WFw.Results;

namespace WFw.Exceptions
{

    /// <summary>
    /// 错误请求
    /// </summary>
    public class BadRequestException : WFwException
    {


        /// <summary>
        /// 
        /// </summary>
        public BadRequestException() : base(OperationResultType.ParamIsErr, "")
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        public BadRequestException(params string[] keyValues) : base(OperationResultType.ParamIsErr, "", keyValues)
        { }


        public BadRequestException(OperationResultType result) : base(result, "")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        public BadRequestException(OperationResultType result, string value) : base(result, value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        /// <param name="param"></param>
        public BadRequestException(OperationResultType result, string value, string param) : base(result, value, param)
        {

        }


    }
}
