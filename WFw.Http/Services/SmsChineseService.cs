using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace WFw.Http.Services
{
    public class SmsChineseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _key;
        private readonly string _uid;
        public SmsChineseService(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _key = configuration["Sms:Key"];
            _uid = configuration["Sms:Uid"];
        }

        public Task<string> Send(string phone, string msg, string key)
        {
            var requestUri = $"/?Uid={_uid}&Key={_key}&smsMob={phone}&smsText={msg}";

            return _httpClient.GetStringAsync(requestUri);
        }

    }
}
