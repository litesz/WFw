namespace WFw.IEntity
{
    /// <summary>
    /// 主键
    /// </summary>
    /// <typeparam name="TPrimary"></typeparam>
    public interface IEntity<TPrimary>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TPrimary Id { get; set; }
    }

}
