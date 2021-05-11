

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
        public ApiResult()
        {
        }

        public ApiResult(object data) : base(data) { }
    }

    /// <summary>
    /// 统一错误返回值
    /// </summary>
    public class ErrApiResult : ApiResult
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public ErrApiResult(WFwException exception)
        {
            Code = exception.OperationResult;
            Msg = exception.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ErrApiResult(OperationResultType code, string msg) : this("", code, msg)
        {

        }

        public ErrApiResult(string requestId, OperationResultType code, string msg)
        {
            this.RequestId = requestId;
            this.Code = code;
            this.Msg = msg;
        }
    }








}
