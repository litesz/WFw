using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 自增主键及全审计信息
    /// </summary>
    public abstract class FullAuditEntityBase : FullAuditEntityBase<int>
    {

    }

    /// <summary>
    /// 自增主键及全审计信息
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAuditEntityBase<TUserId> : FullAuditEntityBase<TUserId, TUserId> where TUserId : struct
    {

    }

    /// <summary>
    /// 自增主键及全审计信息
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAuditEntityBase<TPk, TUserId> : FullAudit<TUserId>, IEntity<TPk> where TPk : struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public TPk Id { get; set; }
    }



}
