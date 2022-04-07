using System.Collections.Generic;

namespace Calculator.Operations
{
    public class SubtractionOperation : IOperation
    {
        public char CharRepresentation => '-';

        public int Priority => 1;

        public bool IsUnary => false;

        public decimal Calculate(List<decimal> arguments)
        {
            return arguments[0] - arguments[1];
        }
    }
}
