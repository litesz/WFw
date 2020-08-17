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
    public partial class DefaultRepository<TEntity> : DefaultRepository<TEntity, int>, IRepository<TEntity> where TEntity : class, IEntity<int>, new()
    {
        public DefaultRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    /// <summary>
    /// 默认仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    public partial class DefaultRepository<TEntity, TPrimary> : IRepository<TEntity, TPrimary> where TEntity : class, IEntity<TPrimary>, new()
    {

        private static readonly bool IsAddAudited;
        private static readonly bool IsAddAuditedByUser;
        private static readonly bool IsSoftDelete;
        private static readonly bool IsSoftDeleteByUser;
        private static readonly bool IsUpdateAudited;
        private static readonly bool IsUpdateAuditedByUser;

        static DefaultRepository()
        {
            var type = typeof(TEntity);

            IsSoftDelete = typeof(ISoftDeletable).IsAssignableFrom(type);
            IsSoftDeleteByUser = typeof(ISoftDeletableByUser<TPrimary>).IsAssignableFrom(type);

            IsUpdateAudited = typeof(IUpdatedAudited).IsAssignableFrom(type);
            IsUpdateAuditedByUser = typeof(IUpdatedAuditedByUser<TPrimary>).IsAssignableFrom(type);

            IsAddAudited = typeof(ICreatedAudited).IsAssignableFrom(type);
            IsAddAuditedByUser = typeof(ICreatedAuditedByUser<TPrimary>).IsAssignableFrom(type);
        }


        private ICurrentUser User => _serviceProvider.GetService<ICurrentUser>();
        private IWDbContext DbContext => _serviceProvider.GetService<IWDbContext>();
        private readonly IServiceProvider _serviceProvider;

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
            .WhereIF(IsSoftDelete, $"({nameof(ISoftDeletable.IsDeleted)}=0)");
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
            if (DeleteEntitiesAudit(entities))
            {
                dynamic[] ids = new dynamic[entities.Length];
                for (int i = 0; i < entities.Length; i++)
                {
                    ids[i] = entities[i].Id;
                }
                return DbContext.Deletable<TEntity>(ids).ExecuteCommand();
            }

            return Update(entities);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete(TPrimary key)
        {
            TEntity entity = Get(key);
            return Delete(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(params TEntity[] entities)
        {
            if (DeleteEntitiesAudit(entities))
            {
                dynamic[] ids = new dynamic[entities.Length];
                for (int i = 0; i < entities.Length; i++)
                {
                    ids[i] = entities[i].Id;
                }

                return DbContext.Deletable<TEntity>(ids).ExecuteCommandAsync();
            }

            return UpdateAsync(entities);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TPrimary key)
        {
            TEntity entity = await GetAsync(key);
            return await DeleteAsync(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity Get(TPrimary key)
        {
            return GetFirst(u => u.Id.Equals(key));
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
        public Task<TEntity> GetAsync(TPrimary key)
        {
            return GetFirstAsync(u => u.Id.Equals(key));
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
            DbContext.Init<TEntity>(initData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Insert(params TEntity[] entities)
        {
            InsertEntitiesAudit(entities);
            return DbContext.Insertable<TEntity>(entities).ExecuteCommand() == entities.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(params TEntity[] entities)
        {
            InsertEntitiesAudit(entities);
            return await DbContext.Insertable<TEntity>(entities).ExecuteCommandAsync() == entities.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TPrimary InsertReturnId(TEntity entity)
        {
            InsertEntitiesAudit(entity);
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
            InsertEntitiesAudit(entity);
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
            UpdateEntitiesAudit(entities);

            return DbContext.Updatable(entities).ExecuteCommand();
        }
        //TODO 添加审计信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="updateor"></param>
        /// <returns></returns>
        public int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateor)
        {
            return DbContext.Updatable<TEntity>().SetColumns(updateor).Where(predicate).ExecuteCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(params TEntity[] entities)
        {
            UpdateEntitiesAudit(entities);
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

        protected void InsertEntitiesAudit(params TEntity[] entities)
        {
            if (!IsAddAudited)
            {
                return;
            }
            DateTime now = DateTime.Now;
            if (IsAddAuditedByUser)
            {
                TPrimary id = User.IsAuthenticated ? User.UserIdAs<TPrimary>() : default;
                foreach (TEntity entity in entities)
                {
                    ICreatedAuditedByUser<TPrimary> audited = (ICreatedAuditedByUser<TPrimary>)entity;
                    audited.CreatedUserId = id;
                    if (audited.CreatedTime == default)
                    {
                        audited.CreatedTime = now;
                    }
                }
            }
            else
            {
                foreach (TEntity entity in entities)
                {
                    ICreatedAudited audited = (ICreatedAudited)entity;
                    if (audited.CreatedTime == default)
                    {
                        audited.CreatedTime = now;
                    }
                }
            }
        }

        protected void UpdateEntitiesAudit(params TEntity[] entities)
        {
            if (!IsUpdateAudited)
            {
                return;
            }
            DateTime now = DateTime.Now;

            if (IsUpdateAuditedByUser)
            {
                TPrimary id = User.IsAuthenticated ? User.UserIdAs<TPrimary>() : default;

                foreach (TEntity entity in entities)
                {
                    IUpdatedAuditedByUser<TPrimary> audited = (IUpdatedAuditedByUser<TPrimary>)entity;
                    audited.UpdatedTime = now;
                    audited.UpdatedUserId = id;
                }
            }
            else
            {
                foreach (TEntity entity in entities)
                {
                    IUpdatedAudited audited = (IUpdatedAudited)entity;
                    audited.UpdatedTime = now;
                }
            }
        }

        protected bool DeleteEntitiesAudit(params TEntity[] entities)
        {
            if (!IsSoftDelete)
            {
                return true;
            }
            DateTime now = DateTime.Now;
            if (IsSoftDeleteByUser)
            {
                foreach (TEntity entity in entities)
                {
                    ISoftDeletableByUser<TPrimary> deleteAudited = (ISoftDeletableByUser<TPrimary>)entity;
                    deleteAudited.IsDeleted = true;
                    deleteAudited.DeletedTime = now;
                    deleteAudited.DeletedUserId = User.UserIdAs<TPrimary>();
                }
            }
            else
            {
                foreach (TEntity entity in entities)
                {
                    ISoftDeletable deleteAudited = (ISoftDeletable)entity;
                    deleteAudited.IsDeleted = true;
                    deleteAudited.DeletedTime = now;
                }

            }

            return false;
        }

    }
}
