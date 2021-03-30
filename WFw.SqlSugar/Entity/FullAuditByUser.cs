using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FullAuditByUser<T> : FullAudit, IFullAuditByUser<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T CreatedUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T UpdatedUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T DeletedUserId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class FullAuditByUser : FullAuditByUser<string> { }


}
