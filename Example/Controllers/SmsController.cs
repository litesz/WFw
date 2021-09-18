using Example.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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

        public async Task<IActionResult> GetNum()
        {



            return Ok(await client.GetMessageRemaining());
        }

        public async Task<IActionResult> Send(SmsViewModel model)
        {
            try
            {
                await client.SendVerificationCode(model.Phone, model.Code, 10);
                //var (isSucc, errMsg) = await client.SendVerification(model.Code, 10, model.Phone);

                //ModelState.AddModelError("", errMsg);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.ToString());
            }

            return View("Index", model);
        }
    }
}
