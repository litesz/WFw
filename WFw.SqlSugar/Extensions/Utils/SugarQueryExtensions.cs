using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFw.IDtos.Requests;

namespace WFw.DbContext
{
    /// <summary>
    /// 
    /// </summary>
    public static class SugarQueryExtensions
    {
        /// <summary>
        /// 分页查询扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static async Task<(IEnumerable<T> Items, int Total)> ToPageListWithTotalAsync<T>(this ISugarQueryable<T> query, int index, int size)
        {
            RefAsync<int> total = new RefAsync<int>();
            var result = await query.ToPageListAsync(index, size, total);
            return (result, total);
        }

        /// <summary>
        /// 分页查询扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static Task<(IEnumerable<T> Items, int Total)> ToPageListWithTotalAsync<T>(this ISugarQueryable<T> query, IPagedResultRequestDto requestDto)
        {
            return ToPageListWithTotalAsync(query, requestDto.PageIndex, requestDto.PageSize);
        }
    }
}
