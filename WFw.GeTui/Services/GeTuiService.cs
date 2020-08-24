using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WFw.GeTui.Models;
using WFw.GeTui.Models.Auth;
using WFw.GeTui.Models.Options;
using WFw.GeTui.Stores;

namespace WFw.GeTui.Services
{

    public partial class GeTuiService : IGeTuiService
    {


        private readonly GeTuiTokenStore _tokenStore;

        private readonly HttpClient _httpClient;
        private readonly PushOptions _pushOptions;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        public GeTuiService(HttpClient client, IOptions<PushOptions> options, GeTuiTokenStore tokenStore)
        {
            _httpClient = client;
            _pushOptions = options.Value;
            _tokenStore = tokenStore;
        }

        public async Task LoadToken()
        {
            var response = await _httpClient.PostAsJsonAsync($"{_pushOptions.AppId}/auth", new AuthRequest(_pushOptions));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<AuthResponseData>>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }

            _tokenStore.Token = result.Data.Token;
            _tokenStore.Expire = result.Data.Expire.ToDateTime();
        }

        public async Task DeleteToken()
        {
            if (string.IsNullOrWhiteSpace(_tokenStore.Token))
            {
                await LoadToken();
            }

            await DeleteAsync($"auth/${_tokenStore.Token}");
        }


        private async Task PostAsync<T>(string url, object body)
        {
            var bodyJson = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            bodyJson.Headers.Add("token", _tokenStore.Token);

            var response = await _httpClient.PostAsync($"{_pushOptions.AppId}/{url}", bodyJson);

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<T>>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }
        }

        private async Task DeleteAsync(string url)
        {

            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_pushOptions.AppId}/{url}");
            request.Headers.Add("token", _tokenStore.Token);
            var response = await _httpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<bool>>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }
        }



    }
}
