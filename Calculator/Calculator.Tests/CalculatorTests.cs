using Calculator.Operations;
using Calculator.Tests.Helpers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private readonly Mock<IParser> _parserMock = new Mock<IParser>();
        private readonly InputToPostfixExpression _inputToPostfix = new InputToPostfixExpression();
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
            var inputExpression = InputExpression.ExpressionWithSpaces;
            decimal expectedResult = 3;

            _parserMock
                .Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == InputExpression.ExpressionWithSpaces)))
                .Returns(_inputToPostfix.dictionary[InputExpression.ExpressionWithSpaces]);                       

            var result = _calculator.Calculate(inputExpression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateComplexExpression()
        {
            var inputExpression = InputExpression.ExpressionWithAllOperationTypes;
            decimal expectedResult = 0;

            _parserMock
                .Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == InputExpression.ExpressionWithAllOperationTypes)))
                .Returns(_inputToPostfix.dictionary[InputExpression.ExpressionWithAllOperationTypes]);

            var result = _calculator.Calculate(inputExpression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenExpressionContainsOnlyNumberShouldReflectIt()
        {
            var inputExpression = InputExpression.DecimalNumber;
            var expectedResult = 2.5;

            _parserMock
                .Setup(m => m.ParseToPostfixNotation(It.Is<string>(s => s == InputExpression.DecimalNumber)))
                .Returns(_inputToPostfix.dictionary[InputExpression.DecimalNumber]);

            var result = _calculator.Calculate(inputExpression);
            Assert.AreEqual(expectedResult, result);
        }
    }
}