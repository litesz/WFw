namespace WFw.Ys.Dtos
{
    public class GetAddresRequest
    {
        public string AccessToken { get; set; }
        public string DeviceSerial { get; set; }
        public int ChannelNo { get; set; } = 1;
        public int Protocol { get; set; } = 3;
        public int Quality { get; set; } = 2;
        public int ExpireTime { get; set; } = 86400;
        public override string ToString()
        {
            return $"accessToken={AccessToken}&channelNo={ChannelNo}&deviceSerial={DeviceSerial}&protocol={Protocol}&quality={Quality}&expireTime={ExpireTime}";
        }
    }


}
