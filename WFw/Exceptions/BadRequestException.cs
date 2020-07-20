using System;
using System.Collections.Generic;
using System.Text;
using WFw.Data;
using WFw.Extensions.Utils;

namespace WFw.Exceptions
{
    public class BadRequestException : Exception
    {
        public OperationResultType OperationResult { get; }
        public string ContentText { get; }

        public BadRequestException() { }

        public BadRequestException(OperationResultType result) : this(result, "") //base(result.GetEnumDescription())
        {
        }

        public BadRequestException(OperationResultType result, string value) : base(string.Format(result.GetEnumDescription(), value))
        {
            ContentText = value;
            OperationResult = result;
        }
    }
}
