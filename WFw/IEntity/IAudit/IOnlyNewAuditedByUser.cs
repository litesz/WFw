namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 仅新增，修改
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOnlyNewAuditedByUser<T> : IUpdatedAuditedByUser<T>, ICreatedAuditedByUser<T>
    {

    }
}


