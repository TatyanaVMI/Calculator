namespace Calculator.Operations
{
    public class SubtractionOperation : IOperation
    {
        public char CharRepresentation => '-';

        public decimal Calculate(decimal arg1, decimal arg2)
        {
            return arg1 - arg2;
        }
    }
}
