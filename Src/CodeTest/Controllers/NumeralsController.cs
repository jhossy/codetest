using CodeTest.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeralsController : ControllerBase
    {
        private readonly IRomansConverter _romansConverter;
        private readonly INumeralsValidator _numeralsValidator;

        public NumeralsController(
            IRomansConverter romansConverter,
            INumeralsValidator numeralsValidator)
        {
            _romansConverter = romansConverter ?? throw new ArgumentNullException(nameof(romansConverter));
            _numeralsValidator = numeralsValidator ?? throw new ArgumentNullException(nameof(numeralsValidator));
        }

        [HttpGet]
        public ActionResult NumeralsToDigits(string input)
        {
            bool isValidInput = _numeralsValidator.Validate(input);

            if (!isValidInput) return BadRequest();

            return Ok(_romansConverter.FromNumeral(input));
        }
    }
}
