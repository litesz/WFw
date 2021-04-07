using System;
using System.ComponentModel;
using System.Reflection;

namespace WFw.Utils
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>忽略大小写的字符串相等比较，判断是否与任意一个待比较字符串相等</summary>
        /// <param name="value">字符串</param>
        /// <param name="strs">待比较字符串数组</param>
        /// <returns></returns>
        public static bool EqualIgnoreCase(this string value, params string[] strs)
        {
            foreach (var item in strs)
            {
                if (string.Equals(value, item, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }

        /// <summary>忽略大小写的字符串开始比较，判断是否与任意一个待比较字符串开始</summary>
        /// <param name="value">字符串</param>
        /// <param name="strs">待比较字符串数组</param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string value, params string[] strs)
        {
            if (value == null || string.IsNullOrEmpty(value)) return false;

            foreach (var item in strs)
            {
                if (value.StartsWith(item, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }

        /// <summary>忽略大小写的字符串结束比较，判断是否以任意一个待比较字符串结束</summary>
        /// <param name="value">字符串</param>
        /// <param name="strs">待比较字符串数组</param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string value, params string[] strs)
        {
            if (value == null || string.IsNullOrEmpty(value)) return false;

            foreach (var item in strs)
            {
                if (value.EndsWith(item, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }

    }
}
