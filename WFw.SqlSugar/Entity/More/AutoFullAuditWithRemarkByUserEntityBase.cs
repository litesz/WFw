using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class AutoFullAuditWithRemarkByUserEntityBase<TPk, TUserId> : AutoFullAduitByUserEntityBase<TPk, TUserId>, IRemark where TPk : struct
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class AutoFullAuditWithRemarkByUserEntityBase<TPk> : AutoFullAuditWithRemarkByUserEntityBase<TPk, TPk> where TPk : struct
    {

    }


}
