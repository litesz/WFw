using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TencentCloud.Sms.V20190711;
using TencentCloud.Sms.V20190711.Models;
using WFw.ISms;
using WFw.TencentCloud.Exceptions;
using WFw.TencentCloud.Options;
using WFw.Utils;

namespace WFw.TencentCloud.Clients.Sms
{

    public class WFwSmsClient : ISmsClient, IWFwSmsClient
    {
        readonly SmsClient _client;
        readonly SmsOptions _options;

        public WFwSmsClient(IServiceProvider sp) : this(sp.GetService<IOptions<TencentCloudOptions>>().Value.Sms)
        {
        }

        public WFwSmsClient(SmsOptions op)
        {
            _options = op;
            _client = new SmsClient(_options.GetCredential(), _options.Regin);
        }

        public Task<int> GetMessageRemaining()
        {
            throw new NotImplementedException();
        }

        public async Task SendMsg(string[] phones, IList<KeyValuePair<string, string>> values, ISmsTemplate template = null)
        {
            ParamCheck.NotNull(template, "签名模板Id设置");
            SendSmsRequest req = new SendSmsRequest
            {
                PhoneNumberSet = phones.Select(u => $"+86{u}").ToArray(),
                SmsSdkAppid = template.SmsSdkAppid,
                TemplateID = template.TemplateId,
                TemplateParamSet = values.Select(u => u.Value).ToArray(),
                Sign = template.Sign,
            };

            SendSmsResponse resp = await _client.SendSms(req);
            WFwTencentCloudSdkException we = null;

            foreach (var item in resp.SendStatusSet)
            {

                if (item.Code != "Ok")
                {
                    if (we == null)
                    {
                        we = new WFwTencentCloudSdkException("短信发送异常");
                        we.AddData(nameof(resp.RequestId), resp.RequestId);
                    }
                    we.AddData($"{ item.PhoneNumber}-{ nameof(item.Code)}", item.Code);
                    we.AddData($"{ item.PhoneNumber}-{ nameof(item.Message)}", item.Message);
                    we.AddData($"{ item.PhoneNumber}-{ nameof(item.SerialNo)}", item.SerialNo);
                }
            }
            if (we != null)
            {
                throw we;
            }
        }


        public Task SendVerificationCode(string phone, string code, int expireMin, ISmsTemplate template = null)
        {
            ParamCheck.IsGreaterThan(expireMin, "过期时长", 1);

            return SendMsg(new string[] { phone },
                new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>(SmsClientConst.KEY_CODE,code),
                    new KeyValuePair<string, string>(SmsClientConst.KEY_EXPIREMIN,expireMin.ToString()),
                },
                template ?? _options.Verification);
        }
    }
}
