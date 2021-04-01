using System;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 全审计信息
    /// </summary>
    public abstract class FullAudit : IFullAudit
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedTime { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);
    }

   



}
