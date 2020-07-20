using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFw.Dto
{


    public class PagedResultDto<TEntity> where TEntity : class
    {
        public int Total { get; set; }
        public IEnumerable<TEntity> Items { get; set; }

        public PagedResultDto(IEnumerable<TEntity> items, int total)
        {
            Items = items;
            Total = total;
        }

        public PagedResultDto((IEnumerable<TEntity> Items, int Total) data)
        {
            Items = data.Items;
            Total = data.Total;
        }
    }




}
