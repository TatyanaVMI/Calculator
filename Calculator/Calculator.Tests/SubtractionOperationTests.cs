using Calculator.Operations;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class SubtractionOperationTests
    {
        [Test]
        public void Calculate4Minus2Return2()
        {
            var operation = new SubtractionOperation();

            var result = operation.Calculate(new List<decimal>() { 4, 2 });

            Assert.AreEqual(2, result);
        }
    }
}