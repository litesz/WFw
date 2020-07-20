using System.Threading.Tasks;
using WFw.Dto;

namespace WFw.DbContext
{
    public static class QueryableExtensions
    {
        public static PagedResult<T> ToPageList<T>(this IWQueryable<T> queryable, PagedResultRequestDto requestDto)
        {
            return queryable.ToPageList(requestDto.PageIndex, requestDto.PageSize);
        }

        public static Task<PagedResult<T>> ToPageListAsync<T>(this IWQueryable<T> queryable, PagedResultRequestDto requestDto)
        {
            return queryable.ToPageListAsync(requestDto.PageIndex, requestDto.PageSize);
        }

    }
}
