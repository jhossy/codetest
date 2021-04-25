using CodeTest.Web.Controllers;
using CodeTest.Web.Infrastructure;
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
    }
}
