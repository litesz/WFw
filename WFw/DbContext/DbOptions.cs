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
        /// <summary>
        /// 自动保存
        /// </summary>
        public bool IsAutoSave { get; set; } = true;
        /// <summary>
        /// 自动关闭连接
        /// </summary>
        public bool IsAutoCloseConnection { get; set; } = true;
        /// <summary>
        /// 表初始化类型
        /// </summary>
        public string InitKeyType { get; set; } = "attribute";
        /// <summary>
        /// 共享内存
        /// </summary>
        public bool IsShardSameThread { get; set; }
        /// <summary>
        /// 默认string在数据库中是否可为空
        /// </summary>
        public bool StringDefaultIsNull { get; set; } = false;
    }
}
