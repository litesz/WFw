using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.TencentCloud.Clients.Ocr;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {

        private IWFwOcrClient client;

        public OcrController(IWFwOcrClient smsClient)
        {
            client = smsClient;
        }


        [HttpGet("BizLicense/{imageUrl}")]
        public async Task<IActionResult> BizLicenseOCR(string imageUrl)
        {
            return Ok(await client.BizLicenseOCR("https://pr-1257987244.cos.ap-shanghai.myqcloud.com/certificates/ff7c17321fcfa67219ce63569f0a4746/f966b80169d647a9ab225be0aeb573cb.jpg"));
        }


    }
}
