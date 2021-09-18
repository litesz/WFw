using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WFw.ISms;
using WFw.SmsChinese.Options;
using WFw.Utils;

namespace WFw.Http.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsChineseApiClient : ISmsClient
    {
        readonly HttpClient _httpClient;
        readonly SmsChineseOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        public SmsChineseApiClient(HttpClient client, SmsChineseOptions op)
        {
            _httpClient = client;
            _options = op;
        }

        public SmsChineseApiClient(IServiceProvider sp) :
            this(sp.GetService<IHttpClientFactory>().CreateClient(SmsChineseOptions.Position), sp.GetService<IOptions<SmsChineseOptions>>().Value)
        {
        }


        public async Task SendMsg(string[] phones, IList<KeyValuePair<string, string>> values, ISmsTemplate template = null)
        {
            ParamCheck.NotNullOrEmpty(phones, "电话");
            ParamCheck.NotNullOrEmpty(values, "消息内容");

            var response = await _httpClient.GetStringAsync(_options.GetSendMsgUrl(string.Join(",", phones), values[0].Value));
            if (!int.TryParse(response, out int status))
            {
                throw new WFwException("发送失败", nameof(response), response);
            }

            if (status < 0)
            {
                throw new WFwException("发送失败", nameof(response), GetErr(status));
            }
        }

        public Task SendVerificationCode(string phone, string code, int expireMin, ISmsTemplate template = null)
        {
            ParamCheck.IsGreaterThan(expireMin, "过期时长", 1);

            return SendMsg(new string[] { phone }, new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(SmsClientConst.KEY_TEXT, BuildVerificationCodeTemplate(code, expireMin)) });
        }

        private string BuildVerificationCodeTemplate(string code, int expireMin)
        {
            ParamCheck.NotNull(_options.VerificationCodeTemplate, "验证码模板");
            return _options.VerificationCodeTemplate.Replace("${code}", code).Replace("${expireMin}", expireMin.ToString());
        }


        public async Task<int> GetMessageRemaining()
        {
            var c = await _httpClient.GetStringAsync(_options.GetMessageRemainingUrl());
            if (!int.TryParse(c, out int v))
            {
                throw new WFwException("查询失败", "response", c);
            }

            if (v < 0)
            {
                throw new WFwException("查询失败", "response", GetErr(v));
            }

            return v;
        }


        private string GetErr(int status)
        {
            if (status > 0)
            {
                return "";
            }
            switch (status)
            {
                case -1: return "没有该用户账户";
                case -2: return "接口密钥不正确";
                case -21: return "MD5接口密钥加密不正确";
                case -3: return "短信数量不足";
                case -11: return "该用户被禁用";
                case -14: return "短信内容出现非法字符";
                case -4: return "手机号格式不正确";
                case -41: return "手机号码为空";
                case -42: return "短信内容为空";
                case -51: return "短信签名格式不正确";
                case -52: return "短信签名太长";
                case -6: return "IP限制";
                default: return "未知错误代码:" + status;
            }
        }


    }
}
