using WFw.Exceptions;

namespace WFw.Results
{
    /// <summary>
    /// 参数检查
    /// </summary>
    public static class CheckParam
    {
        /// <summary>
        /// 不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="name"></param>
        public static void NotNull<T>(T model, string name) where T : class
        {
            if (model == default)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = nameof(T);
                }
            
                throw new WFwException(OperationResultType.IsEmpty, name, "");

            }
        }
    }
}
