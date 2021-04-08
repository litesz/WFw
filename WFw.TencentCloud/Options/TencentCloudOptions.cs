using TencentCloud.Common;

namespace WFw.TencentCloud.Options
{
    /// <summary>
    /// 腾讯云SDK设置
    /// </summary>
    public class TencentCloudOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Position = "TencentCloud";

        /// <summary>
        /// SecretId
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// cos设置
        /// </summary>
        public CosOptions Cos { get; set; }

        /// <summary>
        /// 短信设置
        /// </summary>
        public SmsOptions Sms { get; set; }

        /// <summary>
        /// ocr
        /// </summary>
        public OcrOptions Ocr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Credential Credential => new Credential { SecretId = SecretId, SecretKey = SecretKey };
    }

    /// <summary>
    /// ocr
    /// </summary>
    public class OcrOptions
    {
        /// <summary>
        /// 区域
        /// </summary>
        public string Regin { get; set; } = "ap-guangzhou";
    }

    /// <summary>
    /// cos设置
    /// </summary>
    public class CosOptions
    {
        /// <summary>
        /// 区域
        /// </summary>
        public string Regin { get; set; } = "ap-shanghai";

        /// <summary>
        /// 桶
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// 持续时间
        /// </summary>
        public long DurationSec { get; set; } = 600;
    }

    /// <summary>
    /// 短信设置
    /// </summary>
    public class SmsOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Regin { get; set; } = "ap-guangzhou";

        /// <summary>
        /// 验证码
        /// </summary>
        public SmsTemplateOptions Verification { get; set; }
    }

    public class SmsTemplateOptions
    {

        /// <summary>
        /// 模板
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// SDK AppID 
        /// </summary>
        public string SmsSdkAppid { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }

}
