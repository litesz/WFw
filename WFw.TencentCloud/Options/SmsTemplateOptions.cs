﻿using WFw.ISms;

namespace WFw.TencentCloud.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsTemplateOptions : ISmsTemplate
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
