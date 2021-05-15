using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.Exceptions;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrsController : ControllerBase
    {

        [HttpGet]
        public string GetErr()
        {
            throw new WFw.WFwException(WFw.Results.OperationResultType.IsEmpty, "a3", "x3", null);
        }
        [HttpGet("n")]
        public string GetErrN()
        {
            throw new WFw.WFwException(WFw.Results.OperationResultType.IsEmpty, "a3", "only pt");
        }

        [HttpGet("old")]
        public string GetOldErr()
        {
            throw new BadRequestException(WFw.Results.OperationResultType.NotExist, "student", Guid.NewGuid().ToString());
        }

        [HttpGet("e")]
        public string Exception()
        {
            throw new ArgumentOutOfRangeException("a2324");
        }

    }
}
