using Calculator.Models;
using System.Collections.Generic;

namespace Calculator
{
    public interface IParser
    {
        List<TokenBase> ParseToPostfixNotation(string expression);
    }
}
