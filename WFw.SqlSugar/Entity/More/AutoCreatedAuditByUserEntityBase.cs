using WFw.IEntity.IAudit;

namespace WFw.Entity
{

    /// <summary>
    /// 新增审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class AutoCreatedAuditByUserEntityBase<TPk, TUserId> : AutoCreatedAuditEntityBase<TPk>, ICreatedAuditedByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public TUserId CreatedUserId { get; set; }
    }

    /// <summary>
    /// 新增审计
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AutoCreatedAuditByUserEntityBase<T> : AutoCreatedAuditByUserEntityBase<T, T>, ICreatedAuditedByUser<T> where T : struct
    {

    }
}
