using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Mp.Options
{
    /// <summary>
    /// 设置
    /// </summary>
    public class MpOptions
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public const string Position = "MpOptions";

        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 网页跳转url
        /// </summary>
        public string WebRedirectUrl { get; set; }
    }
}
