using CodeTest.Web.Infrastructure.Validation;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NotFourSameLettersInARowRuleTests
    {
        [Theory]
        [InlineData("I", true), InlineData("II", true), InlineData("III", true), InlineData("IIII", false)]
        [InlineData("B", true), InlineData("BB", true), InlineData("BBB", true), InlineData("BBBB", false)]
        [InlineData("IIIVI", true), InlineData("VIII", true), InlineData("IIIIV", false), InlineData("VIIII", false)]
        [InlineData("MMMM", true)]
        [InlineData("i", true), InlineData("ii", true), InlineData("iii", true), InlineData("iiii", false)]
        [InlineData("b", true), InlineData("bb", true), InlineData("bbb", true), InlineData("bbbb", false)]
        [InlineData("iiivi", true), InlineData("viii", true), InlineData("iiiiv", false), InlineData("viiii", false)]
        [InlineData("mmmm", true)]
        [InlineData("iIIv", true), InlineData("iiiiV", false)]
        [InlineData(null, true)]
        public void ItShouldValidateFourLettersInARow(string input, bool expected)
        {
            //Arrange
            NotFourSameLettersInARowRule sut = new NotFourSameLettersInARowRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result == expected);
        }
    }
}
