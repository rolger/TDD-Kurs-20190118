using FluentAssertions;
using System;
using Xunit;

namespace XUnitExercise
{
    public class StringCalculatorTest
    {
        private StringCalculator calc;

        public StringCalculatorTest()
        {
            calc = new StringCalculator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("0,a")]
        public void CheckInvalidInput(string invalidParam)
        {
            Action addAction = () => calc.Add(invalidParam);
            addAction.Should().Throw<ArgumentException>();
            Action subractAction = () => calc.Subtract(invalidParam);
            subractAction.Should().Throw<ArgumentException>();
            Action multiplyAction = () => calc.Multiply(invalidParam);
            multiplyAction.Should().Throw<ArgumentException>();
            Action divideAction = () => calc.Divide(invalidParam);
            divideAction.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void AddingValidNumbersCalculatesSum()
        {
            calc.Add("1").Should().Be(1);
            calc.Add("1, 5,6").Should().Be(12);
        }

        [Fact]
        public void SubtractingValidNumbersCalculatesDifference()
        {
            calc.Subtract("1").Should().Be(1);
            calc.Subtract("10,5, 6").Should().Be(-1);
        }

        [Fact]
        public void MultiplyingValidNumberCalculatesProduct()
        {
            calc.Multiply("1").Should().Be(1);
            calc.Multiply("10,5, 6").Should().Be(300);
        }

        [Fact]
        public void DividingValidNumbersCalculatesQuotient()
        {
            calc.Divide("1").Should().Be(1);
            calc.Divide("10,2, 1").Should().Be(5);
        }

        [Fact]
        public void SubtractingValidNumbersReverseCalculatesDifference()
        {
            calc.SubtractR("1").Should().Be(1);
            calc.SubtractR("10, 2, 6").Should().Be(-6);
        }

        [Fact]
        public void DividingValidNumbersReverseCalculatesQuotient()
        {
            calc.DivideR("1").Should().Be(1);
            calc.DivideR("10,2, 6").Should().Be(0.3M);
        }

    }
}
