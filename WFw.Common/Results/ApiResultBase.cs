using Newtonsoft.Json;

namespace WFw.Results
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ApiResultBase : IApiResult
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

    }








}
