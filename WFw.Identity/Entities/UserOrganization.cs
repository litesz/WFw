using SqlSugar;
using WFw.Entity;

namespace WFw.Core.Identity.Entities
{
    [SugarTable("Identity_Organization")]
    public class UserOrganization : FullAuditEntityBase<int>
    {
        [SugarColumn(Length = 32)]
        public string Name { get; set; }

        [SugarColumn(Length = 13, ColumnDataType = "char")]
        public string Telephone { get; set; } = "None";

        [SugarColumn(Length = 255)]
        public string Address { get; set; } = "None";

        public int District { get; set; }

        public bool IsLock { get; set; }
    }
}
