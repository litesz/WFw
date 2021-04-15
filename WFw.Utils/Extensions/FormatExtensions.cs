namespace WFw.Utils
{
    /// <summary>
    /// 格式化
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// 转化为文件大小，取整
        /// </summary>
        /// <param name="size">文件大小</param>
        /// <returns></returns>
        public static string FormatFileSize(this double size)
        {
            double mod = 1024.0;
            if (size < mod)
            {
                return $"{size}b";
            }

            string[] units = { "B", "K", "M", "G", "T", "P" };
            int i = 0;

            while (size >= mod)
            {
                size /= mod;
                i++;
            }

            return System.Math.Round(size) + units[i];
        }
    }
}
