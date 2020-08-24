using Newtonsoft.Json;

namespace WFw.GeTui.Models.Auth
{
    public class AuthResponseData
    {
        [JsonProperty("expire_time")]
        public long Expire { get; set; }
        public string Token { get; set; }
    }
}
