using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace WFw.Http.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsChineseService : ISmsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _key;
        private readonly string _uid;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        public SmsChineseService(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _key = configuration["Sms:Key"];
            _uid = configuration["Sms:Uid"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Task<string> Send(string phone, string msg)
        {
            var requestUri = $"/?Uid={_uid}&Key={_key}&smsMob={phone}&smsText={msg}";

            return _httpClient.GetStringAsync(requestUri);
        }

    }
}
