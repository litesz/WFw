using System;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 仅审计状态信息
    /// </summary>
    public abstract class FullAuditStatus : IFullAuditStatus
    {
        public DateTime CreatedTime { get; set; }
        [SqlSugar.SugarColumn(IsNullable = true)]
        public DateTime? UpdatedTime { get; set; }
        public bool IsDeleted { get; set; }
        [SqlSugar.SugarColumn(IsNullable = true)]
        public DateTime? DeletedTime { get; set; }
    }
}
