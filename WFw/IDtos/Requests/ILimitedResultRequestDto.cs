namespace WFw.IDtos.Requests
{
    /// <summary>
    /// 限制查询大小
    /// </summary>
    public interface ILimitedResultRequestDto
    {
        /// <summary>
        /// 尺寸
        /// </summary>
        int PageSize { get; set; }
    }
}
