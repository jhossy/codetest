using CodeTest.Web.Infrastructure;
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
        private readonly IRomansConverter _romansConverter;

        public NumeralsController(IRomansConverter romansConverter)
        {
            _romansConverter = romansConverter ?? throw new ArgumentNullException(nameof(romansConverter));
        }

        [HttpGet]
        public ActionResult NumeralsToDigits(string input)
        {
            if (string.IsNullOrEmpty(input)) return BadRequest();

            return Ok(_romansConverter.FromNumeral(input));
        }
    }
}
