using System;

namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 软删除
    /// </summary>
    public interface ISoftDeletable
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime DeletedTime { get; set; }
    }
}


