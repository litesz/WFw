using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    ///  审计，备注
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class FullAuditWithRemarkByUserEntityBase<TPk, TUserId> : FullAduitByUserEntityBase<TPk, TUserId>, IRemark where TPk : struct
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }
    }

    /// <summary>
    /// 审计，备注
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class FullAuditWithRemarkByUserEntityBase<TPk> : FullAuditWithRemarkByUserEntityBase<TPk, TPk> where TPk : struct
    {

    }

    /// <summary>
    /// 审计，备注
    /// </summary>
    public abstract class FullAuditWithRemarkByUserEntityBase : FullAduitByUserEntityBase, IRemark
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }
    }
}
