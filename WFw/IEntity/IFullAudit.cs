using WFw.IEntity.IAudit;

namespace WFw.IEntity
{
    /// <summary>
    /// 完整审计接口
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public interface IFullAudit<TUserId> :
        ICreatedAuditedByUser<TUserId>,
        IUpdatedAuditedByUser<TUserId>,
        ISoftDeletableByUser<TUserId>
    {
    }


}

