using System.Threading.Tasks;
using WFw.Mp.Models.Cgi;
using WFw.Tencent;

namespace WFw.Mp
{

    public partial class WFwMpApiHttpClient : BaseTencentApiHttpClient, IWFwMpApiHttpClient
    {

        public Task<CgiAccessToken> GetAccessToken()
        {
            return Get<CgiAccessToken>($"/cgi-bin/token?grant_type=client_credential&appid={options.AppId}&secret={options.Secret}");
        }

        public Task<CgiUserInfo> GetUSerInfo(string accessToken, string openId)
        {
            return Get<CgiUserInfo>($"/cgi-bin/user/info?access_token={accessToken}&openid={openId}&lang=zh_CN");
        }
    }
}
