using Newtonsoft.Json;
using WFw.Tencent.Responses;

namespace WFw.Mp.Models.Cgi
{
    public class CgiUserInfo : BaseResponse
    {
        public int Subscribe { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("sex")]
        public int Sex { get; set; }


        [JsonProperty("language")]
        public string Language { get; set; }

        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }

        [JsonProperty("subscribe_time")]
        public long SubscribeTime { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }

        public string Remark { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("tagid_list")]
        public int[] TagIdList { get; set; }


        [JsonProperty("subscribe_scene")]
        public string SubscribeScene { get; set; }

        [JsonProperty("qr_scene")]
        public int QrScene { get; set; }
        [JsonProperty("qr_scene_str")]
        public string QrSceneStr { get; set; }

    }
}
