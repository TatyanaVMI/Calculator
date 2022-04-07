using System.Collections.Generic;

namespace Calculator.Operations
{
    public interface IOperation
    {
        char CharRepresentation { get; }

        int Priority { get; }

        bool IsUnary { get; }

        decimal Calculate(List<decimal> arguments);
    }
}
