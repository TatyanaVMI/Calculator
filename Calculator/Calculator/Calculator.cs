using Calculator.Operations;
using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator: ICalculator
    {
        private readonly IParser _parser;
        private readonly IOperationsProvider _operationsProvider;

        public Calculator(
            IParser parser,
            IOperationsProvider operationsProvider)
        {
            _parser = parser;
            _operationsProvider = operationsProvider;
        }
        
        public decimal Calculate(string expression)
        {
            var postfixNotationExpression = _parser.ParseToPostfixNotation(expression);

            var numbersStack = new Stack<decimal>();
            foreach (var token in postfixNotationExpression)
            {
                if (decimal.TryParse(token, out var number))
                {
                    numbersStack.Push(number);
                }
                else if (_operationsProvider.TryGetOperation(token, out var operation))
                {
                    var arg2 = numbersStack.Pop();
                    var arg1 = numbersStack.Pop();
                    var result = operation.Calculate(arg1, arg2);
                    numbersStack.Push(result);
                }
                else
                {
                    var errorMessage = string.Format(Constants.InvalidTokenErrorMessage, token);
                    throw new ArgumentException(errorMessage);
                }
            }

            return numbersStack.Peek();
        }
    }  
}
