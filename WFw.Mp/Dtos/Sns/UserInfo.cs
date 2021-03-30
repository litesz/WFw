using Newtonsoft.Json;
using WFw.Tencent.Responses;

namespace WFw.Mp.Dtos.Sns
{
    public class UserInfo : BaseResponse
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }
        [JsonProperty("unionid")]
        public string UnionId { get; set; }
        [JsonProperty("nickname")]
        public string NickName { get; set; }


        [JsonProperty("sex")]
        public int Sex { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }
        public string[] Privilege { get; set; }

    }
}
