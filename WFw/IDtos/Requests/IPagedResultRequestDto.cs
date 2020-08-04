namespace WFw.IDtos.Requests
{
    /// <summary>
    /// 分页查询
    /// </summary>
    public interface IPagedResultRequestDto : ILimitedResultRequestDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 已跳过多少条记录
        /// </summary>
        int Skip { get; }
    }
}
