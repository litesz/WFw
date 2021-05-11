

using Newtonsoft.Json;
using System;

namespace WFw.Results
{
    /// <summary>
    /// 泛型，用户反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("code")]
        public OperationResultType Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; } = "成功";
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// 请求id
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApiResult()
        {
        }

        public ApiResult(T data)
        {
            this.Data = data;
        }
    }

    /// <summary>
    /// 同一返回值
    /// </summary>
    public class ApiResult : ApiResult<object>
    {
       
    }

    /// <summary>
    /// 统一错误返回值
    /// </summary>
    public class ErrApirResult : ApiResult<string>
    {
        ///// <summary>
        ///// 请求id
        ///// </summary>
        //[JsonProperty("requestId")]
        //public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public ErrApirResult(WFwException exception)
        {
            Code = exception.OperationResult;
            Msg = exception.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ErrApirResult(OperationResultType code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        public ErrApirResult(string requestId, OperationResultType code, string msg)
        {
            this.RequestId = requestId;
            this.Code = code;
            this.Msg = msg;
        }
    }








}
