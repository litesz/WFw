using System;

namespace WFw.Entity
{
    public abstract class FullAuditOrganizationEntityBase<TUserId> :
     OrganizationEntity<TUserId>,
     IFullAudit<TUserId>
    {
        public TUserId CreatedUserId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public TUserId UpdatedUserId { get; set; }
        public DateTime UpdatedTime { get; set; } = new DateTime(2000, 1, 1);
        public TUserId DeletedUserId { get; set; }
        public DateTime DeletedTime { get; set; } = new DateTime(2000, 1, 1);
        public bool IsDeleted { get; set; }
    }

}
