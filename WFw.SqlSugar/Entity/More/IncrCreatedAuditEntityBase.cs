using System;
using WFw.IEntity.IAudit;

namespace WFw.Entity
{

    /// <summary>
    /// 仅新增时间
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IncrCreatedAuditEntityBase<T> : IncrEntityBase<T>, ICreatedAudited where T : struct
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }

}
