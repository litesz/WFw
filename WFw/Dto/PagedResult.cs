using System.Collections.Generic;

namespace WFw.Dto
{
    public class PagedResult<TEntity>
    {
        public int Total { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PagedResult(IEnumerable<TEntity> items, int total, int pageIndex, int pageSize)
        {
            Items = items;
            Total = total;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public PagedResult(IEnumerable<TEntity> items, int total, IPagedResultRequestDto request)
        {
            Items = items;
            Total = total;
            PageIndex = request.PageIndex;
            PageSize = request.PageSize;
        }

        public PagedResult(PagedResult<TEntity> item) {
            Items = item.Items;
            Total = item.Total;
            PageIndex = item.PageIndex;
            PageSize = item.PageSize;
        }



    }




}
