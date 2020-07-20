namespace WFw.Entity
{
    /// <summary>
    /// 同步标记
    /// </summary>
    public interface IConcurrencyStamp
    {
        string ConcurrencyStamp { get; set; }
    }

}
