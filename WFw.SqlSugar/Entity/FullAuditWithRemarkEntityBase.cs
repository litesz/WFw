using SqlSugar;

namespace WFw.Entity
{
    public abstract class FullAuditWithRemarkEntityBase : FullAuditWithRemarkEntityBase<int>
    {

    }
    public abstract class FullAuditWithRemarkEntityBase<TUserId> :
        FullAuditEntityBase<TUserId>,
        IRemark
    {

        [SugarColumn(Length = 32, IsNullable = true)]
        public string Remark { get; set; }

    }

}
