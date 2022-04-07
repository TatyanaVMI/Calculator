namespace Calculator.Operations
{
    public interface IOperationsProvider
    {
        bool IsOperation(char token);

        bool TryGetOperation(string token, out IOperation operation, bool isUnary = false);

        bool TryGetOperation(char token, out IOperation operation, bool isUnary = false);
    }
}
