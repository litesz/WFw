using System;

namespace WFw.TencentCloud.Clients.Sts
{
    /// <summary>
    /// 
    /// </summary>
    public class TempCredentialResult
    {
        /// <summary>
        /// 
        /// </summary>
        public TempCredential Credential { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Expiration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ExpiredTime { get; set; }

        public string RequestId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Region { get; set; }
    }
}
