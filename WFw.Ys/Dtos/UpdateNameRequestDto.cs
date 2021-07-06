namespace WFw.Ys.Dtos
{
    public class UpdateNameRequestDto
    {
        public string AccessToken { get; set; }
        public string DeviceSerial { get; set; }
        public string DeviceName { get; set; }
    }

    public class AddDeviceRequestDto
    {
        public string AccessToken { get; set; }
        public string DeviceSerial { get; set; }
        public string ValidateCode { get; set; }
    }
}
