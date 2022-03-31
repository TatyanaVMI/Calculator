using Calculator.Operations;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class ParserTests
    {
        private Parser _parser;
    
        [SetUp]
        public void Setup()
        {
            var operations = new List<IOperation> { new AdditionOperation(), new SubtractionOperation() };
            _parser = new Parser(operations);
        }

        [Test]
        public void CheckParsingOfAllOperationTypes()
        {
            var expression = "3+4*2/(1-5)-1";
            var expectedResult = new string[] { "3", "4", "2", "*", "1", "5", "−", "/", "1", "-" };
            var result = _parser.ParseToPostfixNotation(expression);
            Assert.AreEqual(expectedResult, result);
        }
    }
}