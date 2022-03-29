using NUnit.Framework;

namespace Calculator.Tests
{
    public class Tests
    {
        private Calculator _calculator;    
    
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestCase("1+2", 1)]
        public void Test1(string expression, decimal expectedResult)
        {
            var result = _calculator.Calculate(expression);    
            Assert.AreEqual(result, expectedResult);
        }
    }
}