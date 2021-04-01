using WFw.IEntity.IAudit;

namespace WFw.Entity
{
    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class IncrSoftDeleteAuditByUserEntityBase<TPk, TUserId> : IncrSoftDeleteAuditEntityBase<TPk>, ISoftDeletableByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 
        /// </summary>
        public TUserId DeletedUserId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class IncrSoftDeleteAuditByUserEntityBase<TPk> : IncrSoftDeleteAuditByUserEntityBase<TPk, TPk>, ISoftDeletableByUser<TPk> where TPk : struct { }
}
