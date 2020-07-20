using WFw.Exceptions;

namespace WFw.Data
{
    /// <summary>
    /// 参数检查
    /// </summary>
    public static class CheckParam
    {
        public static void NotNull<T>(T model, string name) where T : class
        {
            if (model == default)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = nameof(T);
                }
                throw new BadRequestException(OperationResultType.IsEmpty, name);
            }
        }
    }
}
