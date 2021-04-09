using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{
    /// <summary>
    /// 短信设置
    /// </summary>
    public class SmsOptions: ITencentRegion
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Position = "Sms";

        /// <summary>
        /// SecretId
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Regin { get; set; } = "ap-guangzhou";

        /// <summary>
        /// 验证码
        /// </summary>
        public SmsTemplateOptions Verification { get; set; }
    }

}
