﻿using Newtonsoft.Json;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(T data)
        {
            Data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        public ApiResult(OperationResultType code, T data)
        {
            Data = data;
            Code = code;
        }
    }

    /// <summary>
    /// 同一返回值
    /// </summary>
    public class ApiResult : ApiResult<object>
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(object data) : base(data) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        public ApiResult(OperationResultType code, object data) : base(code, data) { }
    }








}
