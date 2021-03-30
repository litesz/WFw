using System;
using WFw.IEntity.IAudit;

namespace WFw.Entity
{
    /// <summary>
    /// 仅新增，更新
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OnlyNewAuditEntityBase<T> : CreatedAuditEntityBase<T>, IOnlyNewAudited where T : struct
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; } = new DateTime(2000, 1, 1);
    }


    /// <summary>
    ///  仅新增，更新
    /// </summary>
    public abstract class OnlyNewAuditEntityBase : CreatedAuditEntityBase, IOnlyNewAudited
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; } = new DateTime(2000, 1, 1);
    }

}
