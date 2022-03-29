using System.Collections.Generic;

namespace Calculator.Operations
{
    public static class Helper
    {
        public static Dictionary<char, int> OperationPriority = new Dictionary<char, int>
        {
            { '*', 2 },
            { '/', 2 },
            { '-', 1 },
            { '+', 1 },
            { '(', 0 },
            { ')', 0 }
        };
    }
}
