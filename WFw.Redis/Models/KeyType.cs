namespace WFw.Redis
{
    /// <summary>
    /// key 所储存的值的类型。
    /// </summary>
    public enum KeyType
    {
        /// <summary>
        /// key不存在
        /// </summary>
        None,
        /// <summary>
        /// 字符串
        /// </summary>
        String,
        /// <summary>
        /// 列表
        /// </summary>
        List,
        /// <summary>
        /// 合集
        /// </summary>
        Set,
        /// <summary>
        /// 有序合集
        /// </summary>
        ZSet,
        /// <summary>
        /// 哈希表
        /// </summary>
        Hash,
        /// <summary>
        /// stream
        /// </summary>
        Stream
    }
}
