using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WFw.GeTui
{
    /// <summary>
    /// json扩展
    /// </summary>
    internal static class JsonExtensions
    {

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string str) where T : class
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T entity) where T : class
        {
            return JsonConvert.SerializeObject(entity);
        }

        /// <summary>
        /// 基于驼峰序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string SerializeByCamelCase<T>(this T entity) where T : class
        {
            return JsonConvert.SerializeObject(entity, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });

        }

        /// <summary>
        /// 获得Data节点字符串
        /// </summary>
        /// <param name="content">文本</param>
        /// <param name="key">节点名</param>
        /// <param name="offset">初始偏移量</param>
        /// <returns></returns>
        public static string GetSelectedSection(this string content, string key, int offset = 0)
        {
            var dataIndex = content.IndexOf($"\"{key}\"", offset);
            if (dataIndex < 0)
            {
                return null;
            }
            var startIndex = dataIndex + $"\"{key}\"".Length + 1;
            int size = 1;
            int index = 1;
            for (int i = startIndex + 1; i < content.Length; i++)
            {
                size++;
                switch (content[i])
                {
                    case '{': index++; break;
                    case '}':
                        index--;
                        if (index == 0)
                        {
                            return content.Substring(startIndex, size);
                        }
                        break;
                }
            }
            return null;
        }



    }

}
