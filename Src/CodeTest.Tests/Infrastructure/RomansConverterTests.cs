using CodeTest.Web.Infrastructure;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodeTest.Tests
{
    public class RomansConverterTests
    {
        [Fact]
        public void ItShouldConstruct()
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act

            //Assert
            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("XLIX", 49)]
        [InlineData("MCMIII", 1903)]
        [InlineData("MCMXCVII", 1997)]
        [InlineData("MMMM", 4000)]
        [InlineData("", 0)]
        public void ItShouldConvert(
            string input, 
            int expected)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act
            int result = sut.FromNumeral(input);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('I', 1)]
        [InlineData('V', 5)]
        [InlineData('X', 10)]
        [InlineData('L', 50)]
        [InlineData('C', 100)]
        [InlineData('D', 500)]
        [InlineData('M', 1000)]
        public void ItShouldLookup(
            char letter, 
            int expectedValue)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act
            int returnedValue = sut.LookupChar(letter);

            //Assert
            Assert.Equal(expectedValue, returnedValue);
        }

        [Theory]
        [MemberData(nameof(InvalidRomanLetters))]
        public void ItShouldThrow(char letter)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => sut.LookupChar(letter));
        }

        [Theory]
        [MemberData(nameof(InvalidRomanLetters))]
        public void ItShouldReturn0IfInvalidChar(char letter)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act
            int result = sut.FromNumeral(letter.ToString());

            //Assert
            Assert.True(result == 0);

        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(19, "XIX")]
        [InlineData(49, "XLIX")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(900, "CM")]
        [InlineData(999, "CMXCIX")]
        [InlineData(1903, "MCMIII")]
        [InlineData(1997, "MCMXCVII")]
        [InlineData(4000, "MMMM")]
        public void ItShouldReturnNumeralFromValidDigit(
            int digit, 
            string expected)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act
            string result = sut.ToNumeral(digit);

            //Assert
            expected.Should().BeEquivalentTo(result);
        }

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        public void ItShouldReturnEmptyStringIfInvalidInput(
            int digit,
            string expected)
        {
            //Arrange
            RomansConverter sut = new RomansConverter();

            //Act
            string result = sut.ToNumeral(digit);

            //Assert
            expected.Should().BeEquivalentTo(result);
        }

        public static IEnumerable<object[]> InvalidRomanLetters
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { 'A'}, new object[] { 'B'}, new object[] { 'E'}, new object[] { 'F'}, new object[] { 'G'}, new object[] { 'H'},
                    new object[] { 'J'}, new object[] { 'K'}, new object[] { 'N'}, new object[] { 'O'}, new object[] { 'P'}, new object[] { 'Q'},
                    new object[] { 'R'}, new object[] { 'S'}, new object[] { 'T'}, new object[] { 'U'}, new object[] { 'W'}, new object[] { 'Y'}, 
                    new object[] { 'Z'},
                    new object[] { 'a'}, new object[] { 'b'}, new object[] { 'e'}, new object[] { 'f'}, new object[] { 'g'}, new object[] { 'h'},
                    new object[] { 'j'}, new object[] { 'k'}, new object[] { 'n'}, new object[] { 'o'}, new object[] { 'p'}, new object[] { 'q'},
                    new object[] { 'r'}, new object[] { 's'}, new object[] { 't'}, new object[] { 'u'}, new object[] { 'w'}, new object[] { 'y'}, 
                    new object[] { 'z'},
                    new object[] { '!'}, new object[] { '@'}, new object[] { '£'}, new object[] { '$'}, new object[] { '%'}, new object[] { '&'},
                    new object[] { '/'}, new object[] { '{'}, new object[] { '('}, new object[] { '['}, new object[] { ')'}, new object[] { ']'},
                    new object[] { '='}, new object[] { '+'}, new object[] { '?'}, new object[] { '¨'}, new object[] { '`'}, new object[] { '´'},
                    new object[] { '~'},
                };
            }
        }
    }
}
