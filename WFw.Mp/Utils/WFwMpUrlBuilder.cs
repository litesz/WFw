using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using WFw.Mp.Options;

namespace WFw.Mp.Utils
{
    public class WFwMpUrlBuilder
    {
        private readonly MpOptions options;

        private string state = "state";
        private string scop = "snsapi_base";

        public WFwMpUrlBuilder(IServiceProvider sp)
        {
            options = sp.GetService<IOptions<MpOptions>>().Value;
        }

        public WFwMpUrlBuilder SetState(string state)
        {
            this.state = state;
            return this;
        }

        public WFwMpUrlBuilder IsBase()
        {
            scop = "snsapi_base";
            return this;
        }

        public WFwMpUrlBuilder IsUserInfo()
        {
            scop = "snsapi_userinfo";
            return this;
        }

        public string Build()
        {
            return $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={options.AppId}&redirect_uri={WebUtility.UrlEncode(options.WebRedirectUrl)}&response_type=code&scope={scop}&state={state}#wechat_redirect";
        }



    }
}
