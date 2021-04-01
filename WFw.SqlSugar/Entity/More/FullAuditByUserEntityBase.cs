using System;
using WFw.IEntity;

namespace WFw.Entity
{

    /// <summary>
    /// 全审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAuditByUserEntityBase<TPk, TUserId> : OnlyNewAuditByUserEntityBase<TPk, TUserId>, IFullAuditByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 删除用户
        /// </summary>
        public TUserId DeletedUserId { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);
    }

    /// <summary>
    /// 全审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class FullAuditByUserEntityBase<TPk> : FullAuditByUserEntityBase<TPk, TPk>, IFullAuditByUser<TPk> where TPk : struct
    {

    }

    /// <summary>
    /// 全审计
    /// </summary>
    public abstract class FullAduitByUserEntityBase : OnlyNewAuditByUserEntityBase, IFullAuditByUser<string>
    {
        /// <summary>
        /// 删除用户
        /// </summary>
        public string DeletedUserId { get; set; }
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
