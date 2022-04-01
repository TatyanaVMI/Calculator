using Calculator.Operations;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private readonly Mock<IParser> _parserMock = new Mock<IParser>();
        private ICalculator _calculator;

        [SetUp]
        public void Setup()
        {
            var operations = new List<IOperation> { new AdditionOperation(), new SubtractionOperation(), new MultiplyOperation(), new DivisionOperation() };
            var operationsProvider = new OperationsProvider(operations);
            _calculator = new Calculator(_parserMock.Object, operationsProvider);
        }

        [Test]
        public void Calculate1Plus2Return3()
        {
            var inputExpression = "1+2";
            decimal expectedResult = 3;

            _parserMock.Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == "1+2"))).Returns(new List<string> { "1", "2", "+" });                       

            var result = _calculator.Calculate(inputExpression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateComplexExpression()
        {
            var inputExpression = "3+4*2/(1-5)-1";
            decimal expectedResult = 0;

            _parserMock.Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == "3+4*2/(1-5)-1"))).Returns(new List<string>() { "3", "4", "2", "*", "1", "5", "-", "/", "+", "1", "-" });

            var result = _calculator.Calculate(inputExpression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenExpressionContainsOnlyNumberShouldReflectIt()
        {
            var inputExpression = "2.5";
            var expectedResult = 2.5;

            _parserMock.Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == "2.5"))).Returns(new List<string>() { "2.5" });

            var result = _calculator.Calculate(inputExpression);
            Assert.AreEqual(expectedResult, result);
        }
    }
}