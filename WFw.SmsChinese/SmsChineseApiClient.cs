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
            var requestUri = $"http://{(options.IsUtf8 ? "utf8" : "gbk")}.api.smschinese.cn/?Uid={options.Uid}&Key={options.Key}&smsMob={phone}&smsText={text}";
            var response = await _httpClient.GetStringAsync(requestUri);

            if (!int.TryParse(response, out int status))
            {
                return (false, "发送失败");
            }

            if (status > 0)
            {
                return (true, "");
            }
            string err;
            switch (status)
            {
                case -1: err = "没有该用户账户"; break;
                case -2: err = "接口密钥不正确"; break;
                case -21: err = "MD5接口密钥加密不正确"; break;
                case -3: err = "短信数量不足"; break;
                case -11: err = "该用户被禁用"; break;
                case -14: err = "短信内容出现非法字符"; break;
                case -4: err = "手机号格式不正确"; break;
                case -41: err = "手机号码为空"; break;
                case -42: err = "短信内容为空"; break;
                case -51: err = "短信签名格式不正确"; break;
                case -52: err = "短信签名太长"; break;
                case -6: err = "IP限制"; break;
                default: err = "错误代码:" + status; break;
            }

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


        public async Task GetRemain()
        {
            var requestUri = $"http://www.smschinese.cn/web_api/SMS/{(options.IsUtf8 ? "":"GBK/" )}?Action=SMS_Num&Uid={options.Uid}&Key={options.Key}";
            // var requestUri = $"http://{(options.IsUtf8 ? "utf8" : "gbk")}.api.smschinese.cn/?Uid={options.Uid}&Key={options.Key}&smsMob={phone}&smsText={text}";
            var response = await _httpClient.GetStringAsync(requestUri);
        }
    }
}
