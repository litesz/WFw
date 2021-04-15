using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{
    public class StsOptions : ITencentSecret
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
       
    }

}
