using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WFw.Tencent;
using WFw.Tencent.Responses;
using WFw.WxMiniProgram.Auth.Dtos;
using WFw.WxMiniProgram.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WFw.WxMiniProgram
{
    public interface IWxMiniProgramApiHttpClient
    {
        Task<JsCode2SessionResponse> JsCode2Session(string code);
    }

    public class WxMiniProgramApiHttpClient : BaseTencentApiHttpClient, IWxMiniProgramApiHttpClient
    {
        private readonly WxMinProgramOptions programOptions;
        public WxMiniProgramApiHttpClient(HttpClient httpClient, IServiceProvider sp) : base(httpClient)
        {
            programOptions = sp.GetService<IOptions<WxMinProgramOptions>>().Value;
        }

        public Task<JsCode2SessionResponse> JsCode2Session(string code)
        {
            return Get<JsCode2SessionResponse>($"sns/jscode2session?appid={programOptions.AppId}&secret={programOptions.AppSecret}&js_code={code}&grant_type=authorization_code");
        }
    }
}
