using System;

namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 更新
    /// </summary>
    public interface IUpdatedAudited
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        DateTime? UpdatedTime { get; set; }
    }
}


