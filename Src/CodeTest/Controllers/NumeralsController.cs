﻿using CodeTest.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeralsController : ControllerBase
    {
        private readonly INumeralsValidator _numeralsValidator;
        private readonly IRomansConverter _romansConverter;        

        public NumeralsController(
            INumeralsValidator numeralsValidator,
            IRomansConverter romansConverter)
        {            
            _numeralsValidator = numeralsValidator ?? throw new ArgumentNullException(nameof(numeralsValidator));
            _romansConverter = romansConverter ?? throw new ArgumentNullException(nameof(romansConverter));
        }

        [HttpGet]
        public ActionResult NumeralsToDigits(string input)
        {
            bool isValidInput = _numeralsValidator.Validate(input);

            if (!isValidInput) return BadRequest("0");

            return Ok(_romansConverter.FromNumeral(input));
        }
    }
}
