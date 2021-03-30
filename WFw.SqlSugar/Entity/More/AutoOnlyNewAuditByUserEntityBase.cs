using System;
using WFw.IEntity.IAudit;

namespace WFw.Entity
{
    /// <summary>
    /// 仅新增，更新
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class AutoOnlyNewAuditByUserEntityBase<TPk, TUserId> : AutoCreatedAuditByUserEntityBase<TPk, TUserId>, IOnlyNewAuditedByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; } = new DateTime(2100, 1, 1);

        /// <summary>
        /// 更新人
        /// </summary>
        public TUserId UpdatedUserId { get; set; }
    }

    /// <summary>
    /// 仅新增，更新
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class AutoOnlyNewAuditByUserEntityBase<TPk> : AutoOnlyNewAuditByUserEntityBase<TPk, TPk>, IOnlyNewAuditedByUser<TPk> where TPk : struct
    {
    }

}
