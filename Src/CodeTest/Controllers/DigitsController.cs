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
    public class DigitsController : ControllerBase
    {
        private readonly IRomansConverter _romansConverter;
        public DigitsController(IRomansConverter romansConverter)
        {
            _romansConverter = romansConverter ?? throw new ArgumentNullException(nameof(romansConverter));
        }

        [HttpGet]
        public ActionResult DigitToNumerals(int input)
        {
            if (input <= 0 || input > 4000) return BadRequest();

            return Ok(_romansConverter.ToNumeral(input));
        }
    }
}
