using System;
using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class FullAudit<TUserId> : IFullAudit<TUserId>
    {
        [SqlSugar.SugarColumn(IsNullable = true)]
        public TUserId CreatedUserId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [SqlSugar.SugarColumn(IsNullable = true)]
        public TUserId UpdatedUserId { get; set; } = default;

        [SqlSugar.SugarColumn(IsNullable = true)]
        public DateTime? UpdatedTime { get; set; } = new DateTime(2000, 1, 1);

        [SqlSugar.SugarColumn(IsNullable = true)]
        public TUserId DeletedUserId { get; set; } = default;

        [SqlSugar.SugarColumn(IsNullable = true)]
        public DateTime? DeletedTime { get; set; } = new DateTime(2000, 1, 1);
        public bool IsDeleted { get; set; }
    }

}
