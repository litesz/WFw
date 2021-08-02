using System;
using WFw.IDbContext;
using WFw.Identity;
using WFw.IEntity;
using WFw.IEntity.IAudit;

namespace WFw.DbContext
{
    /// <summary>
    /// 默认审计信息处理程序
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    public class DefaultAuditHandler<TEntity, TPrimary> : IAuditHandler<TEntity, TPrimary> where TEntity : class, IEntity<TPrimary>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSoftDelete => SoftAuditedType > 0;

        #region 

        /// <summary>
        /// 同步标记
        /// </summary>
        protected static readonly bool IConcurrencyStamp;

        /// <summary>
        /// 新增
        /// 0 无
        /// 1 时间
        /// 2 时间 操作者
        /// </summary>
        static readonly int AddAuditedType;
        /// <summary>
        /// 删除
        /// 0 无
        /// 1 标识
        /// 2 标识 时间
        /// 3 标识 时间 操作者
        /// </summary>
        static readonly int SoftAuditedType;


        /// <summary>
        /// 更新
        /// 0 无
        /// 1 时间
        /// 2 时间 操作者
        /// </summary>
        static readonly int UpdateAuditedType;
        #endregion
        static DefaultAuditHandler()
        {
            var type = typeof(TEntity);

            if (typeof(ICreatedAudited).IsAssignableFrom(type))
            {
                AddAuditedType = typeof(ICreatedAuditedByUser<TPrimary>).IsAssignableFrom(type) ? 2 : 1;
            }

            if (typeof(IUpdatedAudited).IsAssignableFrom(type))
            {
                UpdateAuditedType = typeof(IUpdatedAuditedByUser<TPrimary>).IsAssignableFrom(type) ? 2 : 1;
            }

            if (typeof(ISoftDeletableFlag).IsAssignableFrom(type))
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(type))
                {
                    SoftAuditedType = typeof(ISoftDeletableByUser<TPrimary>).IsAssignableFrom(type) ? 3 : 2;
                }
                else
                {
                    SoftAuditedType = 1;
                }
            }



            IConcurrencyStamp = typeof(IConcurrencyStamp).IsAssignableFrom(type);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entities"></param>
        public void InsertEntitiesAudit(ICurrentUser user, params TEntity[] entities)
        {
            if (AddAuditedType == 0)
            {
                return;
            }
            DateTime now = DateTime.Now;
            switch (AddAuditedType)
            {
                case 1:
                    foreach (TEntity entity in entities)
                    {
                        ICreatedAudited audited = (ICreatedAudited)entity;
                        if (audited.CreatedTime == default)
                        {
                            audited.CreatedTime = now;
                        }
                    }
                    break;

                case 2:
                    TPrimary id = user != null && user.IsAuthenticated ? user.UserIdAs<TPrimary>() : default;
                    foreach (TEntity entity in entities)
                    {
                        ICreatedAuditedByUser<TPrimary> audited = (ICreatedAuditedByUser<TPrimary>)entity;
                        audited.CreatedUserId = id;
                        if (audited.CreatedTime == default)
                        {
                            audited.CreatedTime = now;
                        }
                    }

                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entities"></param>
        public void UpdateEntitiesAudit(ICurrentUser user, params TEntity[] entities)
        {
            if (UpdateAuditedType == 0)
            {
                return;
            }

            DateTime now = DateTime.Now;
            switch (UpdateAuditedType)
            {
                case 1:
                    foreach (TEntity entity in entities)
                    {
                        IUpdatedAudited audited = (IUpdatedAudited)entity;
                        audited.UpdatedTime = now;
                    }
                    break;

                case 2:
                    TPrimary id = user.UserIdAs<TPrimary>();
                    foreach (TEntity entity in entities)
                    {
                        IUpdatedAuditedByUser<TPrimary> audited = (IUpdatedAuditedByUser<TPrimary>)entity;
                        audited.UpdatedTime = now;
                        audited.UpdatedUserId = id;
                    }
                    break;
                default:
                    return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool DeleteEntitiesAudit(ICurrentUser user ,params TEntity[] entities)
        {
            if (SoftAuditedType == 0)
            {
                return true;
            }
            DateTime now = DateTime.Now;

            switch (SoftAuditedType)
            {
                case 1:
                    foreach (TEntity entity in entities)
                    {
                        ISoftDeletableFlag deleteAudited = (ISoftDeletableFlag)entity;
                        deleteAudited.IsDeleted = true;
                    }
                    break;
                case 2:
                    foreach (TEntity entity in entities)
                    {
                        ISoftDeletable deleteAudited = (ISoftDeletable)entity;
                        deleteAudited.IsDeleted = true;
                        deleteAudited.DeletedTime = now;
                    }
                    break;
                case 3:

                    TPrimary id = user.UserIdAs<TPrimary>();
                    foreach (TEntity entity in entities)
                    {
                        ISoftDeletableByUser<TPrimary> deleteAudited = (ISoftDeletableByUser<TPrimary>)entity;
                        deleteAudited.IsDeleted = true;
                        deleteAudited.DeletedTime = now;
                        deleteAudited.DeletedUserId = id;
                    }
                    break;
                default: return false;
            }


            return false;
        }



    }
}
