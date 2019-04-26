using System;
using Xunit;
using FluentAssertions;
namespace ROT_13
{
    public class EncoderTest
    {
        [Theory]
        [InlineData("1", "1")]
        [InlineData(" ", " ")]
        [InlineData(",", ",")]
        public void NonLettersAreNotModified(string input, string expectedResult)
        {
            string result = Rotate(input);
            result.Should().Be(expectedResult);
        }
        [Theory]
        [InlineData("H", "U")]
        [InlineData("E", "R")]
        public void UpperCaseLettersAreEncoded(string input, string expectedResult)
        {
            string result = Rotate(input);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Ö", "BR")]
        [InlineData("Ü", "HR")]
        [InlineData("Ä", "NR")]
        [InlineData("ß", "FF")]
        public void UmlautsAreEncoded(string input, string expectedResult)
        {
            string result = Rotate(input);
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void LowerCaseLettersAreEncoded()
        {
            string result = Rotate("h");
            result.Should().Be("U");
        }

        [Fact]
        public void LetterRotateInsideTheAlphabet()
        {
            string result = Rotate("W");
            result.Should().Be("J");
        }

        [Fact]
        public void RotateSentence()
        {
            string result = Rotate("Hello, World");
            result.Should().Be("URYYB, JBEYQ");
        }

        private string Rotate(string input)
        {
            new Encoder().Rotate(input);
        }

    }
}
