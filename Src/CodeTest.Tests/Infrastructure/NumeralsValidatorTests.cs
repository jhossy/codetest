using CodeTest.Web.Infrastructure;
using CodeTest.Web.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTest.Tests.Infrastructure
{
    public class NumeralsValidatorTests
    {
        [Theory]
        [InlineData("I")]
        [InlineData("V")]
        [InlineData("X")]
        [InlineData("L")]
        [InlineData("C")]
        [InlineData("D")]
        [InlineData("M")]
        public void ItShouldAcceptValidInput(string input)
        {
            //Arrange
            NumeralsValidator sut = new NumeralsValidator();

            //Act
            bool result = sut.Validate(input);

            //Assert
            Assert.True(result);
        }

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
        public void ItShouldValidateFourLettersInARow(string input, bool expected)
        {
            //Arrange
            NotFourSameLettersInARowRule sut = new NotFourSameLettersInARowRule();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result == expected);
        }

        [Theory]
        [InlineData("VV", false), InlineData("LL", false), InlineData("DD", false)]
        [InlineData("II", true), InlineData("XX", true), InlineData("MM", true)]
        [InlineData("VVV", false)]
        [InlineData("vv", false), InlineData("ll", false), InlineData("dd", false)]
        [InlineData("ii", true), InlineData("xx", true), InlineData("mm", true)]
        public void ItShouldValidateRepetitionOfCertainChars(string input, bool expected)
        {
            //Arrange
            NoRepetitionOfCertainNumerals sut = new NoRepetitionOfCertainNumerals();

            //Act
            bool result = sut.IsSatisfiedBy(input);

            //Assert
            Assert.True(result == expected);
        }
        
    }
}
