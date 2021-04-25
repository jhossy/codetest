using AutoFixture.Xunit2;
using CodeTest.Web.Controllers;
using CodeTest.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace CodeTest.Tests.Controllers
{
    public class DigitsControllerTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            Mock<IDigitsValidator> mockDigitsValidator = new Mock<IDigitsValidator>();
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();

            DigitsController sut = new DigitsController(mockDigitsValidator.Object, mockRomansConverter.Object);

            //Act

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void ItShouldThrow()
        {
            //Arrange
            Mock<IDigitsValidator> mockDigitsValidator = new Mock<IDigitsValidator>();
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();
            
            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new DigitsController(null, mockRomansConverter.Object));
            Assert.Throws<ArgumentNullException>(() => new DigitsController(mockDigitsValidator.Object, null));
        }

        [Theory]
        [AutoData]
        public void ItShouldReturnBadRequest(int input)
        {
            //Arrange
            Mock<IDigitsValidator> mockDigitsValidator = new Mock<IDigitsValidator>();
            mockDigitsValidator.Setup(mockDigitsValidator => mockDigitsValidator.Validate(input))
                .Returns(false);
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();

            DigitsController sut = new DigitsController(mockDigitsValidator.Object, mockRomansConverter.Object);

            //Act
            IActionResult result = sut.DigitToNumerals(input);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [AutoData]
        public void ItShouldReturnOkResult(int input)
        {
            //Arrange
            Mock<IDigitsValidator> mockDigitsValidator = new Mock<IDigitsValidator>();
            mockDigitsValidator.Setup(mockDigitsValidator => mockDigitsValidator.Validate(input))
                .Returns(true);
            Mock<IRomansConverter> mockRomansConverter = new Mock<IRomansConverter>();
            mockRomansConverter.Setup(mockRomansConverter => mockRomansConverter.ToNumeral(input))
                .Returns("I");

            DigitsController sut = new DigitsController(mockDigitsValidator.Object, mockRomansConverter.Object);

            //Act
            IActionResult result = sut.DigitToNumerals(input);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
