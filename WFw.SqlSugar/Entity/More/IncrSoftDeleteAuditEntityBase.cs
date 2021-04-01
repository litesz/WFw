using System;
using WFw.IEntity.IAudit;

namespace WFw.Entity
{

    /// <summary>
    /// 仅删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IncrSoftDeleteAuditEntityBase<T> : IncrEntityBase<T>, ISoftDeletable where T : struct
    {
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);
    }
}
