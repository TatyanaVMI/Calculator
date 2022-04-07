using Calculator.Operations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class DivisionOperationTests
    {
        private readonly DivisionOperation _operation = new DivisionOperation();
        
        [Test]
        public void Calculate4Divide2Return2()
        {           
            var result = _operation.Calculate(new List<decimal>() { 4, 2 });

            Assert.AreEqual(2, result);
        }

        [Test]
        public void WhenDivideToZeroShouldReturnException()
        {
            Assert.Throws<DivideByZeroException>(() => _operation.Calculate(new List<decimal>() { 4, 0 }));
        }
    }
}