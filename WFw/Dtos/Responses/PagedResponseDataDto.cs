using System;
using System.Collections.Generic;
using System.Linq;
using WFw.IDtos.Requests;
using WFw.IDtos.Responses;

namespace WFw.Dtos.Responses
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedResponseDataDto<TEntity> : IPagedResponseDataDto<TEntity>
    {
        /// <summary>
        /// 总计
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 项
        /// </summary>
        public IEnumerable<TEntity> Items { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页尺寸
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PagedResponseDataDto() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="total"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PagedResponseDataDto(IEnumerable<TEntity> items, int total, int pageIndex, int pageSize)
        {
            Items = items ?? throw new ArgumentNullException("items");
            Total = total;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="total"></param>
        /// <param name="request"></param>
        public PagedResponseDataDto(IEnumerable<TEntity> items, int total, IPagedResultRequestDto request)
            : this(items, total, request.PageIndex, request.PageSize)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public PagedResponseDataDto(IEnumerable<TEntity> items) : this(items, items?.Count() ?? 0, 1, items?.Count() ?? 0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public PagedResponseDataDto(IPagedResponseDataDto<TEntity> item) : this(item.Items, item.Total, item.PageIndex, item.PageSize)
        {
        }
    }
}
