namespace WFw.Utils
{
    /// <summary>
    /// 字符串内容加密,如手机号，姓名
    /// </summary>
    public static class StringEncryptProvider
    {
        /// <summary>
        /// 加密手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string EncrpytPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length < 11)
            {
                return "";
            }
            return $"{phone.Substring(0, 3)}****{phone.Substring(phone.Length - 5, 4)}";
        }


        /// <summary>
        /// 加密姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string EncrpytName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            {
                return "";
            }

            switch (name.Length)
            {
                case 1: return name;
                case 2: return $"{name.Substring(0, 1)}*";
                case 3: return $"{name.Substring(0, 1)}*{name.Substring(2, 1)}";
                default: return $"{name.Substring(0, 1)}{name.Substring(name.Length - 1, 1).PadLeft(name.Length - 3, '*')}";
            }
        }



    }
}
