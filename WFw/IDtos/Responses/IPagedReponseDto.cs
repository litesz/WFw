namespace WFw.IDtos.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPagedReponseDto : IResponseDataDto
    {
        /// <summary>
        /// 
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int PageSize { get; set; }
    }
}
