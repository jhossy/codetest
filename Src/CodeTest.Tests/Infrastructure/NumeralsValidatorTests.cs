using AutoFixture.Xunit2;
using CodeTest.Web.Infrastructure;
using CodeTest.Web.Infrastructure.Validation;
using Moq;
using System;
using Xunit;

namespace CodeTest.Tests.Infrastructure
{
    public class NumeralsValidatorTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            Mock<IValidationRuleProvider<string>> mockRuleProvider = new Mock<IValidationRuleProvider<string>>();

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
            Mock<IValidationRuleProvider<string>> mockRuleProvider = new Mock<IValidationRuleProvider<string>>();
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

            Mock<IValidationRule<string>> mockRule = new Mock<IValidationRule<string>>();
            mockRule.Setup(mockRule => mockRule.IsSatisfiedBy(input))
                .Returns(expected);

            Mock<IValidationRuleProvider<string>> mockRuleProvider = new Mock<IValidationRuleProvider<string>>();
            mockRuleProvider.Setup(mockRuleProvider => mockRuleProvider.GetRules())
                .Returns(new IValidationRule<string>[] { mockRule.Object });

            NumeralsValidator sut = new NumeralsValidator(mockRuleProvider.Object);

            //Act
            bool result = sut.Validate(input);

            //Assert
            Assert.True(result == expected);
        }


       

    }
}
