using Calculator.Models;
using Calculator.Operations;
using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Parser: IParser
    {
        private readonly IOperationsProvider _operationsProvider;

        private readonly List<TokenBase> _output = new List<TokenBase>();
        private readonly Stack<TokenBase> _operationsStack = new Stack<TokenBase>();

        public Parser(IOperationsProvider operationsProvider)
        {
            _operationsProvider = operationsProvider;
        }

        public List<TokenBase> ParseToPostfixNotation(string expression)
        {
            expression = expression.Replace(" ", string.Empty);
            for (var i = 0; i < expression.Length; i++)
            {
                var token = expression[i];

                if (char.IsDigit(token))
                {
                    var numberString = ParseNumber(expression, ref i);
                    var expressionToken = new OperandToken(numberString);
                    _output.Add(expressionToken);
                }
                else if (_operationsProvider.IsOperation(token))
                {
                    PushOperationToStack(token, expression, i);
                }
                else if (token == '(')
                {
                    _operationsStack.Push(new BracketToken(token.ToString()));
                }
                else if (token == ')')
                {
                    ProcessExpressionInBrackets();
                    if (_operationsStack.Count == 0 || _operationsStack.Peek().Value != "(")
                    {
                        throw new ArgumentException(Constants.OpenBracketMissedErrorMessage);
                    }
                    else if (_operationsStack.Count > 0 && _operationsStack.Peek().Value == "(")
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
                _output.Add(_operationsStack.Pop());
            }

            return _output;
        }

        private void PushOperationToStack(char token, string expression, int tokenIndex)
        {
            while (_operationsStack.Count > 0
                && OperationInStackHasHigherPriority(token))
            {
                _output.Add(_operationsStack.Pop());
            }

            var isUnaryOperator = true;
            if (tokenIndex > 0
                && (char.IsDigit(expression[tokenIndex - 1]) || expression[tokenIndex - 1] == ')'))
            {
                isUnaryOperator = false;
            }

            _operationsStack.Push(new OperationToken(token.ToString(), isUnaryOperator));
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
                && _operationsStack.Peek().Value != "(")
            {
                _output.Add(_operationsStack.Pop());
            }
        }

        private bool OperationInStackHasHigherPriority(char token)
        {
            return _operationsProvider.TryGetOperation(token, out var currentOperation)
                && _operationsProvider.TryGetOperation(_operationsStack.Peek().Value, out var operationInStack)
                && operationInStack.Priority >= currentOperation.Priority;
        }
    }
}
