using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WFw.Tencent;
using WFw.WxMiniProgram.Dtos.Sns;
using WFw.WxMiniProgram.Options;

namespace WFw.WxMiniProgram
{
    public interface IWFwWxMiniProgramApiHttpClient
    {
        Task<JsCode2SessionResponse> JsCode2Session(string code);
    }

    public class WFwWxMiniProgramApiHttpClient : BaseTencentApiHttpClient, IWFwWxMiniProgramApiHttpClient
    {
        private readonly WxMinProgramOptions programOptions;
        public WFwWxMiniProgramApiHttpClient(HttpClient httpClient, IServiceProvider sp) : base(httpClient)
        {
            programOptions = sp.GetService<IOptions<WxMinProgramOptions>>().Value;
        }

        public Task<JsCode2SessionResponse> JsCode2Session(string code)
        {
            return Get<JsCode2SessionResponse>($"sns/jscode2session?appid={programOptions.AppId}&secret={programOptions.AppSecret}&js_code={code}&grant_type=authorization_code");
        }
    }
}
