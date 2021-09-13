using COSXML.Auth;
using System;
using WFw.TencentCloud.Clients.Sts;

namespace WFw.TencentCloud.Clients.Cos
{
    public class CustomQCloudCredentialProvider : DefaultSessionQCloudCredentialProvider
    {
        private readonly Func<TempCredentialResult> GetTempFunc;
        // 这里假设开始没有密钥，也可以用初始的临时密钥来初始化
        public CustomQCloudCredentialProvider(Func<TempCredentialResult> func) : base(null, null, 0L, null)
        {
            GetTempFunc = func;
        }

        public override void Refresh()
        {
            //... 首先通过腾讯云请求临时密钥

            var result = GetTempFunc?.Invoke();
            if (result == null)
            {
                return;
            }

            //string tmpSecretId = "COS_SECRETID"; //"临时密钥 SecretId";
            //string tmpSecretKey = "COS_SECRETKEY"; //"临时密钥 SecretKey";
            //string tmpToken = "COS_TOKEN"; //"临时密钥 token";
            //long tmpStartTime = 1546860702;//临时密钥有效开始时间，精确到秒
            //long tmpExpiredTime = 1546862502;//临时密钥有效截止时间，精确到秒
            //                                 // 调用接口更新密钥
            SetQCloudCredential(result.Credential.TmpSecretId, result.Credential.TmpSecretKey,
              String.Format("{0};{1}", result.StartTime, result.ExpiredTime), result.Credential.Token);
        }
    }
}
