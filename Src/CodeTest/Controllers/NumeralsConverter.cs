using System;
using Xunit;

namespace CodeTest.Tests
{
    public class NumeralsConverter
    {
        [Fact]
        public void ItSHouldConstruct()
        {
            //Arrange
            NumeralsConverter sut = new NumeralsConverter();

            //Act

            //Assert
            Assert.NotNull(sut);
        }
    }
}
