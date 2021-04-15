

using Newtonsoft.Json;

namespace WFw.Results
{
    /// <summary>
    /// 同一返回值
    /// </summary>
    public class ApiResult
    {
        [JsonProperty("code")]
        /// <summary>
        /// 状态
        /// </summary>
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
        public object Data { get; set; }

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
        public ApiResult(WFwException exception)
        {
            Code = exception.OperationResult;
            Msg = exception.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ApiResult(OperationResultType code, string msg)
        {
            this.Code = code;
            this.Msg = string.Format(code.GetEnumDescription(), msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(object data)
        {
            this.Data = data;
        }
    }
    /// <summary>
    /// 
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
        /// 
        /// </summary>
        public ApiResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public ApiResult(WFwException exception)
        {
            Code = exception.OperationResult;
            Msg = exception.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ApiResult(OperationResultType code, string msg)
        {
            this.Code = code;
            this.Msg = string.Format(code.GetEnumDescription(), msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(T data)
        {
            this.Data = data;
        }
    }

}
