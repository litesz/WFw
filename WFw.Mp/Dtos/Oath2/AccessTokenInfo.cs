﻿using Newtonsoft.Json;
using WFw.Tencent.Responses;

namespace WFw.Mp.Dtos.Oath2
{
    public class AccessTokenInfo : BaseResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int Expires_in { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        public string Scope { get; set; }
    }
}
