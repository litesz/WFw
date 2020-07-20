namespace WFw.Dto
{
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto
    {
        public virtual string Sorting
        {
            get;
            set;
        }

        public bool IsAsc { get; set; } = true;
    }
}
