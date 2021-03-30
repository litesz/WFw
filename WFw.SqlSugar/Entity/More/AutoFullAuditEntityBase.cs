using System;
using WFw.IEntity;

namespace WFw.Entity
{



    /// <summary>
    /// 全审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class AutoFullAduitEntityBase<TPk> : AutoOnlyNewAuditEntityBase<TPk>, IFullAudit where TPk : struct
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
