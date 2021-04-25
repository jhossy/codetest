using CodeTest.Web.Infrastructure.Validation;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NotMoreThanMinMaxNumeralRuleTests
    {
        [Theory]
        [InlineData("III")]
        [InlineData("MMMM")]
        public void ItShouldAllowValidRange(string input)
        {
            //Arrange
            NotMoreThanMinMaxNumeralRule sut = new NotMoreThanMinMaxNumeralRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("MMMMI")]
        [InlineData("MMMM ")]
        public void ItShouldNotAllowInvalidRange(string input)
        {
            //Arrange
            NotMoreThanMinMaxNumeralRule sut = new NotMoreThanMinMaxNumeralRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.False(result);
        }
    }
}
