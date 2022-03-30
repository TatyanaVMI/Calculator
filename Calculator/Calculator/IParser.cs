using System.Collections.Generic;

namespace Calculator
{
    public interface IParser
    {
        string Parse(string expression);
    }
}
