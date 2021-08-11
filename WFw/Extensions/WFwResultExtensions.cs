using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WFw.Mvc;
using WFw.Results;

namespace WFw
{
    /// <summary>
    /// 
    /// </summary>
    public static class WFwResultExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IActionResult ToWFwErrApiResult(this ActionContext context)
        {
            string type = context.HttpContext.Request.Headers[HttpHeaderConst.ErrResultType];

            var errors = context.ModelState.Where(u => u.Value.Errors.Count > 0).ToArray();
            if (type == "multi")
            {
                List<KeyValuePair<string, string[]>> output = new List<KeyValuePair<string, string[]>>();
                foreach (var err in errors)
                {
                    output.Add(new KeyValuePair<string, string[]>(err.Key, err.Value.Errors.Select(u => u.ErrorMessage).ToArray()));
                }

                return new WFwBadRequestObjectResult(output);
            }

            return new WFwBadRequestObjectResult(OperationResultType.ParamIsErr, errors.First().Value.Errors[0].ErrorMessage);

        }

    }
}
