using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class OnlyPkFullAuditWithRemarkEntityBase : OnlyPkFullAuditWithRemarkEntityBase<string>
    {

    }


    public abstract class OnlyPkFullAuditWithRemarkEntityBase<TUserId> : OnlyPkFullAuditWithRemarkEntityBase<TUserId, TUserId>
    {

    }

    public abstract class OnlyPkFullAuditWithRemarkEntityBase<TPk, TUserId> : OnlyPkFullAuditEntityBase<TPk, TUserId>, IRemark
    {
        [SugarColumn(Length = 255, IsNullable = true)]
        public string Remark { get; set; }
    }

}
