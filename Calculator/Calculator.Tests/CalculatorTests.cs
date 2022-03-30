using Moq;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class Tests
    {
        private ICalculator _calculator;
        private readonly Mock<Parser> _parser = new Mock<Parser>();
    
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator(_parser.Object);
        }

        [TestCase("1+2", 3)]
        public void Test1(string expression, decimal expectedResult)
        {
            var result = _calculator.Calculate(expression);    
            Assert.AreEqual(result, expectedResult);
        }
    }
}