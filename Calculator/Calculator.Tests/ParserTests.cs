using Calculator.Operations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class ParserTests
    {
        private Parser _parser;
    
        [SetUp]
        public void Setup()
        {
            var operations = new List<IOperation> { new AdditionOperation(), new SubtractionOperation(), new MultiplyOperation(), new DivisionOperation() };
            var operationsProvider = new OperationsProvider(operations);
            _parser = new Parser(operationsProvider);
        }

        [Test]
        public void CheckParsingOfAllOperationTypes()
        {
            var expression = "3+4*2/(1-5)-1";
            var expectedResult = new List<string>() { "3", "4", "2", "*", "1", "5", "-", "/", "+", "1", "-" };
            var result = _parser.ParseToPostfixNotation(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenExpressionContainsWhiteSpaceShouldIgnoreIt()
        {
            var expression = "1 + 1";
            var expectedResult = new List<string>() { "1", "1", "+" };
            var result = _parser.ParseToPostfixNotation(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenExpressionContainsInvalidCharShouldThrowEx()
        {
            var expression = "1 ~ 1";

            Assert.Throws<ArgumentException>(() => _parser.ParseToPostfixNotation(expression));
        }

        [Test]
        public void WhenExpressionContainsExtraBracketShouldThrowEx()
        {
            var expression = "1*(3-1))";

            Assert.Throws<ArgumentException>(() => _parser.ParseToPostfixNotation(expression));
        }
    }
}