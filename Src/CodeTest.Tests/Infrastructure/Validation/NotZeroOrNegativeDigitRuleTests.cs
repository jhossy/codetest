using CodeTest.Web.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTest.Tests.Infrastructure.Validation
{
    public class NotZeroOrNegativeDigitRuleTests
    {
        [Theory]
        [InlineData(1)]
        public void ItShouldValidate(int input)
        {
            //Arrange
            NotZeroOrNegativeDigitRule sut = new NotZeroOrNegativeDigitRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ItShouldNotValidate(int input)
        {
            //Arrange
            NotZeroOrNegativeDigitRule sut = new NotZeroOrNegativeDigitRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.False(result);
        }
    }
}
