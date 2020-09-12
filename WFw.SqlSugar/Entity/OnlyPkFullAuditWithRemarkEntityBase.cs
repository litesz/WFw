using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 不自增，全审计，备注
    /// </summary>
    public abstract class OnlyPkFullAuditWithRemarkEntityBase : OnlyPkFullAuditWithRemarkEntityBase<string>
    {

    }

    /// <summary>
    /// 不自增，全审计，备注
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class OnlyPkFullAuditWithRemarkEntityBase<TUserId> : OnlyPkFullAuditWithRemarkEntityBase<TUserId, TUserId>
    {

    }

    /// <summary>
    /// 不自增，全审计，备注
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class OnlyPkFullAuditWithRemarkEntityBase<TPk, TUserId> : OnlyPkFullAuditEntityBase<TPk, TUserId>, IRemark
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = 255, IsNullable = true)]
        public string Remark { get; set; }
    }

}
