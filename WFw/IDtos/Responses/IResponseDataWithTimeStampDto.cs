namespace WFw.IDtos.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResponseDataWithTimeStampDto : IResponseDataDto
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        long TimeStamp { get; set; }
    }
}
