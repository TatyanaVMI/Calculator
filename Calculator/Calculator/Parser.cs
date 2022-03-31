using Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Parser: IParser
    {
        private readonly IEnumerable<IOperation> _operations;

        private List<string> _output = new List<string>();
        private Stack<char> _operationsStack = new Stack<char>();

        public Parser(IEnumerable<IOperation> operations)
        {
            _operations = operations;
        }

        public List<string> ParseToPostfixNotation(string expression)
        {
            for (var i = 0; i < expression.Length; i++)
            {
                var token = expression[i];

                if (char.IsDigit(token))
                {
                    var numberString = ParseNumber(expression, ref i);
                    _output.Add(numberString);
                }
                else if (IsOperation(token))
                {
                    PushOperationToStack(token);
                }
                else if (token == '(')
                {
                    _operationsStack.Push(token);
                }
                else if (token == ')')
                {
                    var lastChar = ProcessExpressionInBrackets();
                    if (lastChar != "(")
                    {
                        throw new Exception();
                    }

                    _operationsStack.Pop();
                }
                else
                {
                    throw new Exception();
                }
            }

            while (_operationsStack.Count > 0)
            {
                _output.Add(_operationsStack.Pop().ToString());
            }

            return _output;
        }

        private bool IsOperation(char token)
        {
            return _operations
                .Where(operation => operation.CharRepresentation == token)
                .Any();
        }

        private void PushOperationToStack(char token)
        {
            if (_operationsStack.Count > 0)
            {
                while (Helper.OperationPriority[_operationsStack.Peek()] > Helper.OperationPriority[token])
                {
                    _output.Add(_operationsStack.Pop().ToString());
                }
            }

            _operationsStack.Push(token);
        }

        private string ParseNumber(string expression, ref int index)
        {
            var numberList = new List<char> { expression[index] };
            while (index + 1 < expression.Length && (char.IsDigit(expression[index + 1]) || expression[index + 1] == '.'))
            {
                numberList.Add(expression[index + 1]);
                index++;
            }

            return new string(numberList.ToArray());
        }

        private string ProcessExpressionInBrackets()
        {
            var lastChar = string.Empty;
            if (_operationsStack.Count > 0)
            {
                while (lastChar != "(")
                {
                    lastChar = _operationsStack.Pop().ToString();
                    _output.Add(lastChar);
                }
            }

            return lastChar;
        }
    }
}
