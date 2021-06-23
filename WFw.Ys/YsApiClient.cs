using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WFw.Ys.Dtos;
using WFw.Ys.Options;

namespace WFw.Ys
{
    public interface IYsApiClient
    {
        Task<ApiClientResult<AccessTokenData>> GetAccessToken();
        Task<ApiClientResult<GetAddressResponseData>> GetAddress(GetAddresRequest request);
    }

    public class YsApiClient : IYsApiClient
    {
        private readonly YsOptions ysOptions;
        private readonly HttpClient Client;
        public YsApiClient(HttpClient httpClient, IOptions<YsOptions> yso)
        {

            httpClient.BaseAddress = new Uri("https://open.ys7.com");
            Client = httpClient;
            ysOptions = yso.Value;
        }

        public async Task<ApiClientResult<AccessTokenData>> GetAccessToken()
        {
            StringContent content = new StringContent($"appKey={ysOptions.AppKey}&appSecret={ysOptions.AppSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await Client.PostAsync("/api/lapp/token/get", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("执行失败", "url", "/api/lapp/token/get");
            }

           
            return JsonExtensions.Deserialize<ApiClientResult<AccessTokenData>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiClientResult<GetAddressResponseData>> GetAddress(GetAddresRequest request)
        {
            StringContent content = new StringContent(request.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await Client.PostAsync("/api/lapp/v2/live/address/get", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("执行失败", "url", "/api/lapp/v2/live/address/get");
            }
            return JsonExtensions.Deserialize<ApiClientResult<GetAddressResponseData>>(await response.Content.ReadAsStringAsync());
        }
    }
}
