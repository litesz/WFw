using WFw.IEntity.IAudit;

namespace WFw.IEntity
{
    /// <summary>
    /// 完整审计接口
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public interface IFullAuditByUser<TUserId> :
        IOnlyNewAuditedByUser<TUserId>,
        ISoftDeletableByUser<TUserId>
    {
    }


}

