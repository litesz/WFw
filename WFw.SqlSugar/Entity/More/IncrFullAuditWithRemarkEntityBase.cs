using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class IncrFullAuditWithRemarkEntityBase<TPk> : IncrFullAuditEntityBase<TPk>, IRemark where TPk : struct
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }
    }


}
