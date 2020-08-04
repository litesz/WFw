namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 带人员的更新
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public interface IUpdatedAuditedByUser<TUserId> : IUpdatedAudited
    {
        /// <summary>
        /// 更新人员
        /// </summary>
        TUserId UpdatedUserId { get; set; }
    }
}
