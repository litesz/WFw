using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using WFw.Mp.Options;
using WFw.Tencent;

namespace WFw.Mp
{

    public partial class WFwMpApiHttpClient : BaseTencentApiHttpClient, IWFwMpApiHttpClient
    {
        private readonly MpOptions options;


        public WFwMpApiHttpClient(HttpClient httpClient, IServiceProvider sp) : base(httpClient)
        {
            options = sp.GetService<IOptions<MpOptions>>().Value;
        }


       
    }
}
