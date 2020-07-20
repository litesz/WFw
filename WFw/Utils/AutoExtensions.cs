using System;
using System.Linq;

namespace WFw.Utils
{
    /// <summary>
    /// 自动化
    /// </summary>
    public static class AutoExtensions
    {

        public static TTarget MapTo<TTarget>(this object source)
        {
            if (source == null)
            {
                return default;
            }

            var ttype = typeof(TTarget);
            var stype = source.GetType();
            var target = (TTarget)Activator.CreateInstance(ttype);
            foreach (var prop in ttype.GetProperties())
            {
                var value = stype.GetProperty(prop.Name)?.GetValue(source);
                if (value == null)
                {
                    continue;
                }
                prop.SetValue(target, value);
            }

            return target;
        }


        /// <summary>
        /// 填充类
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget MapTo<TSource, TTarget>(this TSource source, TTarget target)
            where TTarget : class
            where TSource : class
        {
            if (source == null)
            {
                return default;
            }

            var ttype = typeof(TTarget);
            var stype = typeof(TSource);

            foreach (var prop in ttype.GetProperties())
            {
                var value = stype.GetProperty(prop.Name)?.GetValue(source);
                if (value == null)
                {
                    continue;
                }
                prop.SetValue(target, value);
            }

            return target;

        }

        /// <summary>
        /// 填充类
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget Filling<TTarget, TSource>(this TTarget target, TSource source)
            where TTarget : class
            where TSource : class
        {
            if (source == null)
            {
                return default;
            }

            var ttype = typeof(TTarget);
            var stype = typeof(TSource);

            foreach (var prop in ttype.GetProperties())
            {
                var value = stype.GetProperty(prop.Name)?.GetValue(source);
                if (value == null)
                {
                    continue;
                }
                prop.SetValue(target, value);
            }

            return target;

        }

        /// <summary>
        /// 填充类
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="separators"></param>
        /// <returns></returns>
        public static TTarget Filling<TTarget>(this TTarget target, string source, params char[] separators)
            where TTarget : class
        {
            var ttype = typeof(TTarget);

            var p = separators == null || separators.Length == 0 ? new char[] { ';' } : separators;

            var array = source.Split(p);
            foreach (var item in array)
            {
                var info = item.Split(':');
                var prop = ttype.GetProperty(info[0], System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (prop == null)
                {
                    continue;
                }


                prop.SetValue(target, Convert.ChangeType(info[1], prop.PropertyType));
            }
            return target;

        }

        /// <summary>
        /// 反射填充类
        /// </summary>
        /// <typeparam name="TTarget">目标类</typeparam>
        /// <param name="target">目标类</param>
        /// <param name="source">数据</param>
        /// <param name="separators">数据端拆分字符</param>
        /// <param name="dataseparators">数据拆分</param>
        /// <param name="trimchar">数据字段待移除前后缀</param>
        /// <returns></returns>
        public static TTarget Filling<TTarget>(this TTarget target, string source, char separators = ';', char dataseparators = ':', char trimchar = '\"')
            where TTarget : class
        {
            var ttype = typeof(TTarget);

            var array = source.Split(separators);
            foreach (var item in array)
            {
                var info = item.Split(dataseparators);
                var prop = ttype.GetProperty(info[0], System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (prop == null)
                {
                    continue;
                }


                prop.SetValue(target, Convert.ChangeType(info[1].Trim(trimchar), prop.PropertyType));
            }
            return target;

        }

        /// <summary>
        /// 包含null值
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool HasNull<TSource>(this TSource source)
        {
            var type = typeof(TSource);

            foreach (var prop in type.GetProperties())
            {
                if (prop.GetValue(source) == null)
                {
                    return true;
                }
            }

            foreach (var field in type.GetFields())
            {
                if (field.GetValue(source) == null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 包含控制
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasNullOrWhiteSpace<TSource>(this TSource source, out string name)
        {
            var type = typeof(TSource);
            var stype = typeof(string);
            foreach (var prop in type.GetProperties().Where(u => u.PropertyType == stype))
            {
                if (string.IsNullOrWhiteSpace(prop.GetValue(source)?.ToString()))
                {
                    name = prop.Name;
                    return true;
                }
            }

            foreach (var field in type.GetFields().Where(u => u.FieldType == stype))
            {
                if (string.IsNullOrWhiteSpace(field.GetValue(source)?.ToString()))
                {
                    name = field.Name;
                    return true;
                }
            }

            name = string.Empty;
            return false;
        }

        /// <summary>
        /// 比较两个类内部值是否相同
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">目标类</param>
        /// <param name="other">对比类</param>
        /// <returns></returns>
        public static bool EqualsWith<T>(this T t, T other) where T : class, new()
        {
            if (t == null || other == null)
            {
                return false;
            }

            var str1 = Newtonsoft.Json.JsonConvert.SerializeObject(t);
            var str2 = Newtonsoft.Json.JsonConvert.SerializeObject(other);

            return str2 == str1;
        }
    }
}
