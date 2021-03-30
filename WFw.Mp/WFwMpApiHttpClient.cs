using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WFw.Mp.Dtos.Oath2;
using WFw.Mp.Dtos.Sns;
using WFw.Mp.Options;
using WFw.Tencent;

namespace WFw.Mp
{
    public interface IWFwWxMiniProgramApiHttpClient
    {
     

        Task<AccessTokenInfo> GetAccessToken(string code);
        Task<AccessTokenInfo> RefreshAccessToken(string refreshToken);
        Task<UserInfo> GetUserInfo(string accessToken, string openId);
    }

    public class WFwMpApiHttpClient : BaseTencentApiHttpClient, IWFwWxMiniProgramApiHttpClient
    {
        private readonly MpOptions options;

        public string BaseWebRedirectUrl(string state = "state") => $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={options.AppId}&redirect_uri={WebUtility.UrlEncode(options.WebRedirectUrl)}&response_type=code&scope=snsapi_base&state={state}#wechat_redirect";
        public string UserInfoMpRedirectUrl(string state = "state") => $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={options.AppId}&redirect_uri={WebUtility.UrlEncode(options.WebRedirectUrl)}&response_type=code&scope=snsapi_userinfo&state={state}#wechat_redirect";



        public WFwMpApiHttpClient(HttpClient httpClient, IServiceProvider sp) : base(httpClient)
        {
            options = sp.GetService<IOptions<MpOptions>>().Value;
        }


        public Task<AccessTokenInfo> GetAccessToken(string code)
        {
            return Get<AccessTokenInfo>($"/sns/oauth2/access_token?appid={options.AppId}&secret={options.Secret}&code={code}&grant_type=authorization_code");
        }

        public Task<AccessTokenInfo> RefreshAccessToken(string refreshToken)
        {
            return Get<AccessTokenInfo>($"/sns/oauth2/refresh_token?appid={options.AppId}&grant_type=refresh_token&refresh_token={refreshToken}");
        }

        public Task<UserInfo> GetUserInfo(string accessToken, string openId)
        {
            return Get<UserInfo>($"/sns/userinfo?access_token={accessToken}&openid={openId}&lang=zh_CN");
        }


    }
}
