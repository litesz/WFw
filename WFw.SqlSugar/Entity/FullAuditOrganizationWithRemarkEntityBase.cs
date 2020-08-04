using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class FullAuditOrganizationWithRemarkEntityBase<TUserId> :
     FullAuditOrganizationEntityBase<TUserId>,
     IRemark
    {
        [SugarColumn(Length = 32, IsNullable = true)]
        public string Remark { get; set; }

    }

}
