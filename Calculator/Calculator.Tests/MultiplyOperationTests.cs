using Calculator.Operations;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class MultiplyOperationTests
    {
        [Test]
        public void Calculate2Multiply2Return4()
        {
            var operation = new MultiplyOperation();
            
            var result = operation.Calculate(new List<decimal>() { 2, 2 });

            Assert.AreEqual(4, result);
        }
    }
}