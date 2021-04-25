using CodeTest.Web.Infrastructure.Validation;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NotMoreThanMinMaxDigitRuleTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(4000)]
        public void ItShouldAllowValidRange(int input)
        {
            //Arrange
            NotMoreThanMinMaxDigitRule sut = new NotMoreThanMinMaxDigitRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(4001)]
        public void ItShouldNotAllowInvalidRange(int input)
        {
            //Arrange
            NotMoreThanMinMaxDigitRule sut = new NotMoreThanMinMaxDigitRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.False(result);
        }
    }
}