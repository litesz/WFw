using Example.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.Http.Services;
using WFw.ISms;

namespace Example.Controllers
{
    public class SmsController : Controller
    {
        private ISmsClient client;

        public SmsController(ISmsClient smsClient)
        {
            client = smsClient;
            //  ((SmsChineseApiClient)smsClient).GetRemain();

        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Send(SmsViewModel model)
        {
            try
            {

                var (isSucc, errMsg) = await client.SendVerification(model.Code, 10, model.Phone);

                ModelState.AddModelError("", errMsg);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.ToString());
            }

            return View("Index", model);
        }
    }
}
