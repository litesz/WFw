namespace WFw.IEntity
{
    /// <summary>
    /// 带组织
    /// </summary>
    /// <typeparam name="TPrimary"></typeparam>
    public interface IOrganizationEntity<TPrimary> : IEntity<TPrimary>
    {
        /// <summary>
        /// 组织id
        /// </summary>
        TPrimary OrganizationId { get; set; }
    }

}
