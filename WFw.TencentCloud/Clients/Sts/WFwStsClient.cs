using COSSTS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WFw.TencentCloud.Options;

namespace WFw.TencentCloud.Clients.Sts
{

    /// <summary>
    /// 
    /// </summary>
    public interface IWFwStsClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="region"></param>
        /// <param name="allowPrefix"></param>
        /// <param name="allowActions"></param>
        /// <param name="durationSeconds"></param>
        /// <returns></returns>
        TempCredentialResult GetTempCredential(string bucket, string region, string allowPrefix, string[] allowActions, int durationSeconds = 7200);
    }

    /// <summary>
    /// 
    /// </summary>
    public class WFwStsClient : IWFwStsClient
    {

        private readonly StsOptions options;
        private readonly ILogger<WFwStsClient> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        public WFwStsClient(IServiceProvider sp)
        {
            options = sp.GetService<IOptions<TencentCloudOptions>>().Value.Sts;
            logger = sp.GetService<ILogger<WFwStsClient>>();
        }

        public WFwStsClient(StsOptions stsOptions, ILogger<WFwStsClient> l)
        {
            options = stsOptions;
            logger = l;
        }


        private TempCredentialResult GetTempCredential(Dictionary<string, object> values)
        {
            try
            {
                Dictionary<string, object> credential = STSClient.genCredential(values);

                TempCredentialResult output = new TempCredentialResult();
                output.Bucket = values["bucket"].ToString();
                foreach (KeyValuePair<string, object> kvp in credential)
                {
                    switch (kvp.Key)
                    {
                        case "Credentials":
                            output.Credential = JsonExtensions.Deserialize<TempCredential>(kvp.Value.ToString());
                            break;
                        case "ExpiredTime":


                            if (long.TryParse(kvp.Value.ToString(), out long et))
                            {
                                output.ExpiredTime = et;
                            }
                            else {
                                logger.LogError($"ExpiredTime:{kvp.Value}");
                            }

                            output.Expiration = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddSeconds(output.ExpiredTime);
                            break;
                        case "StartTime":

                            if (long.TryParse(kvp.Value.ToString(), out long st))
                            {
                                output.StartTime = st;
                            }
                            else
                            {
                                logger.LogError($"StartTime:{kvp.Value}");
                            }
                            break;
                        case "RequestId": output.RequestId = kvp.Value.ToString(); break;
                            //case "Expiration": output.Expiration = JsonConvert.DeserializeObject<DateTimeOffset>(kvp.Value.ToString()); break;
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "GetTempCredential");
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="region"></param>
        /// <param name="allowPrefix"></param>
        /// <param name="allowActions"></param>
        /// <param name="durationSeconds"></param>
        /// <returns></returns>
        public TempCredentialResult GetTempCredential(string bucket, string region, string allowPrefix, string[] allowActions, int durationSeconds = 7200)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("bucket", bucket);
            values.Add("region", region);
            values.Add("allowPrefix", allowPrefix);
            values.Add("allowActions", allowActions);
            values.Add("durationSeconds", durationSeconds);
            values.Add("secretId", options.SecretId);
            values.Add("secretKey", options.SecretKey);

            return GetTempCredential(values);
        }

        private void GetTempCredential(string bucket, string region)
        {

            //string bucket = "examplebucket-1253653367";  // 您的 bucket
            //string region = "ap-guangzhou";  // bucket 所在区域
            string allowPrefix = "*"; // 这里改成允许的路径前缀，可以根据自己网站的用户登录态判断允许上传的具体路径，例子： a.jpg 或者 a/* 或者 * (使用通配符*存在重大安全风险, 请谨慎评估使用)
            string[] allowActions = new string[] {  // 允许的操作范围，这里以上传操作为例
                "name/cos:PutObject",
                "name/cos:PostObject",
                "name/cos:InitiateMultipartUpload",
                "name/cos:ListMultipartUploads",
                "name/cos:ListParts",
                "name/cos:UploadPart",
                "name/cos:CompleteMultipartUpload"
            };
            // Demo 这里是从环境变量读取，如果是直接硬编码在代码中，请参考：
            // string secretId = "AKIDXXXXXXXXX";
            string secretId = options.SecretId; // 云 API 密钥 Id
            string secretKey = options.SecretKey; // 云 API 密钥 Key
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("bucket", bucket);
            values.Add("region", region);
            values.Add("allowPrefix", allowPrefix);
            // 也可以通过 allowPrefixes 指定路径前缀的集合
            // values.Add("allowPrefixes", new string[] {
            //     "path/to/dir1/*",
            //     "path/to/dir2/*",
            // });
            values.Add("allowActions", allowActions);
            values.Add("durationSeconds", 1800);

            values.Add("secretId", secretId);
            values.Add("secretKey", secretKey);

            Dictionary<string, object> credential = STSClient.genCredential(values);
            foreach (KeyValuePair<string, object> kvp in credential)
            {
                Console.WriteLine("{0} = {1}", kvp.Key, kvp.Value);
            }

        }




    }
}
