using System;

namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 软删除
    /// </summary>
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedTime { get; set; }
    }
}


