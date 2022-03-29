using Calculator.Operations;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
    
        public decimal Calculate(string expression)
        {
            var postfixNotationExpression = new Parser(new List<IOperation> { new AdditionOperation(), new SubtractionOperation() }).Parse(expression);

            return 1;
        }
    }  
}
