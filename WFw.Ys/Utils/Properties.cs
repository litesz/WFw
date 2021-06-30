using System.Linq;
using System.Reflection;
using System.Text;

namespace WFw.Ys.Utils
{
    internal static class Properties<T> where T : new()
    {
        private static readonly PropertyInfo[] PropertyInfos;

        static Properties()
        {
            PropertyInfos = typeof(T).GetProperties();
        }


        internal static string ConvertToString(T data)
        {
            var strs = ConvertToStringArray(data);
            return string.Join("&", strs);
        }

        internal static string[] ConvertToStringArray(T data)
        {
            string[] output = new string[PropertyInfos.Length];

            for (int i = 0; i < PropertyInfos.Length; i++)
            {
                output[i] = $"{FirstToLower(PropertyInfos[i].Name)}={  PropertyInfos[i].GetValue(data)?.ToString()}";
            }
            return output;
        }

        static string FirstToLower(string input)
        {
            return $"{input.First().ToString().ToLower()}{ input.Substring(1)}";
        }

    }
}
