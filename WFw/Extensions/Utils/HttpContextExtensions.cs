using Microsoft.AspNetCore.Http;

namespace System.Linq
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpContextExtensions
    {

        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        /// <summary>
        /// 判断是否是ajax
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool IsAjax(this HttpContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (context.Request.Headers != null)
            {
                return context.Request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return false;

        }

        /// <summary>
        /// 判断是否是手机端
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static bool IsWap(this HttpContext context)
        {
            bool result = false;
            if (context != null)
            {
                var useragent = context.Request.Headers["User-Agent"].ToString().ToLower();

                if (useragent.IndexOf("android") > -1 || useragent.IndexOf("ipod") > -1 || useragent.IndexOf("iphone") > -1 || useragent.IndexOf("ipad") > -1 || useragent.IndexOf("ucweb") > -1)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
