using WFw.Exceptions;
using WFw.Results;

namespace WFw.Utils
{
    /// <summary>
    /// 序列化
    /// </summary>
    public static class SerializeUtils
    {
        /// <summary>
        /// 序列化JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeJson<T>(this T obj) where T : class
        {
            if (obj == null)
            {
                throw new BadRequestException(OperationResultType.ParamIsEmpty);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 基于驼峰序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string SerializeByCamelCase<T>(this T entity) where T : class
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });

        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TOutput DeserializeJson<TOutput>(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new BadRequestException(OperationResultType.ParamIsEmpty);
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<TOutput>(str);
        }
    }
}
