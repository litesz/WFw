using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WFw.Tencent;
using WFw.WxMiniProgram.Dtos.Cgi;
using WFw.WxMiniProgram.Dtos.Sns;
using WFw.WxMiniProgram.Dtos.Wxa;
using WFw.WxMiniProgram.Options;

namespace WFw.WxMiniProgram
{
    public interface IWFwWxMiniProgramApiHttpClient
    {
        /// <summary>
        /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<JsCode2SessionResponse> JsCode2Session(string code);

        /// <summary>
        /// 用户支付完成后，获取该用户的 UnionId，无需用户授权。本接口支持第三方平台代理查询。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetPaidUnionIdResponse> GetPaidUnionId(GetPaidUnionIdRequest request);

        /// <summary>
        /// 获取小程序全局唯一后台接口调用凭据（access_token）。调用绝大多数后台接口时都需使用 access_token，开发者需要进行妥善保存。
        /// </summary>
        /// <returns></returns>
        Task<GetAccessTokenResponse> GetAccessTokenResponse();
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

        public Task<GetPaidUnionIdResponse> GetPaidUnionId(GetPaidUnionIdRequest request)
        {
            return Get<GetPaidUnionIdResponse>($"wxa/getpaidunionid?{request}");
        }

        public Task<GetAccessTokenResponse> GetAccessTokenResponse()
        {
            return Get<GetAccessTokenResponse>($"cgi-bin/token?grant_type=client_credential&appid={programOptions.AppId}&secret={programOptions.AppSecret}");

        }

    }
}
