using WFw.GeTui.Models.Auth;

namespace WFw.GeTui.Models.Options
{
    public class PushOptions : IAuth
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public const string Position = "PushOptions";
        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MasterSecret { get; set; }
        /// <summary>
        /// 提前刷新TOKEN时间
        /// </summary>
        public long InAdvance { get; set; } = 600;
    }
}
