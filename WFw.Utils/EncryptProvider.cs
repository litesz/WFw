using System.Security.Cryptography;
using System.Text;

namespace WFw.Utils
{
    /// <summary>
    /// 加密
    /// </summary>
    public static class EncryptProvider
    {

        private const string md5Salt = "wm73UZkSKNM%";


        /// <summary>
        /// MD5密码加密
        /// md5+加盐+md5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetMd5Password(string password)
        {
            return GetMd5Password(password, md5Salt);
        }

        /// <summary>
        /// MD5密码加密
        /// md5+加盐+md5
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetMd5Password(string password, string salt)
        {
            return GetMd5($"{GetMd5(password)}{salt}");
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static string GetMd5(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sBuilder = new StringBuilder();

                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }

                string hash = sBuilder.ToString();
                return hash.ToUpper();
            }
        }


    }
}
