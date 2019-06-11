using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Stack;
using FluentAssertions;

namespace Algorithms.Test.Stack
{
    public class BasicCalculatorTests
    {
        [Fact]
        public void Only2Operands()
        {
            var inputExpression = "1 + 1";
            var expectedOutput = 2;

            var actualOutput = BasicCalculatorV2.Evaluate(inputExpression);
            actualOutput.Should().Be(expectedOutput);

        }

        [Fact]
        public void MoreThan2Operands()
        {
            var inputExpression = " 2-1 + 2 ";
            var expectedOutput = 3;

            var actualOutput = BasicCalculatorV2.Evaluate(inputExpression);
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void OperandsAndBraces()
        {
            var inputExpression = "(1+(4+5+2)-3)+(6+8)";
            var expectedOutput = 23;

            var actualOutput = BasicCalculatorV2.Evaluate(inputExpression);
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void OperandsAndBracesWithGreaterThan10()
        {
            var inputExpression = "99 + (1+(4+5+2)-3)+(6+8)";
            var expectedOutput = 122;

            var actualOutput = BasicCalculatorV2.Evaluate(inputExpression);
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void OnlyOneOperand()
        {
            var inputExpression = "234567";
            var expectedOutput = 234567;

            var actualOutput = BasicCalculatorV2.Evaluate(inputExpression);
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void OperandsAndBracesBigNumbers()
        {
            var inputExpression = "990999 + 123912381297 - 888";
            var expectedOutput = 123913371408;

            var actualOutput = BasicCalculatorV2.Evaluate(inputExpression);
            actualOutput.Should().Be(expectedOutput);
        }
    }
}
