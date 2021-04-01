using Newtonsoft.Json;
using WFw.Tencent.Responses;

namespace WFw.Mp.Models.Cgi
{
    public class CgiAccessToken : BaseResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int Expires_in { get; set; }
    }
}
