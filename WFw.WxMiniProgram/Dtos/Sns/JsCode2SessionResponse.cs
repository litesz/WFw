using Newtonsoft.Json;
using WFw.Tencent.Responses;

namespace WFw.WxMiniProgram.Dtos.Sns
{
    public class JsCode2SessionResponse : BaseResponse
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}
