using System;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 全审计信息
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAudit<TUserId> : IFullAudit<TUserId>
    {
        /// <summary>
        /// 创建者
        /// </summary>
        [SqlSugar.SugarColumn(IsNullable = true)]
        public TUserId CreatedUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新者
        /// </summary>
        [SqlSugar.SugarColumn(IsNullable = true)]
        public TUserId UpdatedUserId { get; set; } = default;

        /// <summary>
        /// 更新时间
        /// </summary>
        [SqlSugar.SugarColumn(IsNullable = true)]
        public DateTime? UpdatedTime { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// 删除者
        /// </summary>
        [SqlSugar.SugarColumn(IsNullable = true)]
        public TUserId DeletedUserId { get; set; } = default;

        /// <summary>
        /// 删除时间
        /// </summary>
        [SqlSugar.SugarColumn(IsNullable = true)]
        public DateTime? DeletedTime { get; set; } = new DateTime(2000, 1, 1);
        /// <summary>
        /// 软删除标志位
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
