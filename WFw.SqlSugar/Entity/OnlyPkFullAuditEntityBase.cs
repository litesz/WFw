using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 不自增主键及全审计信息
    /// </summary>
    public abstract class OnlyPkFullAuditEntityBase : OnlyPkFullAuditEntityBase<string>
    {

    }

    /// <summary>
    /// 不自增主键及全审计信息
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class OnlyPkFullAuditEntityBase<TUserId> : OnlyPkFullAuditEntityBase<TUserId, TUserId>
    {

    }

    /// <summary>
    /// 不自增主键及全审计信息
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class OnlyPkFullAuditEntityBase<TPk, TUserId> : FullAudit<TUserId>, IEntity<TPk>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true)]
        public TPk Id { get; set; }

    }

}
