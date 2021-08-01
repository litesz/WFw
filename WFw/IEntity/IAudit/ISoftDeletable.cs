using System;

namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 仅软删除标志
    /// </summary>
    public interface ISoftDeletableFlag
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsDeleted { get; set; }
    }

    /// <summary>
    /// 软删除
    /// </summary>
    public interface ISoftDeletable : ISoftDeletableFlag
    {
        /// <summary>
        /// 
        /// </summary>
        DateTime DeletedTime { get; set; }
    }
}


