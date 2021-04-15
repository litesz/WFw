using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WFw.ISms;
using Microsoft.Extensions.Options;
using WFw.SmsChinese.Options;

namespace WFw.Http.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsChineseApiClient : ISmsClient
    {
        private readonly HttpClient _httpClient;
        private readonly SmsChineseOptions options;
        private readonly ILogger<SmsChineseApiClient> logger;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        public SmsChineseApiClient(HttpClient client, SmsChineseOptions op, ILogger<SmsChineseApiClient> l)
        {
            _httpClient = client;
            options = op;
            logger = l;
        }

        public SmsChineseApiClient(IServiceProvider sp) :
            this(sp.GetService<IHttpClientFactory>().CreateClient(SmsChineseOptions.Position), sp.GetService<IOptions<SmsChineseOptions>>().Value, sp.GetService<ILogger<SmsChineseApiClient>>())
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phones"></param>
        /// <returns></returns>
        public Task<(bool, string)> SendSms(string text, params string[] phones)
        {

            return SendSms(text, string.Join(",", phones));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phone"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public async Task<(bool, string)> SendSms(string text, string phone, string templateId = "")
        {
            var response = await _httpClient.GetStringAsync($"http://{(options.IsUtf8 ? "utf8" : "gbk")}.api.smschinese.cn/?Uid={options.Uid}&Key={options.Key}&smsMob={phone}&smsText={text}");

            if (!int.TryParse(response, out int status))
            {
                return (false, "发送失败");
            }

            if (status > 0)
            {
                return (true, "");
            }
            string err = GetErr(status);

            logger.LogError($"发送短信失败[{phone}]:{err}");

            return (false, err);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="ExpireMin"></param>
        /// <param name="phones"></param>
        /// <returns></returns>
        public Task<(bool, string)> SendVerification(string code, int expireMin, params string[] phones)
        {
            return SendSms($"验证码为：{code}，有效期{expireMin}分钟，若非本人操作，请忽略。", phones);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="expireMin"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Task<(bool, string)> SendVerification(string code, int expireMin, string phone)
        {
            return SendSms($"验证码为：{code}，有效期{expireMin}分钟，若非本人操作，请忽略。", phone);
        }


        public async Task<int> GetMessageRemaining()
        {
            var r = await _httpClient.GetAsync($"http://www.smschinese.cn/web_api/SMS/{(options.IsUtf8 ? "" : "GBK/")}?Action=SMS_Num&Uid={options.Uid}&Key={options.Key}");
            var c = await r.Content.ReadAsStringAsync();
            if (!int.TryParse(c, out int v))
            {
                throw new Exception("错误的返回值:" + c);
            }

            if (v > 0)
            {
                return v;
            }

            throw new Exception("查询出错:" + GetErr(v));
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
                default: return "错误代码:" + status;
            }

        }
    }
}
