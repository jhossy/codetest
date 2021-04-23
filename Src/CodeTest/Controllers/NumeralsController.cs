using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeralsController : ControllerBase
    {
        [HttpGet]
        public ActionResult NumeralsToDigits()
        {
            return Ok("Hello world");
        }
    }
}
