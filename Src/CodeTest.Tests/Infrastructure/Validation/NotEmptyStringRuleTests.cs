using CodeTest.Web.Infrastructure.Validation;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NotEmptyStringRuleTests
    {

        [Theory]
        [InlineData("", false), InlineData(" ", false)]
        [InlineData(null, false)]
        public void ItShouldValidateEmptyString(string input, bool expected)
        {
            //Arrange
            NotEmptyStringRule sut = new NotEmptyStringRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result == expected);
        }
    }
}
