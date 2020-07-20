using System;

namespace WFw.Entity
{
    public interface IFullAudit<TUserId> :
        ICreatedAuditedByUser<TUserId>,
        IUpdatedAuditedByUser<TUserId>,
        ISoftDeletableByUser<TUserId>
    {
    }

    public interface ICreatedAudited
    {
        DateTime CreatedTime { get; set; }
    }

    public interface ICreatedAuditedByUser<TUserId> : ICreatedAudited
    {
        TUserId CreatedUserId { get; set; }
    }

    public interface IUpdatedAudited
    {
        DateTime UpdatedTime { get; set; }
      

    }

    public interface IUpdatedAuditedByUser<TUserId> : IUpdatedAudited
    {
        TUserId UpdatedUserId { get; set; }
       
    }
}
