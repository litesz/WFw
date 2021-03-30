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

        public TencentHttpException(string url, BaseResponse output) : base(OperationResultType.TencentHttpErr, ErrorCollection.GetErrTxt(output), $"e={ErrorCollection.GetErrTxt(output)}| u ={url}")
        {

        }

        public TencentHttpException(string url, string postData, BaseResponse output) : base(OperationResultType.TencentHttpErr, ErrorCollection.GetErrTxt(output), $"e={ErrorCollection.GetErrTxt(output)}|u={url}|p={postData}")
        {

        }

    }
}
