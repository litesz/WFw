using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WFw.Tencent.Responses;

namespace WFw.WxMiniProgram.Auth.Dtos
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
