namespace WFw.Entity
{
    /// <summary>
    /// 主键
    /// </summary>
    /// <typeparam name="TPrimary"></typeparam>
    public interface IEntity<TPrimary>
    {
        TPrimary Id { get; set; }
    }

}
