using SqlSugar;
using WFw.Entity;

namespace WFw.Identity.Entities
{
    [SugarTable("Identity_UserRole")]
    public class UserRole : FullAuditEntityBase<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
