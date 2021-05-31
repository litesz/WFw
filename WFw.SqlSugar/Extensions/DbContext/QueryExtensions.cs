using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFw.Dtos.Responses;
using WFw.IDtos.Requests;
using WFw.IDtos.Responses;
using SqlSugar;
namespace WFw.IDbContext
{
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IPagedResponseDataDto<T> ToPageList<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize)
        {
            int total = 0;
            var list = queryable.ToPageList(pageIndex, pageSize, ref total);

            return new PagedResponseDataDto<T>(list, total, pageIndex, pageSize);
        }


        /// <summary>
        /// 分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static IPagedResponseDataDto<T> ToPageList<T>(this ISugarQueryable<T> queryable, IPagedResultRequestDto requestDto)
        {
            return queryable.ToPageList<T>(requestDto.PageIndex, requestDto.PageSize);
        }

        /// <summary>
        /// 分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<IPagedResponseDataDto<T>> ToPageListAsync<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize)
        {
            RefAsync<int> total = new RefAsync<int>();
            var list = await queryable.ToPageListAsync(pageIndex, pageSize, total);
            return new PagedResponseDataDto<T>(list, total.Value, pageIndex, pageSize);
        }


        /// <summary>
        /// 分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public static Task<IPagedResponseDataDto<T>> ToPageListAsync<T>(this ISugarQueryable<T> queryable, IPagedResultRequestDto requestDto)
        {
            return queryable.ToPageListAsync<T>(requestDto.PageIndex, requestDto.PageSize);
        }




    }
}
