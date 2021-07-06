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
            accessToken = "at.c44z5jxqbggfun9s1ccah76f7bjt0d1u-3nqagccksn-13kxqpx-jl3jvw6oo";
            //var r = await apiClient.GetAddress(new WFw.Ys.Dtos.GetAddresRequest
            //{
            //    AccessToken = accessToken,
            //    DeviceSerial = "247519475"
            //});


            //var r1 = await apiClient.UpdateName(new WFw.Ys.Dtos.UpdateNameRequestDto
            //{

            //    AccessToken = accessToken,
            //    DeviceSerial = "C82517761",
            //    DeviceName = "办公室测试"
            //});


            //var r1 = await apiClient.DecryptCamera(new WFw.Ys.Dtos.DecryptCameraRequestDto
            //{
            //    AccessToken = accessToken,
            //    DeviceSerial = "C82517761",
            //    ValidateCode = "TBOHLM"
            //});
            var xxx = await apiClient.AddDevice(new WFw.Ys.Dtos.AddDeviceRequestDto
            {
                AccessToken = accessToken,
                DeviceSerial = "C82517761",
                ValidateCode = "TBOHLM"
            });
            return "";
            //return r.Data.Url;
        }
    }
}
