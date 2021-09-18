using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using COSXML.Transfer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFw.TencentCloud.Clients.Sts;
using WFw.TencentCloud.Options;

namespace WFw.TencentCloud.Clients.Cos
{

    public class WFwCosClient : IWFwCosClient
    {


        private readonly CosXml cosXml;
        private readonly CosOptions options;

        private readonly ILogger<WFwCosClient> logger;
        private QCloudCredentialProvider qCloudCredentialProvider;

        public WFwCosClient(IServiceProvider sp) : this(sp.GetService<IOptions<TencentCloudOptions>>().Value.Cos, sp.GetService<ILogger<WFwCosClient>>(), null)
        {
        }

        public WFwCosClient(CosOptions cos, ILogger<WFwCosClient> l, Func<TempCredentialResult> func)
        {

            options = cos;
            logger = l;

            CosXmlConfig config = new CosXmlConfig.Builder()
                 .SetRegion(options.Regin) //设置一个默认的存储桶地域
                 .Build();

            if (cos.UseTemp)
            {
                qCloudCredentialProvider = new CustomQCloudCredentialProvider(func);

            }
            else
            {
                qCloudCredentialProvider = new DefaultQCloudCredentialProvider(options.SecretId, options.SecretKey, options.DurationSec);

            }

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

        public bool DeleteObject(string key)
        {
            try
            {

                DeleteObjectRequest request = new DeleteObjectRequest(options.Bucket, key);
                //执行请求
                DeleteObjectResult result = cosXml.DeleteObject(request);
                //请求成功
                // Console.WriteLine(result.GetResultInfo());

                logger.LogInformation($"DeleteObject[{key}]:{result.GetResultInfo()}");

            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                logger.LogError(clientEx, $"DeleteObject");
                return false;
                //请求失败
                //Console.WriteLine("CosClientException: " + clientEx);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {

                logger.LogError(serverEx, $"DeleteObject");
                return false;
                //请求失败
                // Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }

            return true;
        }

        public bool DeleteMutiObjects(List<string> keys)
        {


            try
            {
                //存储桶，格式：BucketName-APPID
                DeleteMultiObjectRequest request = new DeleteMultiObjectRequest(options.Bucket);
                //设置返回结果形式
                request.SetDeleteQuiet(false);
                //对象key

                //List<string> objects = new List<string>();
                //objects.Add(key);
                request.SetObjectKeys(keys);
                //执行请求
                DeleteMultiObjectResult result = cosXml.DeleteMultiObjects(request);
                //请求成功
                //   Console.WriteLine(result.GetResultInfo());

                logger.LogInformation($"DeleteMutiObjects[{string.Join("|", keys)}]:{result.GetResultInfo()}");
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                logger.LogError(clientEx, $"DeleteObject");
                return false;
                //请求失败
                //Console.WriteLine("CosClientException: " + clientEx);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {

                logger.LogError(serverEx, $"DeleteObject");
                return false;
                //请求失败
                // Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }

            return true;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">对象在存储桶中的位置标识符，即称对象键</param>
        /// <param name="localDir">本地文件夹</param>
        /// <param name="localFileName">指定本地保存的文件名</param>
        /// <returns></returns>
        public COSXMLDownloadTask GetDownloadTask(string key, string localDir, string localFileName)
        {
            // 下载对象
            COSXMLDownloadTask downloadTask = new COSXMLDownloadTask(options.Bucket, key, localDir, localFileName);
            //downloadTask.progressCallback = delegate (long completed, long total)
            //{
            //    Console.WriteLine(String.Format("progress = {0:##.##}%", completed * 100.0 / total));
            //};

            return downloadTask;
        }

        public async Task DownloadObject(string key, string localDir, string localFileName)
        {

            var downloadTask = GetDownloadTask(key, localDir, localFileName);


            // 初始化 TransferConfig
            TransferConfig transferConfig = new TransferConfig();

            // 初始化 TransferManager
            TransferManager transferManager = new TransferManager(cosXml, transferConfig);


            try
            {
                COSXML.Transfer.COSXMLDownloadTask.DownloadTaskResult result = await transferManager.DownloadAsync(downloadTask);

                string eTag = result.eTag;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToLogMessage());
            }



        }

    }
}
