namespace Calculator.Operations
{
    public class SubtractionOperation : IOperation
    {
        public char CharRepresentation => '-';

        public int Priority => 1;

        public decimal Calculate(decimal arg1, decimal arg2)
        {
            return arg1 - arg2;
        }
    }
}
