using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 自增主键
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T> : IEntity<T> where T : struct
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public virtual T Id { get; set; }
    }

}
