using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.Ys;

namespace Example.Controllers
{
    public class YsController : Controller
    {
        private readonly IYsApiClient apiClient;
        public YsController(IYsApiClient ysApiClient)
        {
            apiClient = ysApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<string> GetAccessToken()
        {
            return (await apiClient.GetAccessToken()).Data.AccessToken;
        }


        public async Task<string> GetAddress(string accessToken)
        {
            var r = await apiClient.GetAddress(new WFw.Ys.Dtos.GetAddresRequest
            {
                AccessToken = accessToken,
                DeviceSerial = "247519596"
            });
            return r.Data.Url;
        }
    }
}
