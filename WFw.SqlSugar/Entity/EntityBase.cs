using SqlSugar;
namespace WFw.Entity
{
    public abstract class EntityBase<T> : IEntity<T>
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public virtual T Id { get; set; }

        public EntityBase()
        {
        }
    }

}
