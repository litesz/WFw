using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WFw.TencentCloud.Options;

namespace WFw.TencentCloud.Cos
{

    public interface IWFwCosClient
    {

    }

    public class WFwCosClient : IWFwCosClient
    {


        private CosXml cosXml;
        private readonly CosOptions options;

        private readonly ILogger<WFwCosClient> logger;
        public WFwCosClient(IOptions<TencentCloudOptions> op, ILogger<WFwCosClient> l)
        {

            options = op.Value.Cos;
            logger = l;

            CosXmlConfig config = new CosXmlConfig.Builder()
                 .SetRegion(options.Regin) //设置一个默认的存储桶地域
                 .Build();

            QCloudCredentialProvider qCloudCredentialProvider = new DefaultQCloudCredentialProvider(op.Value.SecretId, op.Value.SecretKey, options.DurationSec);

            cosXml = new CosXmlServer(config, qCloudCredentialProvider);

        }


        public bool TransferUploadBytes(string cosPath, byte[] data, string filename = "", bool isAttachment = false)
        {
            //.cssg-snippet-body-start:[transfer-upload-bytes]
            try
            {
                PutObjectRequest putObjectRequest = new PutObjectRequest(options.Bucket, cosPath, data);

                if (!string.IsNullOrWhiteSpace(filename))
                {
                    putObjectRequest.SetRequestHeader("Content-Disposition", $"{(isAttachment ? "attachment" : "inline")}; filename={System.Web.HttpUtility.UrlEncode(filename)}");
                }

                var r = cosXml.PutObject(putObjectRequest);

                if (r.IsSuccessful())
                {
                    return true;
                }

                logger.LogError(r.httpMessage);
                return false;

                //throw new BadRequestException(WFw.Results.OperationResultType.IsErr, r.httpMessage);

            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                logger.LogError(clientEx, $"CosClientException");

                return false;
                // throw new BadRequestException(WFw.Results.OperationResultType.IsErr, clientEx.ToString());
                //请求失败
                //Console.WriteLine("CosClientException: " + clientEx);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                logger.LogError(serverEx, $"TransferUploadBytes");
                //请求失败
                //Console.WriteLine("CosServerException: " + serverEx.GetInfo());
                //throw new BadRequestException(WFw.Results.OperationResultType.IsErr, serverEx.GetInfo());
                return false;
            }
        }

      
    }
}
