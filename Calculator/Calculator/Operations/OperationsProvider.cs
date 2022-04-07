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

        public bool TryGetOperation(string tokenString, out IOperation operation, bool isUnary = false)
        {
            operation = null;
            if (char.TryParse(tokenString, out var token))
            {
                return TryGetOperation(token, out operation, isUnary);
            }

            return false;
        }

        public bool TryGetOperation(char token, out IOperation operation, bool isUnary = false)
        {
            operation = null;
            if (IsOperation(token))
            {
                try
                {
                    operation = _operations
                       .Where(op => op.CharRepresentation == token
                            && op.IsUnary == isUnary)
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
