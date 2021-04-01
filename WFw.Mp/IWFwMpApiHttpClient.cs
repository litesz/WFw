using System.Threading.Tasks;
using WFw.Mp.Models.Cgi;
using WFw.Mp.Models.Sns;

namespace WFw.Mp
{
    public interface IWFwMpApiHttpClient
    {
        Task<SnsAccessToken> GetAccessTokenFromSns(string code);
        Task<SnsAccessToken> RefreshAccessTokenFromSns(string refreshToken);
        Task<SnsUserInfo> GetUserInfoFromSns(string accessToken, string openId);

        Task<CgiAccessToken> GetAccessToken();
        Task<CgiUserInfo> GetUSerInfo(string accessToken, string openId);
    }
}
