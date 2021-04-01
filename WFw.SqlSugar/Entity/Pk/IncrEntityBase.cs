using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 自增主键
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IncrEntityBase<T> : IEntity<T> where T : struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public virtual T Id { get; set; }
    }

}
