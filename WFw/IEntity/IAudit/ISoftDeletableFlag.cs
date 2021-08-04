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
}


