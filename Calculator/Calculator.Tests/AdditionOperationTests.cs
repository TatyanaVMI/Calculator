using Calculator.Operations;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class AdditionOperationTests
    {
        [Test]
        public void Calculate2Plus2Return4()
        {
            var operation = new AdditionOperation();
            
            var result = operation.Calculate(new List<decimal>() { 2, 2 });

            Assert.AreEqual(4, result);
        }
    }
}