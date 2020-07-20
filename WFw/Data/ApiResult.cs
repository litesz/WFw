using WFw.Exceptions;

namespace WFw.Data
{

    public class ApiResult
    {
        public OperationResultType code { get; set; }
        public string msg { get; set; } = "成功";
        public object data { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(BadRequestException exception)
        {
            this.code = exception.OperationResult;
            this.msg = exception.Message;
        }

        public ApiResult(OperationResultType code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        public ApiResult(object data)
        {
            this.data = data;
        }
    }

    public class IdResult
    {
        public object Id { get; set; }

        public IdResult(object id)
        {
            Id = id;
        }
    }
}
