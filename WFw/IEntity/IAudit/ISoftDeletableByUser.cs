namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 带人软删除
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public interface ISoftDeletableByUser<TUserId> : ISoftDeletable
    {
        /// <summary>
        /// 删除人
        /// </summary>
        TUserId DeletedUserId { get; set; }
    }

}
