using Calculator.Operations;
using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Parser: IParser
    {
        private readonly IOperationsProvider _operationsProvider;

        private readonly List<string> _output = new List<string>();
        private readonly Stack<char> _operationsStack = new Stack<char>();

        public Parser(IOperationsProvider operationsProvider)
        {
            _operationsProvider = operationsProvider;
        }

        public List<string> ParseToPostfixNotation(string expression)
        {
            for (var i = 0; i < expression.Length; i++)
            {
                var token = expression[i];
                if (char.IsWhiteSpace(token))
                {
                    continue;
                }

                if (char.IsDigit(token))
                {
                    var numberString = ParseNumber(expression, ref i);
                    _output.Add(numberString);
                }
                else if (_operationsProvider.IsOperation(token))
                {
                    PushOperationToStack(token);
                }
                else if (token == '(')
                {
                    _operationsStack.Push(token);
                }
                else if (token == ')')
                {
                    ProcessExpressionInBrackets();
                    if (_operationsStack.Count == 0 || _operationsStack.Peek() != '(')
                    {
                        throw new ArgumentException(Constants.OpenBracketMissedErrorMessage);
                    }
                    else if (_operationsStack.Count > 0 && _operationsStack.Peek() == '(')
                    {
                        _operationsStack.Pop();
                    }
                }
                else
                {
                    var errorMessage = string.Format(Constants.InvalidTokenErrorMessage, token);
                    throw new ArgumentException(errorMessage);
                }
            }

            while (_operationsStack.Count > 0)
            {
                _output.Add(_operationsStack.Pop().ToString());
            }

            return _output;
        }

        private void PushOperationToStack(char token)
        {
            while (_operationsStack.Count > 0
                && OperationInStackHasHigherPriority(token))
            {
                _output.Add(_operationsStack.Pop().ToString());
            }

            _operationsStack.Push(token);
        }

        private string ParseNumber(string expression, ref int index)
        {
            var numberList = new List<char> { expression[index] };
            while (index + 1 < expression.Length
                && (char.IsDigit(expression[index + 1]) || expression[index + 1] == '.'))
            {
                numberList.Add(expression[index + 1]);
                index++;
            }

            return new string(numberList.ToArray());
        }

        private void ProcessExpressionInBrackets()
        {
            while(_operationsStack.Count > 0
                && _operationsStack.Peek() != '(')
            {
                var lastOperation = _operationsStack.Pop().ToString();
                _output.Add(lastOperation);
            }
        }

        private bool OperationInStackHasHigherPriority(char token)
        {
            return _operationsProvider.TryGetOperation(token, out var currentOperation)
                && _operationsProvider.TryGetOperation(_operationsStack.Peek(), out var operationInStack)
                && operationInStack.Priority >= currentOperation.Priority;
        }
    }
}
