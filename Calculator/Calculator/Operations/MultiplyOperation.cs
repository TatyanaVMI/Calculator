namespace Calculator.Operations
{
    public class MultiplyOperation : IOperation
    {
        public char CharRepresentation => '*';

        public int Priority => 2;

        public decimal Calculate(decimal arg1, decimal arg2)
        {
            return arg1 * arg2;
        }
    }
}
