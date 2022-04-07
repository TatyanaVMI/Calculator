using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Tests.Helpers
{
    public class InputToPostfixExpression
    {
        public readonly Dictionary<string, List<TokenBase>> dictionary;

        public InputToPostfixExpression()
        {
            dictionary = new Dictionary<string, List<TokenBase>>()
            {
                { InputExpression.ExpressionWithAllOperationTypes, new List<TokenBase>()
                    {
                        new OperandToken("3"),
                        new OperandToken("4"),
                        new OperandToken("2"),
                        new OperationToken("*"),
                        new OperandToken("1"),
                        new OperandToken("5"),
                        new OperationToken("-"),
                        new OperationToken("/"),
                        new OperationToken("+"),
                        new OperandToken("1"),
                        new OperationToken("-")
                    }
                },
                { InputExpression.ExpressionWithSpaces, new List<TokenBase>()
                    {
                        new OperandToken("1"),
                        new OperandToken("2"),
                        new OperationToken("+")
                    }
                },
                { InputExpression.DecimalNumber, new List<TokenBase>()
                    {
                        new OperandToken(InputExpression.DecimalNumber)
                    }
                }
            };
        }
    }
}
