using System.Collections.Generic;
using System.Linq;

namespace Calculator.Operations
{
    public class OperationsProvider: IOperationsProvider
    {
        private readonly IEnumerable<IOperation> _operations;

        public OperationsProvider(IEnumerable<IOperation> operations)
        {
            _operations = operations;
        }
        
        public bool IsOperation(char token)
        {
            return _operations
                .Where(operation => operation.CharRepresentation == token)
                .Any();
        }

        public bool TryGetOperation(string tokenString, out IOperation operation)
        {
            operation = null;
            if (char.TryParse(tokenString, out var token)
                && IsOperation(token))
            {
                try
                {
                    operation = _operations
                       .Where(op => op.CharRepresentation == token)
                       .Single();
                }
                catch
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
