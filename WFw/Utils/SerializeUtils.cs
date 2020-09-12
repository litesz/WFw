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
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string SerializeJson<T>(this T entity) where T : class
        {
            if (entity == null)
            {
                throw new BadRequestException(OperationResultType.ParamIsEmpty);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        }

        /// <summary>
        /// 基于驼峰序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="isIgnoreNull">是否忽略值为null的对象</param>
        /// <returns></returns>
        public static string SerializeByCamelCase<T>(this T entity, bool isIgnoreNull = false) where T : class
        {
            if (entity == null)
            {
                throw new BadRequestException(OperationResultType.ParamIsEmpty);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(
                entity,
                Newtonsoft.Json.Formatting.Indented,
                new Newtonsoft.Json.JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = isIgnoreNull ? Newtonsoft.Json.NullValueHandling.Ignore : Newtonsoft.Json.NullValueHandling.Include
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
