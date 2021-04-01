using SqlSugar;
using WFw.IEntity;

namespace WFw.Entity
{
    /// <summary>
    /// 值主键
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T> : IEntity<T> where T : struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public virtual T Id { get; set; }
    }

    /// <summary>
    /// 字符串主键
    /// </summary>
    public abstract class EntityBase : IEntity<string>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public virtual string Id { get; set; } = System.Guid.NewGuid().ToString("N");
    }

}
