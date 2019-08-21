using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medialink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        public MathController()
        {
        }
        [HttpGet("Add")]
        public IActionResult Add(int a, int b)
        {
            return Ok(Convert.ToString(a + b));
        }

        [HttpGet("Multiply")]
        public IActionResult Multiply(int a, int b)
        {
            return Ok(Convert.ToString(a * b));
        }

        [HttpGet("Divide")]
        public IActionResult Divide(int a, int b)
        { 
            if(b == 0)
            {
                return StatusCode(500);
            }

            return Ok(Convert.ToString(a / b));
        }
    }
}
