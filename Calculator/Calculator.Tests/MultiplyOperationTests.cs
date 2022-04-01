using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class MultiplyOperationTests
    {
        [Test]
        public void Calculate2Multiply2Return4()
        {
            var operation = new MultiplyOperation();
            
            var result = operation.Calculate(2, 2);

            Assert.AreEqual(4, result);
        }
    }
}