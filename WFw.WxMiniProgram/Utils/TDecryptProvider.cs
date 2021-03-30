using WFw.WxMiniProgram.Dtos.Infos;

namespace WFw.WxMiniProgram.Utils
{
    public static class TDecryptProvider
    {
        /// <summary>
        /// 解码获得手机号
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public static PhoneInfo DecryptPhone(IEncryptedDataInfo encryptedData, string sessionKey)
        {
            return encryptedData.DecryptWxMsg<PhoneInfo>(sessionKey);
        }

        /// <summary>
        /// 解码获得用户信息
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public static UserInfo DecryptUserInfo(IEncryptedDataInfo encryptedData, string sessionKey)
        {
            return encryptedData.DecryptWxMsg<UserInfo>(sessionKey);
        }

    }
}
