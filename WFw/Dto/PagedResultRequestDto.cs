namespace WFw.Dto
{
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequestDto
    {
        public int Skip => (PageIndex - 1) * PageSize;

        int pageIndex = 1;

        public int PageIndex
        {
            get => pageIndex < 1 ? 1 : pageIndex;
            set => pageIndex = value;
        }
    }
}
