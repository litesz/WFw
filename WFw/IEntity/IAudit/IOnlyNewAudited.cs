namespace WFw.IEntity.IAudit
{
    /// <summary>
    /// 仅新增，修改
    /// </summary>
    public interface IOnlyNewAudited : IUpdatedAudited, ICreatedAudited
    {

    }
}


