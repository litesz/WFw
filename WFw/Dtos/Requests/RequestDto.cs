using System;
using System.Collections.Generic;
using System.Text;
using WFw.IDtos.Requests;

namespace WFw.Dtos.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestDto : IRequestDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual (bool isOk, string errMsg) ValidateParams()
        {
            return (true, "");
        }
    }
}
