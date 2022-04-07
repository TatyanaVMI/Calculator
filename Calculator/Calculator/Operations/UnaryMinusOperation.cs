using System.Collections.Generic;

namespace Calculator.Operations
{
    public class UnaryMinusOperation : IOperation
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
