using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WFw.Entity;
using WFw.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace WFw.DbContext
{
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


        private ICurrentUser _user => _serviceProvider.GetService<ICurrentUser>();
        private IWDbContext _dbContext => _serviceProvider.GetService<IWDbContext>();
        private readonly IServiceProvider _serviceProvider;
        public DefaultRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        public IWQueryable<TEntity> Query => _dbContext
            .Queryable<TEntity>()
            .WhereIF(IsSoftDelete, $"({nameof(ISoftDeletable.IsDeleted)}=0)");

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

        public int Delete(params TEntity[] entities)
        {
            if (DeleteEntitiesAudit(entities))
            {
                dynamic[] ids = new dynamic[entities.Length];
                for (int i = 0; i < entities.Length; i++)
                {
                    ids[i] = entities[i].Id;
                }
                return _dbContext.Deletable<TEntity>(ids).ExecuteCommand();
            }

            return Update(entities);
        }

        public int Delete(TPrimary key)
        {
            TEntity entity = Get(key);
            return Delete(entity);
        }

        public Task<int> DeleteAsync(params TEntity[] entities)
        {
            if (DeleteEntitiesAudit(entities))
            {
                dynamic[] ids = new dynamic[entities.Length];
                for (int i = 0; i < entities.Length; i++)
                {
                    ids[i] = entities[i].Id;
                }

                return _dbContext.Deletable<TEntity>(ids).ExecuteCommandAsync();
            }

            return UpdateAsync(entities);
        }

        public async Task<int> DeleteAsync(TPrimary key)
        {
            TEntity entity = await GetAsync(key);
            return await DeleteAsync(entity);
        }

        public TEntity Get(TPrimary key)
        {
            return GetFirst(u => u.Id.Equals(key));
        }

        public IList<TEntity> GetAll()
        {
            return Query.ToList();
        }

        public Task<IList<TEntity>> GetAllAsync()
        {
            return Query.ToListAsync();
        }

        public Task<TEntity> GetAsync(TPrimary key)
        {
            return GetFirstAsync(u => u.Id.Equals(key));
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return Where(predicate).First();
        }

        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Where(predicate).FirstAsync();
        }

        public void Init(params TEntity[] initData)
        {
            _dbContext.Init<TEntity>(initData);
        }

        public bool Insert(params TEntity[] entities)
        {
            InsertEntitiesAudit(entities);
            return _dbContext.Insertable<TEntity>(entities).ExecuteCommand() == entities.Length;
        }

        public async Task<bool> InsertAsync(params TEntity[] entities)
        {
            InsertEntitiesAudit(entities);
            return await _dbContext.Insertable<TEntity>(entities).ExecuteCommandAsync() == entities.Length;
        }

        public TPrimary InsertReturnId(TEntity entity)
        {
            InsertEntitiesAudit(entity);
            _dbContext.Insertable(entity).ExecuteCommandIdentityIntoEntity();
            return entity.Id;
        }

        public async Task<TPrimary> InsertReturnIdAsync(TEntity entity)
        {
            InsertEntitiesAudit(entity);
            await _dbContext.Insertable(entity).ExecuteCommandIdentityIntoEntityAsync();
            return entity.Id;
        }

        public int Update(params TEntity[] entities)
        {
            UpdateEntitiesAudit(entities);

            return _dbContext.Updatable(entities).ExecuteCommand();
        }
        //TODO 添加审计信息
        public int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateor)
        {
            return _dbContext.Updatable<TEntity>().SetColumns(updateor).Where(predicate).ExecuteCommand();
        }

        public Task<int> UpdateAsync(params TEntity[] entities)
        {
            UpdateEntitiesAudit(entities);
            return _dbContext.Updatable(entities).ExecuteCommandAsync();
        }

        public IWQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return Query.Where(expression);
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
                TPrimary id = _user.IsAuthenticated ? _user.UserIdAs<TPrimary>() : default;
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
                TPrimary id = _user.IsAuthenticated ? _user.UserIdAs<TPrimary>() : default;

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
                    deleteAudited.DeletedUserId = _user.UserIdAs<TPrimary>();
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
