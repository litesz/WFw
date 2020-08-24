namespace WFw.GeTui.Models.Auth
{
    public interface IAuth
    {
        string AppKey { get; set; }
        string MasterSecret { get; set; }
    }
}
