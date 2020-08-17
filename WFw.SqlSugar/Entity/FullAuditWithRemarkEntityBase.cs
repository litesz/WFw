using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class FullAuditWithRemarkEntityBase : FullAuditWithRemarkEntityBase<int>
    {

    }


    public abstract class FullAuditWithRemarkEntityBase<TUserId> : FullAuditWithRemarkEntityBase<TUserId, TUserId> where TUserId : struct
    {

    }

    public abstract class FullAuditWithRemarkEntityBase<TPk, TUserId> : FullAuditEntityBase<TPk, TUserId>, IRemark where TPk : struct
    {
        [SugarColumn(Length = 255, IsNullable = true)]
        public string Remark { get; set; }
    }

}
