using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WFw.Mvc;
using WFw.Results;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        [HttpGet("a")]
        public IApiResult A()
        {
            return new ApiResult();
        }

        [HttpGet("b")]
        public IApiResult B()
        {
            return new ApiResult(new { id = 2 });
        }

        [HttpGet("c")]
        public IApiResult C()
        {
            return new ErrApiResult("ErrApiResult");
        }

       

        //

        [HttpPost]
        public IApiResult D(A a)
        {
            return new ApiResult();

        }

    }

    public class A
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
