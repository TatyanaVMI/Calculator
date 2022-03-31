namespace Calculator.Operations
{
    public interface IOperationsProvider
    {
        bool IsOperation(string token);

        bool TryGetOperation(string token, out IOperation operation);
    }
}
