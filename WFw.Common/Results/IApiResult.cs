namespace WFw.Results
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApiResult
    {

        /// <summary>
        /// 
        /// </summary>
        OperationResultType Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        string Msg { get; set; }
    }








}
