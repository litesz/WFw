using WFw.IEntity.IAudit;
using SqlSugar;

namespace WFw.Entity
{
    /// <summary>
    /// 删除
    /// </summary>
    public abstract class SoftDeleteAuditByUserEntityBase : SoftDeleteAuditEntityBase, ISoftDeletableByUser<string>
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string DeletedUserId { get; set; } = string.Empty;

    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class SoftDeleteAuditByUserEntityBase<TPk, TUserId> : SoftDeleteAuditEntityBase<TPk>, ISoftDeletableByUser<TUserId> where TPk : struct
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
    public abstract class SoftDeleteAuditByUserEntityBase<TPk> : SoftDeleteAuditByUserEntityBase<TPk, TPk>, ISoftDeletableByUser<TPk> where TPk : struct { }
}
