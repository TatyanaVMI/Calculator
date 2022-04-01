using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class SubtractionOperationTests
    {
        [Test]
        public void Calculate4Minus2Return2()
        {
            var operation = new SubtractionOperation();

            var result = operation.Calculate(4, 2);

            Assert.AreEqual(2, result);
        }
    }
}