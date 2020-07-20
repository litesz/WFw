using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.Dto;

namespace WFw.DbContext
{
    public partial interface IWQueryable<T>
    {
        IWQueryable<T> Where(string expression);
        IWQueryable<T> Where(Expression<Func<T, bool>> expression);
        IWQueryable<T> WhereIF(bool isWhere, string expression);
        IWQueryable<T> WhereIF(bool isWhere, Expression<Func<T, bool>> expression);
        IWQueryable<T> OrderBy(Expression<Func<T, object>> expression, bool isAsc = true);
        IWQueryable<T> OrderByIF(bool isOrderBy, Expression<Func<T, object>> expression, bool isAsc = true);
        IWQueryable<T> Skip(int index);
        IWQueryable<T> Take(int num);

        T Single();

        Task<T> SingleAsync();

        T Single(Expression<Func<T, bool>> expression);

        Task<T> SingleAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        bool Any();

        Task<bool> AnyAsync();
        T First();
        Task<T> FirstAsync();
        T First(Expression<Func<T, bool>> expression);
        Task<T> FirstAsync(Expression<Func<T, bool>> expression);
        IWQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> expression);
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        IList<T> ToList();
        T[] ToArray();
        Task<IList<T>> ToListAsync();

        PagedResult<T> ToPageList(int pageIndex, int pageSize);

        Task<PagedResult<T>> ToPageListAsync(int pageIndex, int pageSize);
    }
}
