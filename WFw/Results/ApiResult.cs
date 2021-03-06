﻿using WFw.Exceptions;

namespace WFw.Results
{
    /// <summary>
    /// 同一返回值
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public OperationResultType code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; } = "成功";
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApiResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public ApiResult(BadRequestException exception)
        {
            code = exception.OperationResult;
            msg = exception.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ApiResult(OperationResultType code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(object data)
        {
            this.data = data;
        }
    }
}
