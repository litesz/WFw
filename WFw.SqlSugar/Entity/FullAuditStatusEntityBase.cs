using WFw.IEntity;

namespace WFw.Entity
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class FullAuditStatusEntityBase : FullAuditStatusEntityBase<int>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    public abstract class FullAuditStatusEntityBase<TPk> : FullAuditStatus, IEntity<TPk> where TPk : struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public TPk Id { get; set; }
    }



}
