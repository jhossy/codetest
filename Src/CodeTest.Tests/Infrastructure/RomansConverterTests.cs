using CodeTest.Web.Infrastructure;
using System;
using Xunit;

namespace CodeTest.Tests
{
    public class RomansConverterTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act

            //Assert
            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("MCMIII", 1903)]
        [InlineData("MCMXCVII", 1997)]
        [InlineData("MMMM", 4000)]
        [InlineData("", 0)]
        public void ItShouldConvert(string input, int expected)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act
            int result = sut.FromNumeral(input);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
