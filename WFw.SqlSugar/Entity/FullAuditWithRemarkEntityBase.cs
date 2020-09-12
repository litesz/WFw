using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 自增主键，全审计，备注
    /// </summary>
    public abstract class FullAuditWithRemarkEntityBase : FullAuditWithRemarkEntityBase<int>
    {

    }

    /// <summary>
    /// 自增主键，全审计，备注
    /// </summary>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAuditWithRemarkEntityBase<TUserId> : FullAuditWithRemarkEntityBase<TUserId, TUserId> where TUserId : struct
    {

    }

    /// <summary>
    /// 自增主键，全审计，备注
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAuditWithRemarkEntityBase<TPk, TUserId> : FullAuditEntityBase<TPk, TUserId>, IRemark where TPk : struct
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = 255, IsNullable = true)]
        public string Remark { get; set; }
    }

}
