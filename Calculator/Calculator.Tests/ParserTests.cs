using Calculator.Operations;
using Calculator.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class ParserTests
    {
        private Parser _parser;
        private readonly InputToPostfixExpression _inputToPostfix = new InputToPostfixExpression();
    
        [SetUp]
        public void Setup()
        {
            var operations = new List<IOperation> { new AdditionOperation(), new SubtractionOperation(), new MultiplyOperation(), new DivisionOperation(), new UnaryMinusOperation() };
            var operationsProvider = new OperationsProvider(operations);
            _parser = new Parser(operationsProvider);
        }

        [Test]
        public void ParseAllOperationTypes()
        {
            var expression = InputExpression.ExpressionWithAllOperationTypes;
            var expectedResult = _inputToPostfix.dictionary[InputExpression.ExpressionWithAllOperationTypes];
            var result = _parser.ParseToPostfixNotation(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenExpressionContainsWhiteSpaceShouldIgnoreIt()
        {
            var expression = InputExpression.ExpressionWithSpaces;
            var expectedResult = _inputToPostfix.dictionary[InputExpression.ExpressionWithSpaces];
            var result = _parser.ParseToPostfixNotation(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenExpressionContainsInvalidCharShouldThrowEx()
        {
            var expression = InputExpression.ExpressionWithInvalidCharacter;

            Assert.Throws<ArgumentException>(() => _parser.ParseToPostfixNotation(expression));
        }

        [Test]
        public void WhenExpressionContainsExtraBracketShouldThrowEx()
        {
            var expression = InputExpression.ExpressionWithExtraBracket;

            Assert.Throws<ArgumentException>(() => _parser.ParseToPostfixNotation(expression));
        }

        [Test]
        public void ParseExpressionWithNegativeNumbers()
        {
            var expression = InputExpression.ExpressionWithNegativeNumbers;
            var expectedResult = _inputToPostfix.dictionary[InputExpression.ExpressionWithNegativeNumbers];

            var result = _parser.ParseToPostfixNotation(expression);

            Assert.AreEqual(expectedResult, result);
        }
    }
}