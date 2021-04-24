using AutoFixture.Xunit2;
using CodeTest.Web.Infrastructure;
using CodeTest.Web.Infrastructure.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTest.Tests.Infrastructure
{
    public class NumeralsValidatorTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            Mock<IValidationRuleProvider> mockRuleProvider = new Mock<IValidationRuleProvider>();

            //Act
            NumeralsValidator sut = new NumeralsValidator(mockRuleProvider.Object);

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void ItShouldThrowWhenConstructing()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new NumeralsValidator(null));
        }

        [Theory]
        [InlineData("I")]
        [InlineData("V")]
        [InlineData("X")]
        [InlineData("L")]
        [InlineData("C")]
        [InlineData("D")]
        [InlineData("M")]
        public void ItShouldAcceptValidNumeral(string input)
        {
            //Arrange            
            Mock<IValidationRuleProvider> mockRuleProvider = new Mock<IValidationRuleProvider>();
            NumeralsValidator sut = new NumeralsValidator(mockRuleProvider.Object);

            //Act
            bool result = sut.Validate(input);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineAutoData(true)]
        [InlineAutoData(false)]
        public void ItShouldReturnTrueIfAllValidationSucceeds(             
            bool expected,
            string input)
        {
            //Arrange            

            Mock<INumeralsValidationRule<string>> mockRule = new Mock<INumeralsValidationRule<string>>();
            mockRule.Setup(mockRule => mockRule.IsSatisfiedBy(input))
                .Returns(expected);

            Mock<IValidationRuleProvider> mockRuleProvider = new Mock<IValidationRuleProvider>();
            mockRuleProvider.Setup(mockRuleProvider => mockRuleProvider.GetRules())
                .Returns(new INumeralsValidationRule<string>[] { mockRule.Object });

            NumeralsValidator sut = new NumeralsValidator(mockRuleProvider.Object);

            //Act
            bool result = sut.Validate(input);

            //Assert
            Assert.True(result == expected);
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
