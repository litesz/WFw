namespace WFw.Results
{
    /// <summary>
    /// 统一错误返回值
    /// </summary>
    public class ErrApiResult : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public ErrApiResult(WFwException exception)
        {
            Code = exception.OperationResult;
            Msg = exception.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public ErrApiResult(string msg) : this("", OperationResultType.IsErr, msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ErrApiResult(OperationResultType code, string msg) : this("", code, msg)
        {

        }



        public ErrApiResult(string requestId, OperationResultType code, string msg)
        {
            RequestId = requestId;
            Code = code;
            Msg = msg;
        }
    }








}
