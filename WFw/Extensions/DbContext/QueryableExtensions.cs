using System.Threading.Tasks;
using WFw.IDbContext;
using WFw.IDtos.Requests;
using WFw.IDtos.Responses;

namespace WFw.IDbContext
{
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static IPagedResponseDataDto<T> ToPageList<T>(this IWQueryable<T> queryable, IPagedResultRequestDto requestDto)
        {
            return queryable.ToPageList(requestDto.PageIndex, requestDto.PageSize);
        }

        public static Task<IPagedResponseDataDto<T>> ToPageListAsync<T>(this IWQueryable<T> queryable, IPagedResultRequestDto requestDto)
        {
            return queryable.ToPageListAsync(requestDto.PageIndex, requestDto.PageSize);
        }

    }
}
