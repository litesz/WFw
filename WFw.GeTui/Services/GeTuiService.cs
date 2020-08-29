using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WFw.GeTui.Models;
using WFw.GeTui.Models.Auth;
using WFw.GeTui.Models.Options;
using WFw.GeTui.Stores;

namespace WFw.GeTui.Services
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GeTuiService : IGeTuiService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly GeTuiTokenStore _tokenStore;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// 
        /// </summary>
        private readonly PushOptions _pushOptions;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        /// <param name="tokenStore"></param>
        public GeTuiService(HttpClient client, IOptions<PushOptions> options, GeTuiTokenStore tokenStore)
        {
            _httpClient = client;
            _pushOptions = options.Value;
            _tokenStore = tokenStore;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task LoadToken(bool isRefresh = false)
        {
            if (!isRefresh && !_tokenStore.IsExpire)
            {
                return;
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DeleteToken()
        {
            if (string.IsNullOrWhiteSpace(_tokenStore.Token))
            {
                await LoadToken();
            }

            await DeleteAsync($"auth/${_tokenStore.Token}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task<string> PostAsync(string url, object body)
        {
            var bodyJson = new StringContent(JsonExtensions.SerializeByCamelCase(body), Encoding.UTF8, "application/json");

            bodyJson.Headers.Add("token", _tokenStore.Token);

            var response = await _httpClient.PostAsync($"{_pushOptions.AppId}/{url}", bodyJson);

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }

            return content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task PostAndCheckCodeAsync(string url, object body)
        {
            var content = await PostAsync(url, body);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task<T> PostAndReturnAsync<T>(string url, object body)
        {
            var content = await PostAsync(url, body);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<T>>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }
            return result.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_pushOptions.AppId}/{url}");
            request.Headers.Add("token", _tokenStore.Token);
            var response = await _httpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(content);
            if (result.Code != 0)
            {
                throw new ArgumentOutOfRangeException($"$[${result.Code}]:{result.Msg}");
            }
            return content;
            //
            // var startIndex = content.IndexOf("{", 1);
            //return content.Substring(startIndex + 1, content.Length - startIndex - 3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(string url)
        {
            var jTokens = await GetJTokensAsync(url);
            var content = jTokens.FirstOrDefault();
            if (content == null)
            {
                return default;
            }
            return content.ToObject<T>();
        }

        /// <summary>
        /// 查询data节点文本
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetDataStrAsync(string url)
        {

            var content = await GetAsync(url);

            return content.GetSelectedSection("data");
        }

        /// <summary>
        /// 查询jtoken
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<IJEnumerable<JToken>> GetJTokensAsync(string url)
        {

            var content = await GetDataStrAsync(url);

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("查询结果解码失败");
            }

            return JObject.Parse(content).Values();

        }

    }
}
