namespace WFw.Entity
{
    public interface IOrganizationEntity<TPrimary> : IEntity<TPrimary>
    {
        TPrimary OrganizationId { get; set; }
    }

}
