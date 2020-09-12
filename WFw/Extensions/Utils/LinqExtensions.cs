using System.Collections.Generic;
using WFw.Dtos.Responses;
using WFw.IDtos.Requests;
using WFw.IDtos.Responses;

namespace System.Linq
{
    /// <summary>
    /// linq扩展
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// 判断条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <param name="isUse"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> ts, bool isUse, Func<T, bool> func)
        {
            if (isUse)
            {
                return ts.Where(func);
            }
            return ts;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static IPagedResponseDataDto<T> ToPageList<T>(this IEnumerable<T> ts, IPagedResultRequestDto requestDto)
        {
            return new PagedResponseDataDto<T>(
                ts.Skip(requestDto.Skip).Take(requestDto.PageSize).ToArray(),
                ts.Count(),
                requestDto);
        }

    }
}
