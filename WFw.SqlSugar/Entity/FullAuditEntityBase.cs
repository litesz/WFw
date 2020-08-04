﻿using System;
using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class FullAuditEntityBase : FullAuditEntityBase<int>
    {

    }

    public abstract class FullAuditEntityBase<TUserId> :
       EntityBase<TUserId>,
       IFullAudit<TUserId>
    {
        public TUserId CreatedUserId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public TUserId UpdatedUserId { get; set; }
        public DateTime? UpdatedTime { get; set; } = new DateTime(2000, 1, 1);
        public TUserId DeletedUserId { get; set; }
        public DateTime? DeletedTime { get; set; } = new DateTime(2000, 1, 1);
        public bool IsDeleted { get; set; }

    }

}
