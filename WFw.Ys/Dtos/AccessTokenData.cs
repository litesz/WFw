using System;

namespace WFw.Ys.Dtos
{
    public class AccessTokenData
    {
        public string AccessToken { get; set; }
        public long ExpireTime { get; set; }
    }

    public class ApiClientResult<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }

        public bool IsSuccess => Code == 200;
    }

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

    public class GetAddressResponseData
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
