using CodeTest.Web.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

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
        [InlineData("MCMIII", 1903)]
        [InlineData("MCMXCVII", 1997)]
        [InlineData("MMMM", 4000)]
        [InlineData("", 0)]
        public void ItShouldConvert(string input, int expected)
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
        public void ItShouldLookup(char letter, int expectedValue)
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
