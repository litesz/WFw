using System.Collections.Generic;

namespace WFw.Results
{
    /// <summary>
    /// 参数错误
    /// </summary>
    public class ModelStateErrApiResult : ApiResultBase, IErrApirResult
    {
        public ModelStateErrApiResult(IList<KeyValuePair<string, string[]>> errors)
        {
            Code = OperationResultType.ParamIsErr;
            Errors = errors;
            Msg = "参数错误";
        }

        public IList<KeyValuePair<string, string[]>> Errors { get; set; }


    }





}
