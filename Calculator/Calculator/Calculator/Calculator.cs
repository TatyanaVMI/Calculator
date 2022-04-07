using Calculator.Models;
using Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Globalization;

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
                if (token is OperandToken
                    && decimal.TryParse(token.Value, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var number))
                {
                    numbersStack.Push(number);
                }
                else if (token is OperationToken operationToken
                    && _operationsProvider.TryGetOperation(token.Value, out var operation, operationToken.IsUnary))
                {                                      
                    var arguments = new List<decimal>();
                    if (operationToken.IsUnary)
                    {
                        arguments.Add(numbersStack.Pop());
                    }
                    else
                    {
                        var arg2 = numbersStack.Pop();
                        var arg1 = numbersStack.Pop();
                        arguments.Add(arg1);
                        arguments.Add(arg2);
                    }
                    
                    var result = operation.Calculate(arguments);
                    numbersStack.Push(result);
                }
                else
                {
                    var errorMessage = string.Format(Constants.InvalidTokenErrorMessage, token);
                    throw new ArgumentException(errorMessage);
                }
            }

            return numbersStack.Pop();
        }
    }  
}
