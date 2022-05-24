namespace WFw.Redis
{
    /// <summary>
    /// 排序
    /// </summary>
    public enum GeoOrderBy
    {
        /// <summary>
        /// 查找结果根据距离从近到远排序。
        /// </summary>
        ASC,
        /// <summary>
        /// 查找结果根据从远到近排序。
        /// </summary>
        DESC
    }
}
