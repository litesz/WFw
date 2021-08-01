using WFw.IEntity.IAudit;
using SqlSugar;

namespace WFw.Entity
{

    /// <summary>
    /// 新增审计
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CreatedAuditByUserEntityBase<T> : CreatedAuditByUserEntityBase<T, T>, ICreatedAuditedByUser<T> where T : struct
    {

    }



    /// <summary>
    /// 新增审计
    /// </summary>
    /// <typeparam name="TPk"></typeparam>
    /// <typeparam name="TUserId"></typeparam>
    public abstract class CreatedAuditByUserEntityBase<TPk, TUserId> : CreatedAuditEntityBase<TPk>, ICreatedAuditedByUser<TUserId> where TPk : struct
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public TUserId CreatedUserId { get; set; }
    }


    /// <summary>
    /// 新增审计
    /// </summary>
    public abstract class CreatedAuditByUserEntityBase : CreatedAuditEntityBase, ICreatedAuditedByUser<string>
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string CreatedUserId { get; set; }
    }


}
