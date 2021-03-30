namespace WFw.WxMiniProgram.Dtos.Infos
{
    public interface IEncryptedDataInfo
    {
        string EncryptedData { get; set; }
        string Iv { get; set; }
    }


    public class PhoneInfo
    {

        public string PhoneNumber { get; set; }
        public string PurePhoneNumber { get; set; }
        public string CountryCode { get; set; }

    }

    public class UserInfo
    {
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string AvatarUrl { get; set; }
        public string UnionId { get; set; }
        public Watermark Watermark { get; set; }
    }
    public class Watermark
    {
        public string AppId { get; set; }
        public long TimeStamp { get; set; }
    }
}
