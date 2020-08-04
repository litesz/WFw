using WFw.IDtos.Requests;

namespace WFw.Dtos.Requests
{
    /// <summary>
    /// 排序分页查询
    /// </summary>
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 排序条件
        /// </summary>
        public virtual string Sorting
        {
            get;
            set;
        }

        /// <summary>
        /// 是升序
        /// </summary>
        public bool IsAsc { get; set; } = true;
    }
}
