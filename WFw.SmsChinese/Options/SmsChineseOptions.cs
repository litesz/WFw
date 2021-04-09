namespace WFw.SmsChinese.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsChineseOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Position = "SmsChinese";
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUtf8 { get; set; } = true;
    }
}
