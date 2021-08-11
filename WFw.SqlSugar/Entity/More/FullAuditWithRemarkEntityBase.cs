using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class FullAuditWithRemarkEntityBase<TPk> : FullAduitEntityBase<TPk>, IRemark where TPk : struct
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; } = string.Empty;
    }

    /// <summary>
    /// 全审计，备注
    /// </summary>
    public abstract class FullAuditWithRemarkEntityBase : FullAduitEntityBase, IRemark
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; } = string.Empty;
    }

}
