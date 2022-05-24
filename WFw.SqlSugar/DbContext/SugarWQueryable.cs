using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.Dtos.Responses;
using WFw.IDbContext;
using WFw.IDtos.Responses;

namespace WFw.DbContext
{
    /// <summary>
    /// 查询接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SugarWQueryable<T> : IWQueryable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public ISugarQueryable<T> Queryable => _queryable;

        private ISugarQueryable<T> _queryable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public SugarWQueryable(ISqlSugarClient client)
        {
            _queryable = client.Queryable<T>();
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="queryable"></param>
        public SugarWQueryable(ISugarQueryable<T> queryable)
        {
            _queryable = queryable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _queryable.Any(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            return _queryable.Any();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.AnyAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<bool> AnyAsync()
        {
            return _queryable.AnyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IWQueryable<T> As(string tableName)
        {
            _queryable = _queryable.AS(tableName);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _queryable.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> expression)
        {
            return _queryable.Count(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> CountAsync()
        {
            return _queryable.CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.CountAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T First()
        {
            return _queryable.First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T First(Expression<Func<T, bool>> expression)
        {
            return _queryable.First(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<T> FirstAsync()
        {
            return _queryable.FirstAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.FirstAsync(expression);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IWQueryable<T> OrderBy(Expression<Func<T, object>> expression, bool isAsc)
        {
            _queryable = _queryable.OrderBy(expression, isAsc ? OrderByType.Asc : OrderByType.Desc);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOrderBy"></param>
        /// <param name="expression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IWQueryable<T> OrderByIF(bool isOrderBy, Expression<Func<T, object>> expression, bool isAsc)
        {
            if (isOrderBy)
            {
                _queryable = _queryable.OrderBy(expression, isAsc ? OrderByType.Asc : OrderByType.Desc);
            }
            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> OrderBy(Expression<Func<T, object>> expression)
        {
            _queryable = _queryable.OrderBy(expression, OrderByType.Asc);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOrderBy"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> OrderByIF(bool isOrderBy, Expression<Func<T, object>> expression)
        {
            if (isOrderBy)
            {
                _queryable = _queryable.OrderBy(expression, OrderByType.Asc);
            }
            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> OrderByDescending(Expression<Func<T, object>> expression)
        {
            _queryable = _queryable.OrderBy(expression, OrderByType.Desc);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOrderBy"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> OrderByDescendingIF(bool isOrderBy, Expression<Func<T, object>> expression)
        {
            if (isOrderBy)
            {
                _queryable = _queryable.OrderBy(expression, OrderByType.Desc);
            }
            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> expression)
        {
            return new SugarWQueryable<TResult>(_queryable.Select<TResult>(expression));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Single()
        {
            return _queryable.Single();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T Single(Expression<Func<T, bool>> expression)
        {
            return _queryable.Single(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<T> SingleAsync()
        {
            return _queryable.SingleAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<T> SingleAsync(Expression<Func<T, bool>> expression)
        {
            return _queryable.SingleAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IWQueryable<T> Skip(int index)
        {
            _queryable = _queryable.Skip(index);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IWQueryable<T> Take(int num)
        {
            _queryable = _queryable.Take(num);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return _queryable.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<T> ToList()
        {
            return _queryable.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> ToListAsync()
        {
            return await _queryable.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IPagedResponseDataDto<T> ToPageList(int pageIndex, int pageSize)
        {
            int total = 0;
            var list = _queryable.ToPageList(pageIndex, pageSize, ref total);

            return new PagedResponseDataDto<T>(list, total, pageIndex, pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IPagedResponseDataDto<T>> ToPageListAsync(int pageIndex, int pageSize)
        {
            RefAsync<int> total = new RefAsync<int>();
            var list = await _queryable.ToPageListAsync(pageIndex, pageSize, total);
            return new PagedResponseDataDto<T>(list, total.Value, pageIndex, pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToSql()
        {

            var sqlInfo = _queryable.ToSql();
            string sql = sqlInfo.Key;

            if (sqlInfo.Value != null && sqlInfo.Value.Count > 0)
            {
                foreach (var item in sqlInfo.Value)
                {
                    sql = sql.Replace(item.ParameterName, item.Value.ToString());
                }
            }

            return sql;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> Where(string expression)
        {
            _queryable = _queryable.Where(expression);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            _queryable = _queryable.Where(expression);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isWhere"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> WhereIF(bool isWhere, Expression<Func<T, bool>> expression)
        {
            if (isWhere)
            {
                _queryable = _queryable.Where(expression);
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isWhere"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> WhereIF(bool isWhere, string expression)
        {
            if (isWhere)
            {
                _queryable = _queryable.Where(expression);
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<T> GroupBy(Expression<Func<T, object>> expression)
        {
            _queryable = _queryable.GroupBy(expression);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupFileds"></param>
        /// <returns></returns>
        public IWQueryable<T> GroupBy(string groupFileds)
        {
            _queryable = _queryable.GroupBy(groupFileds);
            return this;
        }
    }

}
