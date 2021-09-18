using System;
using System.Collections.Generic;
using System.Linq;

namespace WFw.Utils
{
    public static class ParamCheck
    {
        /// <summary>
        /// 字符串不为空
        /// </summary>
        /// <param name="str"></param>
        /// <param name="name"></param>
        public static void NotNull(this string str, string name = "")
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new WFwIsEmptyException(name, "name", name);
            }
        }

        /// <summary>
        /// 不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="name"></param>
        public static void NotNull<T>(this T t, string name = "") where T : class
        {
            if (t == null)
            {
                throw new WFwIsEmptyException(name, "name", name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="name"></param>
        public static void NotNullOrEmpty<T>(this IEnumerable<T> t, string name = "")
        {
            if (t == null || t.Count() == 0)
            {
                throw new WFwIsEmptyException(name, "name", name);
            }
        }

        /// <summary>
        /// 是guid
        /// </summary>
        /// <param name="str"></param>
        /// <param name="name"></param>
        public static void IsGuid(this string content, string name = "")
        {
            if (!Guid.TryParse(content, out var _))
            {
                throw new WFwException($"{name}不是GUID", "content", content);
            }
        }

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="baseLine"></param>
        /// <param name="isEqual"></param>
        public static void IsGreaterThan(this int value, string name = "", int baseLine = 0, bool isEqual = true)
        {
            if (isEqual)
            {
                if (value < baseLine) { throw new WFwException($"{name}不能小于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
            else
            {
                if (value <= baseLine) { throw new WFwException($"{name}不能小于等于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
        }

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="baseLine"></param>
        /// <param name="isEqual"></param>
        public static void IsGreaterThan(this long value, string name = "", long baseLine = 0, bool isEqual = true)
        {
            if (isEqual)
            {
                if (value < baseLine) { throw new WFwException($"{name}不能小于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
            else
            {
                if (value <= baseLine) { throw new WFwException($"{name}不能小于等于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
        }

        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="baseLine"></param>
        /// <param name="isEqual"></param>
        public static void IsLessThan(this int value, string name = "", int baseLine = 0, bool isEqual = true)
        {
            if (isEqual)
            {
                if (value > baseLine) { throw new WFwException($"{name}不能大于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
            else
            {
                if (value <= baseLine) { throw new WFwException($"{name}不能大于等于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }

        }

        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="baseLine"></param>
        /// <param name="isEqual"></param>
        public static void IsLessThan(this long value, string name = "", long baseLine = 0, bool isEqual = true)
        {
            if (isEqual)
            {
                if (value > baseLine) { throw new WFwException($"{name}不能大于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
            else
            {
                if (value <= baseLine) { throw new WFwException($"{name}不能大于等于{baseLine}", nameof(value), value.ToString(), nameof(baseLine), baseLine.ToString()); }
            }
        }


    }
}
