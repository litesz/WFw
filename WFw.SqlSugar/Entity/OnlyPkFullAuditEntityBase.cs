using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class OnlyPkFullAuditEntityBase : OnlyPkFullAuditEntityBase<string>
    {

    }

    public abstract class OnlyPkFullAuditEntityBase<TUserId> : OnlyPkFullAuditEntityBase<TUserId, TUserId>
    {

    }


    public abstract class OnlyPkFullAuditEntityBase<TPk, TUserId> : FullAudit<TUserId>, IEntity<TPk>
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true)]
        public TPk Id { get; set; }

    }

}
