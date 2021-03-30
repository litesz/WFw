using System;
using System.Net.Http;
using System.Threading.Tasks;
using WFw.Tencent.Responses;

namespace WFw.Tencent
{
    public abstract class BaseTencentApiHttpClient
    {
        private HttpClient Client;
        public BaseTencentApiHttpClient(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://api.weixin.qq.com/");
            Client = httpClient;
        }


        protected async Task<T> Get<T>(string url) where T : BaseResponse
        {
            var response = await Client.GetAsync(url);
            T output = JsonExtensions.Deserialize<T>(await response.Content.ReadAsStringAsync());

            if (output.Errcode != 0)
            {
                throw new TencentHttpException(url, output);
            }
            return output;

        }


        protected async Task<T> Post<T>(string url, string postData) where T : BaseResponse
        {
            var response = await Client.PostAsync(url, new StringContent(postData));
            T output = JsonExtensions.Deserialize<T>(await response.Content.ReadAsStringAsync());

            if (output.Errcode != 0)
            {
                throw new TencentHttpException(url, postData, output);
            }
            return output;
        }

        protected Task<T> Post<T>(string url, object data) where T : BaseResponse
        {
            return Post<T>(url, JsonExtensions.Serialize(data));
        }

    }
}
