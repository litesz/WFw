namespace WFw.IDtos.Requests
{
    /// <summary>
    /// 排序分页查询
    /// </summary>
    public interface IPagedAndSortedResultRequestDto : IPagedResultRequestDto
    {
        /// <summary>
        /// 排序条件
        /// </summary>
        string Sorting { get; set; }

        /// <summary>
        /// 升序/降序
        /// </summary>
        bool IsAsc { get; set; }
    }
}
