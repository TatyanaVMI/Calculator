using Calculator.Operations;
using System.Collections.Generic;

namespace Calculator
{
    public class Parser: IParser
    {
        private readonly IEnumerable<IOperation> _operations;

        public Parser(IEnumerable<IOperation> operations)
        {
            _operations = operations;
        }

        public string Parse(string expression)
        {
            return expression;
        }
    }
}
