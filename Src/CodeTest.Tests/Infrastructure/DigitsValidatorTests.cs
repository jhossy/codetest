using AutoFixture.Xunit2;
using CodeTest.Web.Infrastructure;
using CodeTest.Web.Infrastructure.Validation;
using Moq;
using System;
using Xunit;

namespace CodeTest.Tests.Infrastructure
{
    public class DigitsValidatorTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            Mock<IValidationRuleProvider<int>> mockRuleProvider = new Mock<IValidationRuleProvider<int>>();

            //Act
            DigitsValidator sut = new DigitsValidator(mockRuleProvider.Object);

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void ItShouldThrowWhenConstructing()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new DigitsValidator(null));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(90)]
        [InlineData(900)]
        [InlineData(1903)]
        [InlineData(1997)]
        [InlineData(4000)]
        public void ItShouldAcceptValidNumeral(int input)
        {
            //Arrange            
            Mock<IValidationRuleProvider<int>> mockRuleProvider = new Mock<IValidationRuleProvider<int>>();
            DigitsValidator sut = new DigitsValidator(mockRuleProvider.Object);

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
            int input)
        {
            //Arrange            

            Mock<IValidationRule<int>> mockRule = new Mock<IValidationRule<int>>();
            mockRule.Setup(mockRule => mockRule.IsSatisfiedBy(input))
                .Returns(expected);

            Mock<IValidationRuleProvider<int>> mockRuleProvider = new Mock<IValidationRuleProvider<int>>();
            mockRuleProvider.Setup(mockRuleProvider => mockRuleProvider.GetRules())
                .Returns(new IValidationRule<int>[] { mockRule.Object });

            DigitsValidator sut = new DigitsValidator(mockRuleProvider.Object);

            //Act
            bool result = sut.Validate(input);

            //Assert
            Assert.True(result == expected);
        }


       

    }
}
