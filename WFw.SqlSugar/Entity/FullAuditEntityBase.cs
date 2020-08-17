using System;
using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class FullAuditEntityBase : FullAuditEntityBase<int>
    {

    }

    public abstract class FullAuditEntityBase<TUserId> : FullAuditEntityBase<TUserId, TUserId> where TUserId : struct
    {

    }

    public abstract class FullAuditEntityBase<TPk, TUserId> : FullAudit<TUserId>, IEntity<TPk> where TPk : struct
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public TPk Id { get; set; }
    }


    

}
