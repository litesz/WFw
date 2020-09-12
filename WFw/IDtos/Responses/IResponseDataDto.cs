using System.Collections.Generic;

namespace WFw.IDtos.Responses
{
    /// <summary>
    /// 返回值数据对象dto标注
    /// </summary>
    public interface IResponseDataDto : IDto { }

    /// <summary>
    /// 分页查询数据
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPagedResponseDataDto<TEntity> : IResponseDataDto
    {
        /// <summary>
        /// 
        /// </summary>
        int Total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> Items { get; set; }
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
