using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{
    public class StsOptions : ITencentRegion
    {

        /// <summary>
        /// 
        /// </summary>
        public const string Position = "Sts";

        /// <summary>
        /// SecretId
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Regin { get; set; } = "ap-guangzhou";
        /// <summary>
        /// 
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DurationSeconds { get; set; } = 7200;
    }

}
