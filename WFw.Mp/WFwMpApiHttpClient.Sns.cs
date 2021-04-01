using System.Threading.Tasks;
using WFw.Mp.Models.Sns;
using WFw.Tencent;

namespace WFw.Mp
{

    public partial class WFwMpApiHttpClient : BaseTencentApiHttpClient, IWFwMpApiHttpClient
    {

        public Task<SnsAccessToken> GetAccessTokenFromSns(string code)
        {
            return Get<SnsAccessToken>($"/sns/oauth2/access_token?appid={options.AppId}&secret={options.Secret}&code={code}&grant_type=authorization_code");
        }

        public Task<SnsAccessToken> RefreshAccessTokenFromSns(string refreshToken)
        {
            return Get<SnsAccessToken>($"/sns/oauth2/refresh_token?appid={options.AppId}&grant_type=refresh_token&refresh_token={refreshToken}");
        }

        public Task<SnsUserInfo> GetUserInfoFromSns(string snsAccessToken, string openId)
        {
            return Get<SnsUserInfo>($"/sns/userinfo?access_token={snsAccessToken}&openid={openId}&lang=zh_CN");
        }


    }
}
