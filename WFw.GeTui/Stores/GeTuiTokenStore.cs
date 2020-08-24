using Microsoft.Extensions.Options;
using System;
using WFw.GeTui.Models.Options;

namespace WFw.GeTui.Stores
{
    public class GeTuiTokenStore
    {

        private readonly long _inAdvance;
        public bool IsLoading { get; set; }

        public string Token { get; set; }
        public DateTime Expire { get; set; }

        public GeTuiTokenStore(IOptions<PushOptions> options)
        {
            _inAdvance = options.Value.InAdvance;
        }


        public bool IsExpired()
        {

            if (string.IsNullOrWhiteSpace(Token))
            {
                return false;
            }

            if (DateTime.Now.AddSeconds(_inAdvance) >= Expire)
            {

                return false;
            }
            return true;
        }

    }
}
