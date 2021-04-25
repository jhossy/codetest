using AutoFixture.Xunit2;
using CodeTest.Web.Controllers;
using CodeTest.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace CodeTest.Tests.Controllers
{
    public class NumeralsControllerTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            Mock<INumeralsValidator> mockNumeralsValidator = new Mock<INumeralsValidator>();
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();

            NumeralsController sut = new NumeralsController(mockNumeralsValidator.Object, mockRomansConverter.Object);

            //Act

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void ItShouldThrow()
        {
            //Arrange
            Mock<INumeralsValidator> mockNumeralsValidator = new Mock<INumeralsValidator>();
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new NumeralsController(null, mockRomansConverter.Object));
            Assert.Throws<ArgumentNullException>(() => new NumeralsController(mockNumeralsValidator.Object, null));
        }

        [Theory]
        [AutoData]
        public void ItShouldReturnBadRequest(string input)
        {
            //Arrange
            Mock<INumeralsValidator> mockNumeralsValidator = new Mock<INumeralsValidator>();
            mockNumeralsValidator.Setup(mockNumeralsValidator => mockNumeralsValidator.Validate(input))
                .Returns(false);
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();

            NumeralsController sut = new NumeralsController(mockNumeralsValidator.Object, mockRomansConverter.Object);

            //Act
            IActionResult result = sut.NumeralsToDigits(input);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [AutoData]
        public void ItShouldReturnOkResult(string input)
        {
            //Arrange
            Mock<INumeralsValidator> mockNumeralsValidator = new Mock<INumeralsValidator>();
            mockNumeralsValidator.Setup(mockNumeralsValidator => mockNumeralsValidator.Validate(input))
                .Returns(true);
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();
            mockRomansConverter.Setup(mockRomansConverter => mockRomansConverter.FromNumeral(input))
                .Returns(1);

            NumeralsController sut = new NumeralsController(mockNumeralsValidator.Object, mockRomansConverter.Object);

            //Act
            IActionResult result = sut.NumeralsToDigits(input);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
