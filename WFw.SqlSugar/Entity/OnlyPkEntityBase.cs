using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 仅主键
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OnlyPkEntityBase<T> : IEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public virtual T Id { get; set; }
    }

}
