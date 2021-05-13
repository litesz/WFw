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
        /// 生成临时密钥
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="region"></param>
        /// <param name="allowPrefix"></param>
        /// <param name="allowActions"></param>
        /// <param name="durationSeconds"></param>
        /// <returns></returns>
        TempCredentialResult GetTempCredential(string bucket, string region, string allowPrefix, string[] allowActions, int durationSeconds = 7200);

        /// <summary>
        /// 默认action设置生成临时密钥
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="region"></param>
        /// <param name="allowPrefix"></param>
        /// <param name="durationSeconds"></param>
        /// <returns></returns>
        TempCredentialResult GetDefaultTempCredential(string bucket, string region, string allowPrefix, int durationSeconds = 7200);
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


        private TempCredentialResult GenTempCredential(Dictionary<string, object> values)
        {



            try
            {
                Dictionary<string, object> credential = STSClient.genCredential(values);

                TempCredentialResult output = new TempCredentialResult
                {
                    Bucket = values["bucket"].ToString(),
                    Region = values["region"].ToString()
                };
                IList<string> errs = new List<string>();
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
                            else
                            {
                                errs.Add("ExpiredTime");
                                errs.Add("kvp.Value.ToString()");
                                // logger.LogError($"ExpiredTime:{kvp.Value}");
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
                                errs.Add("StartTime");
                                errs.Add("kvp.Value.ToString()");
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

                string[] p = new string[] {
                    "bucket",values["bucket"].ToString(),
                    "region",values["region"].ToString(),
                    "allowPrefix",values["allowPrefix"].ToString(),
                    "allowActions",string.Join(",", values["allowActions"] as string[]),
                    "ex",ex.Message
                };

                throw new WFwException(Results.OperationResultType.TencentCloudSdkStsErr, "", p);
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
            if (string.IsNullOrWhiteSpace(bucket))
            {
                throw new WFwException(Results.OperationResultType.IsEmpty, "bucket");
            }
            if (string.IsNullOrWhiteSpace(region))
            {
                throw new WFwException(Results.OperationResultType.IsEmpty, "region");
            }
            if (string.IsNullOrWhiteSpace(allowPrefix))
            {
                throw new WFwException(Results.OperationResultType.IsEmpty, "allowPrefix");
            }
            if (allowActions == null || allowActions.Length == 0)
            {
                throw new WFwException(Results.OperationResultType.IsEmpty, "allowActions");
            }
            if (durationSeconds < 1 || durationSeconds > 129600)
            {
                throw new WFwException(Results.OperationResultType.IsErr, "持续时间错误", nameof(durationSeconds), durationSeconds.ToString());
            }

            Dictionary<string, object> values = new Dictionary<string, object>
            {
                { "bucket", bucket },
                { "region", region },
                { "allowPrefix", allowPrefix },
                { "allowActions", allowActions },
                { "durationSeconds", durationSeconds },
                { "secretId", options.SecretId },
                { "secretKey", options.SecretKey }
            };




            return GenTempCredential(values);
        }

        public TempCredentialResult GetDefaultTempCredential(string bucket, string region, string allowPrefix, int durationSeconds = 7200)
        {


            //string allowPrefix = "*"; // 这里改成允许的路径前缀，可以根据自己网站的用户登录态判断允许上传的具体路径，例子： a.jpg 或者 a/* 或者 * (使用通配符*存在重大安全风险, 请谨慎评估使用)
            string[] allowActions = new string[] {  // 允许的操作范围，这里以上传操作为例
                "name/cos:PutObject",
                    "name/cos:PostObject",
                    "name/cos:InitiateMultipartUpload",
                    "name/cos:ListMultipartUploads",
                    "name/cos:ListParts",
                    "name/cos:UploadPart",
                    "name/cos:CompleteMultipartUpload",
                    "name/cos:HeadObject",//判断指定对象是否存在和有权限
                    "name/cos:GetObject"//下载对象
            };

            return GetTempCredential(bucket, region, allowPrefix, allowActions, durationSeconds);

        }




    }
}
