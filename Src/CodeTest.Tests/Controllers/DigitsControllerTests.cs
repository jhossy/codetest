using CodeTest.Web.Controllers;
using CodeTest.Web.Infrastructure;
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
    }
}
