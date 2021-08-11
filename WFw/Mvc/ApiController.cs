using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WFw.Results;

namespace WFw.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiController : ControllerBase
    {

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public virtual WFwBadRequestObjectResult WFwErrApiResult(string content)
        {
            return new WFwBadRequestObjectResult(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual WFwBadRequestObjectResult WFwErrApiResult(OperationResultType code, string msg)
        {
            return new WFwBadRequestObjectResult(code, msg);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class WFwApiResult<T> : ObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public WFwApiResult(T data) : base(new ApiResult<T>(data))
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WFwBadRequestObjectResult : UnprocessableEntityObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errApirResult"></param>
        public WFwBadRequestObjectResult(IErrApirResult errApirResult) : base(errApirResult)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public WFwBadRequestObjectResult(string content) : this(new ErrApiResult(content))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public WFwBadRequestObjectResult(OperationResultType code, string msg) : this(new ErrApiResult(code, msg))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        public WFwBadRequestObjectResult(IList<KeyValuePair<string, string[]>> errors) : this(new ModelStateErrApiResult(errors))
        {

        }



    }






}
