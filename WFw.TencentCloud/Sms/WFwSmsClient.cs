using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TencentCloud.Sms.V20190711;
using TencentCloud.Sms.V20190711.Models;
using WFw.ISms;
using WFw.TencentCloud.Options;
using System.Linq;

namespace WFw.TencentCloud
{

    public interface IWFwSmsClient : ISmsClient
    {




    }

    public class WFwSmsClient : ISmsClient, IWFwSmsClient
    {
        private readonly SmsClient client;
        private readonly SmsOptions options;
        private readonly ILogger<WFwSmsClient> logger;
        public WFwSmsClient(IOptions<TencentCloudOptions> op, ILogger<WFwSmsClient> l)
        {
            options = op.Value.Sms;
            client = new SmsClient(op.Value.Credential, options.Regin);
            logger = l;
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
            return (false, "发送失败");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="expireMin"></param>
        /// <param name="phones"></param>
        /// <returns></returns>
        public async Task<(bool, string)> SendVerification(string code, int expireMin, string phones)
        {
            try
            {
                SendSmsRequest req = new SendSmsRequest
                {
                    PhoneNumberSet = phones.Select(u => $"+86{u}").ToArray(),
                    SmsSdkAppid = options.Verification.SmsSdkAppid,
                    TemplateID = options.Verification.TemplateId,
                    TemplateParamSet = new string[] { code, expireMin.ToString() },
                    Sign = options.Verification.Sign
                };

                SendSmsResponse resp = await client.SendSms(req);
                return (true, "");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"SendVerification:{code}");

                return (false, "发送失败");
            }
        }
    }
}
