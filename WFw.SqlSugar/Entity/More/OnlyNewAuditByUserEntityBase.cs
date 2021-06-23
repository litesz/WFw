using System;
using WFw.IEntity.IAudit;

namespace WFw.Entity
{
    /// <summary>
    /// 仅新增，更新
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class OnlyNewAuditByUserEntityBase<TPk, TUserId> : CreatedAuditByUserEntityBase<TPk, TUserId>, IOnlyNewAuditedByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// 更新人
        /// </summary>
        public TUserId UpdatedUserId { get; set; }
    }

    /// <summary>
    /// 仅新增，更新
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class OnlyNewAuditByUserEntityBase<TPk> : OnlyNewAuditByUserEntityBase<TPk, TPk>, IOnlyNewAuditedByUser<TPk> where TPk : struct
    {
    }


    /// <summary>
    /// 仅新增，更新
    /// </summary>
    public abstract class OnlyNewAuditByUserEntityBase : CreatedAuditByUserEntityBase, IOnlyNewAuditedByUser<string>
    {
        /// <summary>
        /// 更新人
        /// </summary>
        [SqlSugar.SugarColumn(IsNullable = true)]
        public string UpdatedUserId { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; } = new DateTime(2000, 1, 1);
    }




}
