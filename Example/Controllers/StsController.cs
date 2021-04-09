using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.TencentCloud.Clients.Cos;
using WFw.TencentCloud.Clients.Sts;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StsController : ControllerBase
    {

        private readonly IWFwStsClient stsClient;
        private readonly IWFwCosClient cosClient;

        public StsController(IWFwStsClient wFwStsClient, IWFwCosClient wFwCosClient)
        {
            stsClient = wFwStsClient;
            cosClient = wFwCosClient;
        }

        public IActionResult Get()
        {
            int durationSeconds = 7200;
            string bucket = "xc-1257987244";  // 您的 bucket
            string region = "ap-shanghai";  // bucket 所在区域
            string allowPrefix = "*"; // 这里改成允许的路径前缀，可以根据自己网站的用户登录态判断允许上传的具体路径，例子： a.jpg 或者 a/* 或者 * (使用通配符*存在重大安全风险, 请谨慎评估使用)
            string[] allowActions = new string[] {  // 允许的操作范围，这里以上传操作为例
                    "name/cos:PutObject",
                    "name/cos:PostObject",
                    "name/cos:InitiateMultipartUpload",
                    "name/cos:ListMultipartUploads",
                    "name/cos:ListParts",
                    "name/cos:UploadPart",
                    "name/cos:CompleteMultipartUpload",
                    "name/cos:GetObject"//下载对象
                };

            return Ok(stsClient.GetTempCredential(bucket, region, allowPrefix, allowActions, durationSeconds));

        }

        

    }
}
