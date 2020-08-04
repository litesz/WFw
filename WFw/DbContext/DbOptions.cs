namespace WFw.DbContext
{
    /// <summary>
    /// 数据库连接参数
    /// </summary>
    public class DbOptions
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public const string Position = "DbOptions";
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DatabaseType { get; set; } = "mysql";
    }
}
