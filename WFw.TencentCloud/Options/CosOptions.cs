using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{
    /// <summary>
    /// cos设置
    /// </summary>
    public class CosOptions : ITencentRegion
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Position = "Cos";

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

        /// <summary>
        /// SecretId
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 使用临时密钥
        /// </summary>
        public bool UseTemp { get; set; }
    }

}
