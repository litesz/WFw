using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using TencentCloud.Sms.V20190711;
using TencentCloud.Sms.V20190711.Models;
using WFw.ISms;
using WFw.TencentCloud.Options;

namespace WFw.TencentCloud.Clients.Sms
{

    public interface IWFwSmsClient : ISmsClient
    {
        Task SendVerification(string code, int expireMin, params string[] phones);
    }

    public class WFwSmsClient : ISmsClient, IWFwSmsClient
    {
        private readonly SmsClient client;
        private readonly SmsOptions options;


        public WFwSmsClient(IServiceProvider sp) : this(sp.GetService<IOptions<TencentCloudOptions>>().Value.Sms)
        {
        }

        public WFwSmsClient(SmsOptions op)
        {
            options = op;
            client = new SmsClient(options.GetCredential(), options.Regin);

        }

        public Task<int> GetMessageRemaining()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phone"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public Task<(bool, string)> SendSms(string text, string phone, string templateId = "")
        {
            return Task.FromResult((false, "发送失败"));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="expireMin"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<(bool, string)> SendVerification(string code, int expireMin, string phone)
        {
            try
            {
                SendSmsRequest req = new SendSmsRequest
                {
                    PhoneNumberSet = new string[] { $"+86{phone}" },
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
                ////   logger.LogError(ex.ToLogMessage());

                return (false, ex.Message);
            }
        }

        public async Task SendVerification(string code, int expireMin, params string[] phones)
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

            }
            catch (Exception ex)
            {
                string[] p = new string[] {
                    //"bucket",values["bucket"].ToString(),
                    //"region",values["region"].ToString(),
                    //"allowPrefix",values["allowPrefix"].ToString(),
                    //"allowActions",string.Join(",", values["allowActions"] as string[]),
                    "phones",string.Join(",",phones),
                    "ex",ex.Message
                };

                throw new WFwException(Results.OperationResultType.TencentCloudSdkStsErr, "", p);
            }

        }
    }
}
