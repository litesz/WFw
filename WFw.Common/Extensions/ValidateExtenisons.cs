using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WFw.Utils
{
    /// <summary>
    /// 验证
    /// </summary>
    public static class ValidateExtenisons
    {
        readonly static string[] pictureFormatArray = { ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".ico" };

        /// <summary>
        /// 是否是ip地址
        /// </summary>
        /// <param name="strIp"></param>
        /// <returns></returns>
        public static bool IsIp(this string strIp)
        {
            if (string.IsNullOrWhiteSpace(strIp)) { return false; }

            return Regex.IsMatch(strIp,
                @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
        }

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="strPhone"></param>
        /// <returns></returns>
        public static bool IsMobile(this string strPhone)
        {
            if (string.IsNullOrWhiteSpace(strPhone)) { return false; }
            return Regex.IsMatch(strPhone, @"^1[1-9][0-9]{9}$");
        }

        /// <summary>
        /// 是否是端口号
        /// </summary>
        /// <param name="strPort"></param>
        /// <returns></returns>
        public static bool IsPort(this string strPort)
        {
            if (string.IsNullOrWhiteSpace(strPort)) { return false; }

            if (!int.TryParse(strPort, out int port)) { return false; }

            return port > 0 && port <= 65535;
        }

        /// <summary>
        /// 是否是邮箱
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public static bool IsEmail(this string strEmail)
        {
            if (string.IsNullOrWhiteSpace(strEmail)) { return false; }
            return Regex.IsMatch(strEmail, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="strNum"></param>
        /// <returns></returns>
        public static bool IsNum(this string strNum)
        {
            if (string.IsNullOrWhiteSpace(strNum)) { return false; }
            return Regex.IsMatch(strNum, @"^[0-9]*$");
        }

        /// <summary>
        /// 是否是中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChineseCharacter(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) { return false; }
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]{0,}");
        }

        /// <summary>
        /// 是否是图片文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsImage(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) { return false; }
            //var name = fileName.Split('.');
            //var exName = name[name.Length - 1];
            var exName = System.IO.Path.GetExtension(fileName).ToLower();
            return pictureFormatArray.Contains(exName);
        }
    }
}
