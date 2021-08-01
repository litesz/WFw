using System.Collections.Generic;

namespace WFw.IDtos.Responses
{
    /// <summary>
    /// 分页查询数据
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPagedResponseDataDto<TEntity> : IPagedReponseDto
    {

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> Items { get; set; }
    }
}
