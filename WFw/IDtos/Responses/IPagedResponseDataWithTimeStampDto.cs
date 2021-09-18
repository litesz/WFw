namespace WFw.IDtos.Responses
{
    /// <summary>
    /// 分页查询数据,带时间戳
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPagedResponseDataWithTimeStampDto<TEntity> : IPagedResponseDataDto<TEntity>, IResponseDataWithTimeStampDto
    {

    }
}
