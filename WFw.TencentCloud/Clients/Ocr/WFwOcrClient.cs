using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Ocr.V20181119;
using TencentCloud.Ocr.V20181119.Models;
using WFw.TencentCloud.Options;

namespace WFw.TencentCloud.Clients.Ocr
{

    public interface IWFwOcrClient
    {

        Task<BizLicenseOCRResponse> BizLicenseOCR(string imageUrl);
    }

    public class WFwOcrClient : IWFwOcrClient
    {

       
        private readonly OcrClient client;

        public WFwOcrClient(IServiceProvider sp) : this(sp.GetService<IOptions<TencentCloudOptions>>().Value.Ocr)
        {
        }

        public WFwOcrClient(OcrOptions ocr)
        {
          
            Credential cred = new Credential
            {
                SecretId = ocr.SecretId,
                SecretKey = ocr.SecretKey
            };

            client = new OcrClient(cred, ocr.Regin);
        }



        public async Task<BizLicenseOCRResponse> BizLicenseOCR(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                throw new WFw.WFwException(Results.OperationResultType.IsEmpty, "图片路径", "");
            }

            try
            {

                return await client.BizLicenseOCR(new BizLicenseOCRRequest
                {
                    ImageUrl = imageUrl
                });

            }
            catch (TencentCloudSDKException tce)
            {
                var x = tce.Message.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                //throw new WFwException(Results.OperationResultType.TencentHttpErr, x.Last(), $"TRequestId={tce.RequestId};imageUrl={imageUrl}");
                throw new WFwException(Results.OperationResultType.TencentHttpErr, x.Last(), "TRequestId", tce.RequestId, "imageUrl", imageUrl);
            }



        }

    }
}
