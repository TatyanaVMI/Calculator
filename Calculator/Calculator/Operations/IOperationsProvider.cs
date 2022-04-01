namespace Calculator.Operations
{
    public interface IOperationsProvider
    {
        bool IsOperation(char token);

        bool TryGetOperation(string token, out IOperation operation);
    }
}
