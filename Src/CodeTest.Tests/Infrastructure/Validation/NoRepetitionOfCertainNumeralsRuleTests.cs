using CodeTest.Web.Infrastructure.Validation;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NoRepetitionOfCertainNumeralsRuleTests
    {
        [Theory]
        [InlineData("VV", false), InlineData("LL", false), InlineData("DD", false)]
        [InlineData("II", true), InlineData("XX", true), InlineData("MM", true)]
        [InlineData("VVV", false)]
        [InlineData("vv", false), InlineData("ll", false), InlineData("dd", false)]
        [InlineData("ii", true), InlineData("xx", true), InlineData("mm", true)]
        [InlineData(null, true)]
        public void ItShouldValidateRepetitionOfCertainChars(string input, bool expected)
        {
            //Arrange
            NoRepetitionOfCertainNumeralsRule sut = new NoRepetitionOfCertainNumeralsRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result == expected);
        }
    }
}
