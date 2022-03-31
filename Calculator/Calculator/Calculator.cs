using Calculator.Operations;
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
            foreach (var expressionItem in postfixNotationExpression)
            {
                if (decimal.TryParse(expressionItem, out var number))
                {
                    numbersStack.Push(number);
                }
                else if (_operationsProvider.TryGetOperation(expressionItem, out var operation))
                {
                    var result = operation.Calculate(numbersStack.Pop(), numbersStack.Pop());
                    numbersStack.Push(result);
                }
            }

            return numbersStack.Peek();
        }
    }  
}
