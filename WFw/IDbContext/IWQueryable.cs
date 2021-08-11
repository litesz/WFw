using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.IDtos.Responses;

namespace WFw.IDbContext
{
    /// <summary>
    /// 查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IWQueryable<T>
    {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        IWQueryable<T> As(string tableName);

        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> Where(string expression);

        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> Where(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="isWhere"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> WhereIF(bool isWhere, string expression);

        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="isWhere"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> WhereIF(bool isWhere, Expression<Func<T, bool>> expression);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IWQueryable<T> OrderBy(Expression<Func<T, object>> expression, bool isAsc);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="isOrderBy"></param>
        /// <param name="expression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IWQueryable<T> OrderByIF(bool isOrderBy, Expression<Func<T, object>> expression, bool isAsc);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> OrderBy(Expression<Func<T, object>> expression);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="isOrderBy"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> OrderByIF(bool isOrderBy, Expression<Func<T, object>> expression);

        /// <summary>
        /// 倒叙排列
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> OrderByDescending(Expression<Func<T, object>> expression);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="isOrderBy"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> OrderByDescendingIF(bool isOrderBy, Expression<Func<T, object>> expression);


        /// <summary>
        /// 跳过
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IWQueryable<T> Skip(int index);

        /// <summary>
        /// 取指定长度
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        IWQueryable<T> Take(int num);
        /// <summary>
        /// 唯一
        /// </summary>
        /// <returns></returns>
        T Single();

        /// <summary>
        /// 唯一
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T Single(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 异步唯一
        /// </summary>
        /// <returns></returns>
        Task<T> SingleAsync();

        /// <summary>
        /// 异步唯一
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> SingleAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        bool Any();
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 异步是否存在
        /// </summary>
        /// <returns></returns>
        Task<bool> AnyAsync();
        /// <summary>
        /// 异步是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 第一条
        /// </summary>
        /// <returns></returns>
        T First();

        /// <summary>
        /// 第一条
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T First(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 异步第一条
        /// </summary>
        /// <returns></returns>
        Task<T> FirstAsync();

        /// <summary>
        /// 异步第一条
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> FirstAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 选择
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> expression);
        /// <summary>
        /// 计数
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 异步计数
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        /// <summary>
        /// 异步计数
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 转list
        /// </summary>
        /// <returns></returns>
        IList<T> ToList();

        /// <summary>
        /// 异步转list
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> ToListAsync();

        /// <summary>
        /// 转array
        /// </summary>
        /// <returns></returns>
        T[] ToArray();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedResponseDataDto<T> ToPageList(int pageIndex, int pageSize);

        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IPagedResponseDataDto<T>> ToPageListAsync(int pageIndex, int pageSize);

        /// <summary>
        /// 获得sql
        /// </summary>
        /// <returns></returns>
        string ToSql();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IWQueryable<T> GroupBy(Expression<Func<T, object>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupFileds"></param>
        /// <returns></returns>
        IWQueryable<T> GroupBy(string groupFileds);
    }
}
