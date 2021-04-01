using System;
using WFw.IEntity;

namespace WFw.Entity
{

    /// <summary>
    /// 全审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class IncrFullAuditByUserEntityBase<TPk, TUserId> : IncrOnlyNewAuditByUserEntityBase<TPk, TUserId>, IFullAuditByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 
        /// </summary>
        public TUserId DeletedUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);
    }

    /// <summary>
    /// 全审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class IncrFullAuditByUserEntityBase<TPk> : IncrFullAuditByUserEntityBase<TPk, TPk>, IFullAuditByUser<TPk> where TPk : struct
    {

    }




}
