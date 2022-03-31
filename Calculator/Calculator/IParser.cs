using System.Collections.Generic;

namespace Calculator
{
    public interface IParser
    {
        List<string> ParseToPostfixNotation(string expression);
    }
}
