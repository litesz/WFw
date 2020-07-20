namespace WFw.Dto
{
    public interface IPagedResultRequestDto : ILimitedResultRequestDto
    {
        int PageIndex { get; set; }
        int Skip { get; }
    }
}
