using System;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 全审计
    /// </summary>
    public abstract class FullAduitEntityBase : OnlyNewAuditEntityBase, IFullAudit
    {
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// 软删除标志位
        /// </summary>
        public bool IsDeleted { get; set; }
    }


    /// <summary>
    /// 全审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class FullAduitEntityBase<TPk> : OnlyNewAuditEntityBase<TPk>, IFullAudit where TPk : struct
    {
        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);
    }


}
