using System.Collections.Generic;

namespace Calculator.Operations
{
    public class UnaryMinus : IOperation
    {
        public char CharRepresentation => '-';

        public int Priority => 3;

        public bool IsUnary => true;

        public decimal Calculate(List<decimal> arguments)
        {
            return 0 - arguments[0];
        }
    }
}
