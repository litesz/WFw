using System;
using System.IO;
using System.Security.Cryptography;
using WFw.WxMiniProgram.Infos;

namespace WFw.WxMiniProgram.Utils
{
    public static class MiniDecrypt
    {
        /// <summary>
        /// 解码用户信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="encryptedData"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static T DecryptWxMsg<T>(this IEncryptedDataInfo encryptedData, string sessionKey) where T : class
        {

            if (string.IsNullOrWhiteSpace(encryptedData.EncryptedData))
            {
                throw new WFwException(Results.OperationResultType.ParamIsEmpty, "解码内容");
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new WFwException(Results.OperationResultType.ParamIsEmpty, "解码密钥");

            }

            if (string.IsNullOrWhiteSpace(encryptedData.Iv))
            {
                throw new WFwException(Results.OperationResultType.ParamIsEmpty, "初始向量");
            }

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.BlockSize = 128;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.Key = Convert.FromBase64String(sessionKey);
                    aesAlg.IV = Convert.FromBase64String(encryptedData.Iv);
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedData.EncryptedData)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(srDecrypt.ReadToEnd());
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new WFwException(Results.OperationResultType.IsErr, "解码失败");
            }
        }

    }
}
