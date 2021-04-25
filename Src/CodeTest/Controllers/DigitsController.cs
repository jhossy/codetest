using CodeTest.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitsController : ControllerBase
    {
        private readonly IDigitsValidator _digitsValidator;
        private readonly IRomansConverter _romansConverter;        

        public DigitsController(
            IDigitsValidator digitsValidator,
            IRomansConverter romansConverter)
        {
            _digitsValidator = digitsValidator ?? throw new ArgumentNullException(nameof(digitsValidator));
            _romansConverter = romansConverter ?? throw new ArgumentNullException(nameof(romansConverter));
        }

        [HttpGet]
        public ActionResult DigitToNumerals(int input)
        {
            if (!_digitsValidator.Validate(input)) return BadRequest("");

            return Ok(_romansConverter.ToNumeral(input));
        }
    }
}
