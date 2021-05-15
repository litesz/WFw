﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WFw.Tencent.Responses;

namespace WFw.WxMiniProgram.Dtos.Cgi
{
    public class GetAccessTokenResponse : BaseResponse
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
