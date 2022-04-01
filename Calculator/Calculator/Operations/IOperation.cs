namespace Calculator.Operations
{
    public interface IOperation
    {
        char CharRepresentation { get; }

        int Priority { get; }

        decimal Calculate(decimal arg1, decimal arg2);
    }
}
