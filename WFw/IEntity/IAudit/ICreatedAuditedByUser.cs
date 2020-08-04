namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 带人员的新增
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public interface ICreatedAuditedByUser<TUserId> : ICreatedAudited
    {
        /// <summary>
        /// 创建人
        /// </summary>
        TUserId CreatedUserId { get; set; }
    }
}


