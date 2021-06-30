using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WFw.Ys.Dtos;
using WFw.Ys.Options;
using WFw.Ys.Utils;

namespace WFw.Ys
{
    public interface IYsApiClient
    {
        Task<ApiClientResult<AccessTokenData>> GetAccessToken();
        Task<ApiClientResult<GetAddressResponseData>> GetAddress(GetAddresRequest request);
        Task<(bool isOk, string msg)> DecryptCamera(DecryptCameraRequestDto requestDto);
        Task<(bool isOk, string msg)> EncryptCamera(EncryptCameraRequestDto requestDto);
        Task<(bool isOk, string msg)> UpdateName(UpdateNameRequestDto requestDto);
    }


    public class YsApiClient : IYsApiClient
    {
        readonly YsOptions ysOptions;
        readonly HttpClient Client;
        public YsApiClient(HttpClient httpClient, IOptions<YsOptions> yso)
        {

            httpClient.BaseAddress = new Uri("https://open.ys7.com");
            Client = httpClient;
            ysOptions = yso.Value;
        }


        StringContent GenerateStringContent<T>(T obj) where T : new()
        {

            return new StringContent(Properties<T>.ConvertToString(obj), Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        public async Task<ApiClientResult<AccessTokenData>> GetAccessToken()
        {
            if (string.IsNullOrWhiteSpace(ysOptions.AppKey) || string.IsNullOrWhiteSpace(ysOptions.AppSecret))
            {
                throw new WFwIsEmptyException($"{nameof(ysOptions.AppKey)}或{nameof(ysOptions.AppSecret)}");
            }

            StringContent content = new StringContent($"appKey={ysOptions.AppKey}&appSecret={ysOptions.AppSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await Client.PostAsync("/api/lapp/token/get", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("刷新accessToken网络请求失败", "响应", await response.Content.ReadAsStringAsync());
            }


            return JsonExtensions.Deserialize<ApiClientResult<AccessTokenData>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiClientResult<GetAddressResponseData>> GetAddress(GetAddresRequest request)
        {
            //StringContent content = new StringContent(request.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await Client.PostAsync("/api/lapp/v2/live/address/get", GenerateStringContent(request));

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("查询播放地址网络请求失败", "响应", await response.Content.ReadAsStringAsync());
            }
            return JsonExtensions.Deserialize<ApiClientResult<GetAddressResponseData>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool isOk, string msg)> DecryptCamera(DecryptCameraRequestDto requestDto)
        {
            var response = await Client.PostAsync("/api/lapp/device/encrypt/off", GenerateStringContent(requestDto));

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("摄像机直播解密网络请求失败", "响应", await response.Content.ReadAsStringAsync());
            }
            var r = JsonExtensions.Deserialize<ApiClientResult>(await response.Content.ReadAsStringAsync());
            if (r.IsSuccess || r.Code == 60016)
            {
                return (true, "");
            }
            return (false, r.Msg);
        }


        public async Task<(bool isOk, string msg)> EncryptCamera(EncryptCameraRequestDto requestDto)
        {
            var response = await Client.PostAsync("/api/lapp/device/encrypt/on", GenerateStringContent(requestDto));

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("摄像机直播加密网络请求失败", "响应", await response.Content.ReadAsStringAsync());
            }
            var r = JsonExtensions.Deserialize<ApiClientResult>(await response.Content.ReadAsStringAsync());
            if (r.IsSuccess || r.Code == 60016)
            {
                return (true, "");
            }
            return (false, r.Msg);
        }




        public async Task<(bool isOk, string msg)> UpdateName(UpdateNameRequestDto requestDto)
        {

            var response = await Client.PostAsync("/api/lapp/device/name/update", GenerateStringContent(requestDto));

            if (!response.IsSuccessStatusCode)
            {
                throw new WFwException("更新摄像机平台名称网络请求失败", "响应", await response.Content.ReadAsStringAsync());
            }
            var r = JsonExtensions.Deserialize<ApiClientResult>(await response.Content.ReadAsStringAsync());
            if (r.IsSuccess)
            {
                return (true, "");
            }
            return (false, r.Msg);
        }

    }
}
