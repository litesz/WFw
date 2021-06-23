using System.Collections.Generic;

namespace WFw.IDtos.Responses
{
    /// <summary>
    /// 返回值数据对象dto标注
    /// </summary>
    public interface IResponseDataDto : IDto { }

    /// <summary>
    /// 
    /// </summary>
    public interface IPagedReponse : IResponseDataDto
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

    /// <summary>
    /// 分页查询数据
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPagedResponseDataDto<TEntity> : IPagedReponse
    {

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> Items { get; set; }
    }
}
