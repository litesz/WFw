using System;
using System.Collections.Generic;
using System.Text;
using WFw.Exceptions;
using WFw.Results;
using WFw.Tencent.Responses;

namespace WFw.Tencent
{
    public class TencentHttpException : WFwException
    {

        public TencentHttpException(string url, BaseResponse output)
            : base(OperationResultType.TencentHttpErr, ErrorCollection.GetErrTxt(output), "url", url)
        {
        }

        public TencentHttpException(string url, string postData, BaseResponse output)
            : base(OperationResultType.TencentHttpErr, "url", url, "data", postData)
        {
        }

        public TencentHttpException(OperationResultType type, string url, BaseResponse output)
           : base(type, ErrorCollection.GetErrTxt(output), "url", url)
        {
        }

        public TencentHttpException(OperationResultType type, string url, string postData, BaseResponse output)
          : base(type, "url", url, "data", postData)
        {
        }


    }
}
