using WFw.IDtos.Requests;

namespace WFw.Dtos.Requests
{
    /// <summary>
    /// 分页查询
    /// </summary>
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequestDto
    {
        /// <summary>
        /// 跳过内容
        /// </summary>
        public int Skip => (PageIndex - 1) * PageSize;

        /// <summary>
        /// 
        /// </summary>
        private int pageIndex = 1;

        /// <summary>
        /// 索引，最小为1
        /// </summary>
        public int PageIndex
        {
            get => pageIndex < 1 ? 1 : pageIndex;
            set => pageIndex = value;
        }
    }
}
