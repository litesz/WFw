using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.Dto;

namespace WFw.DbContext
{
    public class SugarWQueryable<T> : IWQueryable<T>
    {
        private ISugarQueryable<T> _queryable;

        public SugarWQueryable(SqlSugarClient client)
        {
            _queryable = client.Queryable<T>();
        }

        public SugarWQueryable(ISugarQueryable<T> queryable)
        {
            _queryable = queryable;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _queryable.Any(expression);
        }

        public bool Any()
        {
            return _queryable.Any();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.AnyAsync(expression);
        }

        public Task<bool> AnyAsync()
        {
            return _queryable.AnyAsync();
        }

        public int Count()
        {
            return _queryable.Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _queryable.Count(expression);
        }

        public Task<int> CountAsync()
        {
            return _queryable.CountAsync();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.CountAsync(expression);
        }

        public T First()
        {
            return _queryable.First();
        }

        public T First(Expression<Func<T, bool>> expression)
        {
            return _queryable.First(expression);
        }

        public Task<T> FirstAsync()
        {
            return _queryable.FirstAsync();
        }

        public Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.FirstAsync(expression);

        }

        public IWQueryable<T> OrderBy(Expression<Func<T, object>> expression, bool isAsc = true)
        {
            _queryable = _queryable.OrderBy(expression, isAsc ? OrderByType.Asc : OrderByType.Desc);
            return this;
        }

        public IWQueryable<T> OrderByIF(bool isOrderBy, Expression<Func<T, object>> expression, bool isAsc = true)
        {
            if (isOrderBy)
            {
                _queryable = _queryable.OrderBy(expression, isAsc ? OrderByType.Asc : OrderByType.Desc);
            }
            return this;
        }

        public IWQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> expression)
        {
            return new SugarWQueryable<TResult>(_queryable.Select<TResult>(expression));
        }

        public T Single()
        {
            return _queryable.Single();
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            return _queryable.Single(expression);
        }

        public Task<T> SingleAsync()
        {
            return _queryable.SingleAsync();

        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.SingleAsync(expression);
        }

        public IWQueryable<T> Skip(int index)
        {
            _queryable = _queryable.Skip(index);
            return this;
        }

        public IWQueryable<T> Take(int num)
        {
            _queryable = _queryable.Take(num);
            return this;
        }

        public T[] ToArray()
        {
            return _queryable.ToArray();
        }

        public IList<T> ToList()
        {
            return _queryable.ToList();
        }

        public async Task<IList<T>> ToListAsync()
        {
            return await _queryable.ToListAsync();
        }

        public PagedResult<T> ToPageList(int pageIndex, int pageSize)
        {
            int total = 0;
            var list = _queryable.ToPageList(pageIndex, pageSize, ref total);

            return new PagedResult<T>(list, total, pageIndex, pageSize);
        }

        public async Task<PagedResult<T>> ToPageListAsync(int pageIndex, int pageSize)
        {
            RefAsync<int> total = new RefAsync<int>();
            var list = await _queryable.ToPageListAsync(pageIndex, pageSize, total);
            return new PagedResult<T>(list, total.Value, pageIndex, pageSize);
        }

        public IWQueryable<T> Where(string expression)
        {
            _queryable = _queryable.Where(expression);
            return this;
        }

        public IWQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            _queryable = _queryable.Where(expression);
            return this;
        }

        public IWQueryable<T> WhereIF(bool isWhere, Expression<Func<T, bool>> expression)
        {
            if (isWhere)
            {
                _queryable = _queryable.Where(expression);
            }
            return this;
        }

        public IWQueryable<T> WhereIF(bool isWhere, string expression)
        {
            if (isWhere)
            {
                _queryable = _queryable.Where(expression);
            }
            return this;
        }
    }

}
