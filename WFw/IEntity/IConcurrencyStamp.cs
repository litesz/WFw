namespace WFw.IEntity
{
    /// <summary>
    /// 同步标记
    /// </summary>
    public interface IConcurrencyStamp
    {
        /// <summary>
        /// 同步标记
        /// </summary>
        string ConcurrencyStamp { get; set; }
    }

}
