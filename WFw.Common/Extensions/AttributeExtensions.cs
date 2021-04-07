using System;
using System.ComponentModel;
using System.Reflection;

namespace WFw
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="en">枚举</param>
        /// <returns>返回枚举的描述</returns>
        public static string GetEnumDescription(this Enum en)
        {
            Type type = en.GetType();   //获取类型
            MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员
            if (memberInfos == null || memberInfos.Length == 0)
            {
                return en.ToString();
            }

            if (memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attrs)
            {
                if (attrs.Length == 0)
                {
                    return en.ToString();
                }

                return attrs[0].Description;//返回当前描述
            }

            return en.ToString();
        }

    }
}
