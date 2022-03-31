using Calculator.Operations;
using Moq;
using NUnit.Framework;
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
            var operations = new List<IOperation> { new AdditionOperation(), new SubtractionOperation() };
            var operationsProvider = new OperationsProvider(operations);
            _calculator = new Calculator(_parserMock.Object, operationsProvider);
        }

        [Test]
        public void Test1()
        {
            var inputExpression = "1+2";
            decimal expectedResult = 3;

            _parserMock.Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == "1+2"))).Returns(new List<string> { "1", "2", "+" });                       

            var result = _calculator.Calculate(inputExpression);    
            Assert.AreEqual(expectedResult, result);
        }
    }
}