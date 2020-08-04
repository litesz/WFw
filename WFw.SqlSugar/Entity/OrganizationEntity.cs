using WFw.IEntity;

namespace WFw.Entity
{
    public abstract class OrganizationEntity<T> : EntityBase<T>, IOrganizationEntity<T>
    {
        public virtual T OrganizationId { get; set; }
    }

}
