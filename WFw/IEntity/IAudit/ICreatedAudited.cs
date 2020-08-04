using System;

namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 新增
    /// </summary>
    public interface ICreatedAudited
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; set; }
    }
}
