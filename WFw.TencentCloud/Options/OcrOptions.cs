using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{
    /// <summary>
    /// ocr
    /// </summary>
    public class OcrOptions: ITencentRegion
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Position = "Ocr";

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


       
    }

}
