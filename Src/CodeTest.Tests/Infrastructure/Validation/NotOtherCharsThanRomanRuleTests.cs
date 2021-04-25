using CodeTest.Web.Infrastructure.Validation;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NotOtherCharsThanRomanRuleTests
    {
        [Theory]
        [InlineData("A"), InlineData("a")]
        [InlineData("#"), InlineData("¤")]
        [InlineData("-"), InlineData("+")]
        [InlineData("IA"), InlineData("ia")]
        [InlineData(null)]
        public void ItShouldRejectInvalidChars(
            string input)
        {
            //Arrange
            NotOtherCharsThanRomanRule sut = new NotOtherCharsThanRomanRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("I"), InlineData("i")]
        [InlineData("V"), InlineData("v")]
        [InlineData("X"), InlineData("x")]
        [InlineData("L"), InlineData("l")]
        [InlineData("C"), InlineData("c")]
        [InlineData("D"), InlineData("d")]
        [InlineData("M"), InlineData("m")]        
        public void ItShouldNotRejectValidChars(
            string input)
        {
            //Arrange
            NotOtherCharsThanRomanRule sut = new NotOtherCharsThanRomanRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result);
        } 
    }
}
