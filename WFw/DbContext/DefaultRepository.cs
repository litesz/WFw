using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.IDbContext;
using WFw.Identity;
using WFw.IEntity;
using WFw.IEntity.IAudit;

namespace WFw.DbContext
{

    /// <summary>
    /// 默认仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DefaultRepository<TEntity> : DefaultRepository<TEntity, int>, IRepository<TEntity> where TEntity : class, IEntity<int>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public DefaultRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    public class DefaultRepository<TEntity, TPrimary> : DefaultRepository<TEntity, TPrimary, TPrimary>, IRepository<TEntity, TPrimary> where TEntity : class, IEntity<TPrimary>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public DefaultRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    /// <summary>
    /// 默认仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    /// <typeparam name="TAdudit"></typeparam>
    public class DefaultRepository<TEntity, TPrimary, TAdudit> : IRepository<TEntity, TPrimary, TAdudit> where TEntity : class, IEntity<TPrimary>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        IAuditHandler<TEntity, TAdudit> AuditHandler => _serviceProvider.GetService<IAuditHandler<TEntity, TAdudit>>();

        /// <summary>
        /// 
        /// </summary>
        ICurrentUser CurrentUser => _serviceProvider.GetService<ICurrentUser>();

        /// <summary>
        /// 
        /// </summary>
        IWDbContext DbContext => _serviceProvider.GetService<IWDbContext>();

        readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public DefaultRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public IWQueryable<TEntity> Query => DbContext
            .Queryable<TEntity>()
            .WhereIF(AuditHandler.IsSoftDelete, $"({nameof(ISoftDeletable.IsDeleted)}=0)");

        /// <summary>
        /// 查询(包含软删除)
        /// </summary>
        public IWQueryable<TEntity> QueryNoFlag => DbContext.Queryable<TEntity>();

        /// <summary>
        /// ado
        /// </summary>
        public IAdo Ado => DbContext.Ado;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckExists(Expression<Func<TEntity, bool>> predicate, TPrimary id = default)
        {
            var pId = Where(predicate).Select(u => u.Id).First();

            if (pId.Equals(default))
            {
                return false;
            }

            if (id.Equals(default))
            {
                return !pId.Equals(default);
            }
            else
            {
                return pId.Equals(id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> CheckExistsAsync(Expression<Func<TEntity, bool>> predicate, TPrimary id = default)
        {
            var pId = await Where(predicate).Select(u => u.Id).FirstAsync();

            if (pId.Equals(default(TPrimary)))
            {
                return false;
            }

            if (id.Equals(default(TPrimary)))
            {
                return !pId.Equals(default(TPrimary));
            }
            else
            {
                return pId.Equals(id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Delete(params TEntity[] entities)
        {
            if (AuditHandler.DeleteEntitiesAudit(CurrentUser, entities))
            {
                dynamic[] ids = new dynamic[entities.Length];
                for (int i = 0; i < entities.Length; i++)
                {
                    ids[i] = entities[i].Id;
                }
                return DbContext.Deletable<TEntity>(ids).ExecuteCommand();
            }

            return DbContext.Updatable(entities).ExecuteCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete(TPrimary key)
        {
            TEntity entity = GetFirst(key);
            return Delete(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(params TEntity[] entities)
        {
            if (AuditHandler.DeleteEntitiesAudit(CurrentUser, entities))
            {
                dynamic[] ids = new dynamic[entities.Length];
                for (int i = 0; i < entities.Length; i++)
                {
                    ids[i] = entities[i].Id;
                }

                return DbContext.Deletable<TEntity>(ids).ExecuteCommandAsync();
            }

            return DbContext.Updatable(entities).ExecuteCommandAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TPrimary key)
        {
            TEntity entity = await GetFirstAsync(key);
            return await DeleteAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetAll()
        {
            return Query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<TEntity>> GetAllAsync()
        {
            return Query.ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity GetFirst(TPrimary key)
        {
            return GetFirst(u => u.Id.Equals(key));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return Where(predicate).First();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TEntity> GetFirstAsync(TPrimary key)
        {
            return GetFirstAsync(u => u.Id.Equals(key));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Where(predicate).FirstAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initData"></param>
        public void Init(params TEntity[] initData)
        {
            DbContext.Init(initData);
            if (initData != null && initData.Length > 0 && Query.First() == null)
            {
                Insert(initData);
                //DbContext.Insertable<TEntity>(initData).ExecuteCommand();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Insert(params TEntity[] entities)
        {
            AuditHandler.InsertEntitiesAudit(CurrentUser, entities);

            return DbContext.Insertable<TEntity>(entities).ExecuteCommand() == entities.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(params TEntity[] entities)
        {
            AuditHandler.InsertEntitiesAudit(CurrentUser, entities);
            return await DbContext.Insertable<TEntity>(entities).ExecuteCommandAsync() == entities.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TPrimary InsertReturnId(TEntity entity)
        {
            AuditHandler.InsertEntitiesAudit(CurrentUser, entity);
            DbContext.Insertable(entity).ExecuteCommandIdentityIntoEntity();
            return entity.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TPrimary> InsertReturnIdAsync(TEntity entity)
        {
            AuditHandler.InsertEntitiesAudit(CurrentUser, entity);
            await DbContext.Insertable(entity).ExecuteCommandIdentityIntoEntityAsync();
            return entity.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update(params TEntity[] entities)
        {
            AuditHandler.UpdateEntitiesAudit(CurrentUser, entities);

            return DbContext.Updatable(entities).ExecuteCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(params TEntity[] entities)
        {
            AuditHandler.UpdateEntitiesAudit(CurrentUser, entities);
            return DbContext.Updatable(entities).ExecuteCommandAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IWQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return Query.Where(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Where(predicate).Any();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Where(predicate).AnyAsync();
        }
    }
}
