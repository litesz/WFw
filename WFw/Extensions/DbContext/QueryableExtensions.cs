using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.Dtos.Responses;
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

        /// <summary>
        /// 分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static IPagedResponseDataDto<T> ToPageList<T>(this IEnumerable<T> ts, IPagedResultRequestDto requestDto)
        {
            return new PagedResponseDataDto<T>(ts.Skip(requestDto.Skip).Take(requestDto.PageSize).ToArray(), ts.Count(), requestDto);
        }


        /// <summary>
        /// 分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static Task<IPagedResponseDataDto<T>> ToPageListAsync<T>(this IWQueryable<T> queryable, IPagedResultRequestDto requestDto)
        {
            return queryable.ToPageListAsync(requestDto.PageIndex, requestDto.PageSize);
        }


      

    }
}
