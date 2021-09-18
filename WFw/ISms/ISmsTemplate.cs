namespace WFw.ISms
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISmsTemplate
    {

        /// <summary>
        /// 模板
        /// </summary>
        string TemplateId { get; set; }

        /// <summary>
        /// SDK AppID 
        /// </summary>
        string SmsSdkAppid { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        string Sign { get; set; }
    }
}
