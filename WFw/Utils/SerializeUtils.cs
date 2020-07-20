using WFw.Data;
using WFw.Exceptions;

namespace WFw.Utils
{
    public class SerializeUtils
    {
        public static string SerializeJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

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
