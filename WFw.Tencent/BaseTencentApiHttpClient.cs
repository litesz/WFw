using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
            T output = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            if (output.Errcode != 0)
            {
                throw new TencentHttpException(url, output);
            }
            return output;

        }


        protected async Task<T> Post<T>(string url, string postData) where T : BaseResponse
        {
            var response = await Client.PostAsync(url, new StringContent(postData));
            T output = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            if (output.Errcode != 0)
            {
                throw new TencentHttpException(url, postData, output);
            }
            return output;
        }

    }
}
