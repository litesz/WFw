using System;

namespace WFw.IEntity.IAudit
{

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


